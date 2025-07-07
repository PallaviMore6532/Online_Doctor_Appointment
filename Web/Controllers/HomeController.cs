using Entities;
using Entities.Repositories.Interfaces;
using Entities.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Cryptography;
using System.Collections.Generic;
using Web.CustFilters;
using Core;
using System.Numerics;
using NuGet.Packaging.Signing;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Web.Controllers
{
    public class HomeController : Controller
    {

        IAreaRepo repo;
        IClinicRepo crepo;
        ISpecilityRepo srepo;
        ICityRepo citrepo;
        IDoctorRepo drepo;
        IdoctorSpecialitiesRepo dsrepo;
        IDoctorScheduleRepo dschedule;
        IPatientinfo pinfo;
        IClinicRatingRepo clirepo;
        IDoctorRatingRepo drating;
        IWebHostEnvironment env;


        public HomeController(IAreaRepo repo,IClinicRepo crepo, ISpecilityRepo srepo, ICityRepo citrepo,IDoctorRepo drepo,IdoctorSpecialitiesRepo dsrepo,IDoctorScheduleRepo dschedule,IPatientinfo pa,IClinicRatingRepo clirepo,IDoctorRatingRepo drating, IWebHostEnvironment env)
        {
            this.repo = repo;
            this.crepo = crepo;
            this.srepo = srepo;
            this.citrepo = citrepo;
            this.drepo = drepo;
            this.dsrepo = dsrepo;
          this.dschedule = dschedule;
            this.pinfo = pa;
            this.clirepo = clirepo;
            this.drating = drating;
            this.env = env;
        }

        public IActionResult Index()
        {
            ViewBag.aname = new SelectList(this.repo.GetAll(), "AreaID", "AreaName");
            ViewBag.cname = new SelectList(this.crepo.GetAll(), "ClinicID", "ClinicName");
            ViewBag.sname = new SelectList(this.srepo.GetAll(), "SpecilityID", "SpecilityName");


            return View(this.crepo.GetAll());
          
        }

        public IActionResult searchByName(Int64 aname=0,Int64 sname= 0)
        {
			ViewBag.aname = new SelectList(this.repo.GetAll(), "AreaID", "AreaName");
			ViewBag.cname = new SelectList(this.crepo.GetAll(), "ClinicID", "ClinicName");
			ViewBag.sname = new SelectList(this.srepo.GetAll(), "SpecilityID", "SpecilityName");

            //if (aname == 0 && sname == 0)
            if(aname != 0 && sname !=0)
            {

              //  var v = this.crepo.GetAll();
                var v=this.crepo.GetClinicdetail(aname, sname);
                return View("Index",v.ToList());

            }





            else
            {
                var v = this.crepo.GetAll();
               // var v = this.crepo.GetAll().Where(p => p.ClinicID == aname && p.ClinicID == sname);
                return View("Index", v.ToList());
            }



        }

        [HttpGet]
        public IActionResult BookAppointment(Int64 id)
        {
           
           
            var v1 = this.dsrepo.getdocbyclinicnew(id);
            return View(v1.ToList());
        }

        [HttpGet]
        public IActionResult BookSchedule(Int64 id) 
        {
           
                var doctor = this.drepo.getbyDoctorid(id);
                var v = this.dschedule.getdoctorschedulebydoctorid(id);
               // var v1 = this.dschedule.getbyDoctorscheduleid(id);
                //session created for doctor visiting charges fees
                HttpContext.Session.SetString("VisitingCharges", doctor.VisitingCharges.ToString());
                HttpContext.Session.SetString("DoctorScheduleID", v.DoctorScheduleID.ToString());
                return View(v);
          
            
        }

        [UserAuth]
        [HttpGet]
        public IActionResult AddPatient() 
        {
			TempData["Message"] = null;
			return View();
        }



        [HttpPost]
        public IActionResult AddPatient(Patient rec)
        {

            //           TempData["Message"] = null;
            //           if (rec != null)
            //           {


            //               var v1 = this.pinfo.Patientinfo(rec);
            //               TempData["Message"] = v1.Message;
            //               var v = this.pinfo.getbyPatientID(rec.PatientID);
            //               HttpContext.Session.SetString("PatientID", v.PatientID.ToString());
            //HttpContext.Session.SetString("AppointmentDate", v.AppointmentDate.ToString());






            //  }
            //  return RedirectToAction("MakePayment", "Payment");


            if (rec.Photo == null)
            {
                ModelState.AddModelError("Photo", "Please Select File to Upload!");
                return View(rec);
            }

            if (rec.Photo.Length <= 0)
            {
                ModelState.AddModelError("Photo", "Please Select File to Upload!");
                return View(rec);
            }

            string relative = Path.Combine("ProjectPhpto", rec.Photo.FileName);
            string actualpath = Path.Combine(this.env.WebRootPath, relative);
            FileStream fs = new FileStream(actualpath, FileMode.Create);
            rec.Photo.CopyTo(fs);
            rec.PhotoPath = "\\" + relative;
            var v1 = this.pinfo.Patientinfo(rec);
            TempData["Message"] = v1.Message;
            var v = this.pinfo.getbyPatientID(rec.PatientID);
            HttpContext.Session.SetString("PatientID", v.PatientID.ToString());
            HttpContext.Session.SetString("AppointmentDate", v.AppointmentDate.ToString());

            if (v1 != null)
            {
                //TempData["Message"] = res.Message;
                return RedirectToAction("MakePayment", "Payment");
            }
            else
            {
                ModelState.AddModelError("", "Invalid patient infp");
                return View(rec);
            }

        
       
           




          
           

        }

        [HttpGet]
        public IActionResult DoctorRating(Int64 id,Int64 cid)
        {
            var clinic = this.crepo.getbyid(cid);
            HttpContext.Session.SetString("ClinicID", clinic.ClinicID.ToString());


            var doctor = this.drepo.getbyDoctorid(id);
            HttpContext.Session.SetString("DoctorID", doctor.DoctorID.ToString());

            return View();
        }

        [HttpPost]
        public IActionResult DoctorRating(DoctorRating rec)
        {
           this.drating.Add(rec);
            return RedirectToAction("Index", "Home");
        }








    }
}
