using Core;
using Entities.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Web.CustFilters;

namespace Web.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    [AdminAuth]
    public class StateController : Controller
    {
        IStateRepo repo;
        ICountryRepo courepo;
        public StateController(IStateRepo repo, ICountryRepo courepo)
        {
            this.repo = repo;
            this.courepo = courepo;
        }
        public IActionResult Index()
        {
            return View(this.repo.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            TempData["Message"] = null;
            ViewBag.Country=new SelectList(this.courepo.GetAll(),"CountryID","CountryName");
            return View();
        }

        [HttpPost]
        public IActionResult Create(State rec)
        {
            TempData["Message"] = null;
            ViewBag.Country = new SelectList(this.courepo.GetAll(), "CountryID", "CountryName");
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
          
            var rec = this.repo.GetById(id);
            ViewBag.Country = new SelectList(this.courepo.GetAll(), "CountryID", "CountryName",rec.CountryID);

            return View(rec);
        }

        [HttpPost]
        public IActionResult Edit(State rec)
        {
            TempData["Message"] = null;
            ViewBag.Country = new SelectList(this.courepo.GetAll(), "CountryID", "CountryName",rec.CountryID);
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
