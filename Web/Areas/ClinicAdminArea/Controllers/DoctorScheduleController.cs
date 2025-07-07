using Core;
using Entities;
using Entities.Repositories.Interfaces;
using Entities.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.Areas.ClinicAdminArea.Controllers
{
    [Area("ClinicAdminArea")]
    public class DoctorScheduleController : Controller
    {
        IDoctorScheduleRepo repo;
        IDoctorRepo cc;
        IdoctorSpecialitiesRepo srepo;
        IOpdSessionRepo orepo;
       
        public DoctorScheduleController(IDoctorScheduleRepo repo, IDoctorRepo cc,IdoctorSpecialitiesRepo srepo,IOpdSessionRepo orepo)
        {
            this.repo = repo;
            this.cc=cc;
            this.srepo = srepo;
            this.orepo = orepo;
        }

       
        public IActionResult Index()
        {
            Int64 cid = Convert.ToInt64(HttpContext.Session.GetString("ClinicID"));
            var v=this.repo.GetAllById(cid);
            return View(v.ToList());
        }

        [HttpGet]
        public IActionResult Create() 
        {
            TempData["Message"] = null;
            Int64 cid = Convert.ToInt64(HttpContext.Session.GetString("ClinicID"));
            ViewBag.opd = new SelectList(this.orepo.GetAllById(cid), "OPDSessionID", "SessionName");
            ViewBag.doctors = new SelectList(this.cc.GetAllById(cid), "DoctorID", "FirstName");

            //ViewBag.doctors = new SelectList(this.cc.GetAll(), "DoctorID", "FirstName");
            //ViewBag.opd = new SelectList(this.orepo.GetAll(), "OPDSessionID", "SessionName");
            return View();
        
        }

        [HttpPost]
        public IActionResult Create(DoctorSchedule rec)
        {
            TempData["Message"] = null;
            Int64 cid = Convert.ToInt64(HttpContext.Session.GetString("ClinicID"));
            ViewBag.opd = new SelectList(this.orepo.GetAllById(cid), "OPDSessionID", "SessionName");
            ViewBag.doctors = new SelectList(this.cc.GetAllById(cid), "DoctorID", "FirstName");
          
            if (ModelState.IsValid) 
            {
                var v=this.repo.Add(rec);
                if(v.IsSuccess)
                {
					TempData["Message"] = v.Message;
					return RedirectToAction("Index");
				}
				else
				{
					ModelState.AddModelError("", v.Message);
					return View(rec);
				}
               
			}
            return View(rec);
        }

        [HttpGet]
        public IActionResult Edit(Int64 id)
        {
            Int64 cid = Convert.ToInt64(HttpContext.Session.GetString("ClinicID"));
            ViewBag.opd = new SelectList(this.orepo.GetAllById(cid), "OPDSessionID", "SessionName");
            var v = this.repo.getdoctorschedulebydoctorid(id);
            var v1=this.srepo.GetDoctorSpecialitydoctorid(id);

            var viewmo = new DoctorScheduleVM
            {
                 doctorSpeciality=v1,
                 doctorSchedule=v
            };

            return View(viewmo);
        }

        [HttpPost]
        public IActionResult Edit(DoctorScheduleVM rec)
        {
            Int64 cid = Convert.ToInt64(HttpContext.Session.GetString("ClinicID"));
            //  ViewBag.opd = new SelectList(this.orepo.GetAll(), "OPDSessionID", "SessionName");
            ViewBag.opd = new SelectList(this.orepo.GetAllById(cid), "OPDSessionID", "SessionName");
            if (ModelState.IsValid) 
            {
                var v = this.repo.getdoctorschedulebydoctorid(rec.doctorSchedule.DoctorID);
                if (v != null)
                {
                    v.StartTime = rec.doctorSchedule.StartTime;
                    v.EndTime = rec.doctorSchedule.EndTime;
                    v.Interval = rec.doctorSchedule.Interval;
                    v.DayOfWeek = rec.doctorSchedule.DayOfWeek;
                    v.OPDSessionID = rec.doctorSchedule.OPDSessionID;

					this.repo.EditSave(v);
				}
                return RedirectToAction("Index");


                
            
              
            }
            return View(rec);
        }

        [HttpGet]
        public IActionResult Delete(Int64 id)
        {
            TempData["Message"] = null;
            var rec = this.repo.Delete(id);
            TempData["Message"] = rec.Message;
            return RedirectToAction("Index");
        }

       





    }
}
