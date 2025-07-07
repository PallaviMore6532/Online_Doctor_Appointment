using Core;
using Entities.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.Areas.ClinicAdminArea.Controllers
{
    [Area("ClinicAdminArea")]
    public class MedicineController : Controller
    {
        IMedicineRepo repo;
        public MedicineController(IMedicineRepo repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            return View(this.repo.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            TempData["Message"] = null;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Medicine rec)
        {
            TempData["Message"] = null;
          
            if (ModelState.IsValid)
            {
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
            var rec = this.repo.GetByid(id);
            return View(rec);
        }

        [HttpPost]
        public IActionResult Edit(Medicine rec)
        {
            TempData["Message"] = null;
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
            var v = this.repo.Delete(id);
            TempData["Message"] = v.Message;
            return RedirectToAction("Index");


        }

    }
}
