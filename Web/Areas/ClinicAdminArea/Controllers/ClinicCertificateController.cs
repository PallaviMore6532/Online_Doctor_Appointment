using Core;
using Entities.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Web.CustFilters;

namespace Web.Areas.AdminArea.Controllers
{
    [Area("ClinicAdminArea")]
    
    public class ClinicCertificateController : Controller
    {
        IClinicCertificateRepo repo;
        IClinicRepo courepo;
        public ClinicCertificateController(IClinicCertificateRepo repo, IClinicRepo courepo)
        {
            this.repo = repo;
            this.courepo = courepo;
        }
        public IActionResult Index()
        {
            Int64 cid = Convert.ToInt64(HttpContext.Session.GetString("ClinicID"));
            return View(this.repo.GetAllById(cid));
        }

        [HttpGet]
        public IActionResult Create()
        {
            TempData["Message"] = null;

          //  ViewBag.Clinic=new SelectList(this.courepo.GetAll(),"ClinicID","ClinicName");
            return View();
        }

        [HttpPost]
        public IActionResult Create(ClinicCertificate rec)
        {
            TempData["Message"] = null;
          
            //  ViewBag.Clinic = new SelectList(this.courepo.GetAll(), "ClinicID", "ClinicName");
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
         //   ViewBag.Clinic = new SelectList(this.courepo.GetAll(), "ClinicID", "ClinicName",rec.ClinicID);

            return View(rec);
        }

        [HttpPost]
        public IActionResult Edit(ClinicCertificate rec)
        {
            TempData["Message"] = null;
            Int64 cid = Convert.ToInt64(HttpContext.Session.GetString("ClinicID"));
            rec.ClinicID = cid;
            //  ViewBag.Clinic = new SelectList(this.courepo.GetAll(), "ClinicID", "ClinicName", rec.ClinicID);
            if (ModelState.IsValid)
            {
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
