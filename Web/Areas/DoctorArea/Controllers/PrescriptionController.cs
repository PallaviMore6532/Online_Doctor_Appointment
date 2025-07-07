using Core;
using Entities.Repositories.Interfaces;
using Entities.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Protocol;

namespace Web.Areas.DoctorArea.Controllers
{
	[Area("DoctorArea")]
	public class PrescriptionController : Controller
	{
		IPatientinfo repo;
		IMedicineRepo mrepo;
		IPrescriptionRepo prepo;
		public PrescriptionController(IPatientinfo repo, IMedicineRepo mrepo, IPrescriptionRepo prepo)
		{
			this.repo = repo;
			this.mrepo = mrepo;
			this.prepo = prepo;
		}

		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public IActionResult CreatePrescription(Int64 id,Int64 bid)
		{
			

                HttpContext.Session.SetString("PatientID", id.ToString());
                Int64 pid = Convert.ToInt64(HttpContext.Session.GetString("PatientID"));

                HttpContext.Session.SetString("BookedAppointmentID", bid.ToString());
                Int64 bookid = Convert.ToInt64(HttpContext.Session.GetString("BookedAppointmentID"));



                var p = this.repo.getbyPatientID(pid);
                return View(p);
          
		}

		[HttpGet]
		public IActionResult GeneratePrescription()
		{
			TempData["Message"] = null;
			ViewBag.medicine = new SelectList(this.mrepo.GetAll(), "MedicineID", "MedicineName");
			return View();
		}

		[HttpPost]
		public IActionResult GeneratePrescription(Prescription rec, Int64[] MedicineID, Int64[] Qty, Int64[] Dosage, string[] Duration, string[] Remark)
		{
			TempData["Message"] = null;
			ViewBag.medicine = new SelectList(this.mrepo.GetAll(), "MedicineID", "MedicineName");

			if(ModelState.IsValid) 
			{
				var res = this.prepo.Add(rec, MedicineID, Qty, Dosage, Duration, Remark);
				if(res.IsSuccess)
				{
					TempData["Message"] = res.Message;
					return RedirectToAction("index");
				}
				else
				{
					ModelState.AddModelError("", res.Message);
					return View(rec);
				}
			
			}
			return View(rec);
		}

		[HttpGet]
		public IActionResult PatientMedicine(Int64 id)
		{
			//TempData["Message"] = null;

			//var v = this.prepo.getprescriptionbyappid(id);
			//ViewBag.medicine = new SelectList(this.mrepo.GetAll(), "MedicineID", "MedicineName", v.MedicineID);



			        var v1 = this.prepo.getbyid(id);


			//return View(v1.ToList());
			return View(v1.ToList());
		
		}

		[HttpGet]
		public IActionResult Edit(Int64 id,Int64 pid)
		{
			TempData["Message"] = null;
			var v1=this.prepo.getbyprescriptionid(pid);
			HttpContext.Session.SetString("PrescriptionID", v1.PrescriptionID.ToString());


			var v = this.prepo.getprescriptionbyappid(id);
			ViewBag.medicine = new SelectList(this.mrepo.GetAll(), "MedicineID", "MedicineName", v.MedicineID);

			return View(v);
		}

		[HttpPost]
		public IActionResult Edit(PrescriptionDetail rec)
		{
			TempData["Message"] = null;

			ViewBag.medicine = new SelectList(this.mrepo.GetAll(), "MedicineID", "MedicineName", rec.MedicineID);

			if (ModelState.IsValid)
			{
				var v = this.prepo.Edit(rec);
				if (v.IsSuccess)
				{
					TempData["Message"] = v.Message;
					return RedirectToAction("index");
				}
				else
				{
					ModelState.AddModelError("", v.Message);
					return View(rec);
				}


			}
			return View(rec);
		}
	}
}
