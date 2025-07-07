using Core;
using Entities;

using Entities.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net;

namespace Web.Areas.ClinicAdminArea.Controllers
{
    [Area("ClinicAdminArea")]
    public class DoctorController : Controller
    {
        TimeContext repo;
        IWebHostEnvironment env;
        public DoctorController(TimeContext repo, IWebHostEnvironment env)
        {
            this.repo = repo;
            this.env = env;
        }
        public IActionResult Index()
        {
			ViewBag.area = new SelectList(this.repo.Areas.ToList(), "AreaID", "AreaName");
            //ViewBag.clinic = new SelectList(this.repo.Clinics.ToList(), "ClinicID", "ClinicName");
            Int64 cid = Convert.ToInt64(HttpContext.Session.GetString("ClinicID"));
            var v = from t in this.repo.Doctors
                    where t.ClinicID == cid
                    select new DoctorVm
                    {

                        DoctorID = t.DoctorID,
                        FirstName = t.FirstName,
                        LastName = t.LastName,
                        MobileNo = t.MobileNo,
                        Address = t.Address,
                        IsAvailable = t.IsAvailable,
                        DoctorExperiance = t.DoctorExperiance,
                        AreaID = t.AreaID,
                        PhotoPath = t.PhotoPath,
                        DoctorQualification = t.DoctorQualification,
                        Password = t.Password,
                       // ClinicID = t.ClinicID,
                        ClinicName=t.Clinic.ClinicName,
                        AreaName=t.Area.AreaName,
                        VisitingCharges = t.VisitingCharges,
                        doctorfacilitycount = t.DoctorSpecialities.Count()
                        
                    };

         
            return View(v.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.area = new SelectList(this.repo.Areas.ToList(), "AreaID", "AreaName");
          //  ViewBag.clinic = new SelectList(this.repo.Clinics.ToList(), "ClinicID", "ClinicName");

            return View();
        }

        [HttpPost]
        public IActionResult Create(DoctorVm rec)
        {

            ViewBag.area = new SelectList(this.repo.Areas.ToList(), "AreaID", "AreaName");
           // ViewBag.clinic = new SelectList(this.repo.Clinics.ToList(), "ClinicID", "ClinicName");

            if(ModelState.IsValid) 
            {
                if (rec.photo == null)
                {
                    ModelState.AddModelError("Photo", "Please Select File to Upload!");
                    return View(rec);
                }

                if (rec.photo.Length <= 0)
                {
                    ModelState.AddModelError("Photo", "Please Select File to Upload!");
                    return View(rec);
                }

                string relative = Path.Combine("ProjectPhpto", rec.photo.FileName);
                string actualpath = Path.Combine(this.env.WebRootPath, relative);
                FileStream fs = new FileStream(actualpath, FileMode.Create);
                rec.photo.CopyTo(fs);
                rec.PhotoPath = "\\" + relative;


                Int64 cid = Convert.ToInt64(HttpContext.Session.GetString("ClinicID"));
                Doctor d = new Doctor();

				d.FirstName = rec.FirstName;
				d.LastName = rec.LastName;
				d.MobileNo = rec.MobileNo;
				d.Address = rec.Address;
				d.IsAvailable = rec.IsAvailable;
				d.DoctorExperiance = rec.DoctorExperiance;
				d.AreaID = rec.AreaID;
                d.photo = rec.photo;
				d.PhotoPath = rec.PhotoPath;
				d.DoctorQualification = rec.DoctorQualification;
				d.Password = rec.Password;
                d.ClinicID = cid;
                d.VisitingCharges = rec.VisitingCharges;

				foreach (var temp in rec.dfacility)
				{
					DoctorSpeciality df = new DoctorSpeciality();
					df.SpecilityID = temp;
					d.DoctorSpecialities.Add(df);
				}
				this.repo.Doctors.Add(d);
				this.repo.SaveChanges();
				return RedirectToAction("Index");
				
			}
            return View(rec);

        }

        [HttpGet]
        public IActionResult Edit(Int64 id)
        {
			ViewBag.area = new SelectList(this.repo.Areas.ToList(), "AreaID", "AreaName");
            //ViewBag.clinic = new SelectList(this.repo.Clinics.ToList(), "ClinicID", "ClinicName");
            Int64 cid = Convert.ToInt64(HttpContext.Session.GetString("ClinicID"));

            var v = from t in this.repo.Doctors
                    where t.DoctorID == id
					select new DoctorVm
					{ 
						DoctorID = t.DoctorID,
						FirstName = t.FirstName,
						LastName = t.LastName,
						MobileNo = t.MobileNo,
						Address = t.Address,
						IsAvailable = t.IsAvailable,
						DoctorExperiance = t.DoctorExperiance,
						AreaID = t.AreaID,
                        photo=t.photo,
						PhotoPath = t.PhotoPath,
						DoctorQualification = t.DoctorQualification,
						Password = t.Password,
					//	ClinicID = t.ClinicID,
                        VisitingCharges = t.VisitingCharges,
						doctorfacilitycount = t.DoctorSpecialities.Count()
					};
			return View(v.FirstOrDefault());

		}

        [HttpPost]
        public IActionResult Edit(DoctorVm rec)
        {
            if(ModelState.IsValid) 
            {
				//delete all data from doctor
				var dfacility = from t in this.repo.DoctorSpecialities
								where t.DoctorID == rec.DoctorID
								select t;

				foreach (var temp in dfacility)
				{
					this.repo.DoctorSpecialities.Remove(temp);
				}

                if (rec.photo != null)
                {
                    if (rec.photo.Length > 0)
                    {
                        string relative = Path.Combine("ProjectPhpto", rec.photo.FileName);
                        string actualpath = Path.Combine(this.env.WebRootPath, relative);
                        FileStream fs = new FileStream(actualpath, FileMode.Create);
                        rec.photo.CopyTo(fs);
                        rec.PhotoPath = "\\" + relative;
                    }
                }

                Int64 cid = Convert.ToInt64(HttpContext.Session.GetString("ClinicID"));
                Doctor d = this.repo.Doctors.Find(rec.DoctorID);
                
                
                    d.FirstName = rec.FirstName;
                    d.LastName = rec.LastName;
                    d.MobileNo = rec.MobileNo;
                    d.Address = rec.Address;
                    d.IsAvailable = rec.IsAvailable;
                    d.DoctorExperiance = rec.DoctorExperiance;
                    d.AreaID = rec.AreaID;
                    d.PhotoPath = rec.PhotoPath;
                    d.photo = rec.photo;
                    d.DoctorQualification = rec.DoctorQualification;
                    d.Password = rec.Password;
                    d.ClinicID = cid;
                d.VisitingCharges = rec.VisitingCharges;



                    foreach (var temp in rec.dfacility)
                    {
                        DoctorSpeciality ds = new DoctorSpeciality();
                        ds.SpecilityID = temp;
                        d.DoctorSpecialities.Add(ds);
                    }
					this.repo.SaveChanges();
				

               
                return RedirectToAction("Index");





			}
            return View(rec);
        }

        [HttpGet]
        public IActionResult Delete(Int64 id)
        {
			var dfacility = from t in this.repo.DoctorSpecialities
							where t.DoctorID == id
							select t;

			foreach (var temp in dfacility)
			{
				this.repo.DoctorSpecialities.Remove(temp);
			}

            var v=from t in this.repo.Doctors
                  where t.DoctorID == id
                  select t;

            foreach (var temp in v) 
            {
               this.repo.Doctors.Remove(temp);
            
            }

            this.repo.SaveChanges();

            return RedirectToAction("Index");

        }

      
    }
}
