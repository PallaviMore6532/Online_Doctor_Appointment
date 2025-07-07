using Core;
using Entities.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Web.CustFilters;

namespace Web.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    [AdminAuth]
    public class SpecilityController : Controller
    {
        ISpecilityRepo repo;
        public SpecilityController(ISpecilityRepo repo)
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
        public IActionResult Create(Specility rec)
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
            var rec = this.repo.GetByID(id);
            return View(rec);
        }

        [HttpPost]
        public IActionResult Edit(Specility rec)
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
