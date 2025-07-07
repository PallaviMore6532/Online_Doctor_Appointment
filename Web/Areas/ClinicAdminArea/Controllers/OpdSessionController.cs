using Core;
using Entities.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.Areas.ClinicAdminArea.Controllers
{
	[Area("ClinicAdminArea")]
	public class OpdSessionController : Controller
	{
		IOpdSessionRepo repo;
		IClinicRepo crepo;
		public OpdSessionController(IOpdSessionRepo repo,IClinicRepo crepo)
		{
			this.repo = repo;
			this.crepo = crepo;
		}
		
		public IActionResult Index()
		{
            Int64 cid = Convert.ToInt64(HttpContext.Session.GetString("ClinicID"));
            var v=this.repo.GetAllById(cid);
			return View(v);
		}

        [HttpGet]
        public IActionResult Create()
        {
            TempData["Message"] = null;
          //  ViewBag.Clinic = new SelectList(this.crepo.GetAll(), "ClinicID", "ClinicName");
            return View();
        }

        [HttpPost]
        public IActionResult Create(OPDSession rec)
        {
            TempData["Message"] = null;
          //  ViewBag.Clinic = new SelectList(this.crepo.GetAll(), "ClinicID", "ClinicName");
            if (ModelState.IsValid)
            {
                Int64 cid = Convert.ToInt64(HttpContext.Session.GetString("ClinicID"));
                rec.ClinicID = cid;
                var v = this.repo.Add(rec);
                if (v.IsSuccess)
                {
                    TempData["Message"] = v.Message;
                    return RedirectToAction("index");
                }
                else
                {
                    ModelState.AddModelError("", v.Message);
                    return View(v);
                }

            }
            return View(rec);
        }

        [HttpGet]
        public IActionResult Edit(Int64 id)
        {
            TempData["Message"] = null;

            var rec = this.repo.GetById(id);
           // ViewBag.Clinic = new SelectList(this.crepo.GetAll(), "ClinicID", "ClinicName", rec.ClinicID);

            return View(rec);
        }

        [HttpPost]
        public IActionResult Edit(OPDSession rec)
        {
            TempData["Message"] = null;
           // ViewBag.Clinic = new SelectList(this.crepo.GetAll(), "ClinicID", "ClinicName", rec.ClinicID);
            if (ModelState.IsValid)
            {
                Int64 cid = Convert.ToInt64(HttpContext.Session.GetString("ClinicID"));
                rec.ClinicID = cid;
                var v = this.repo.Edit(rec);
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
