using Core;
using Entities.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Web.CustFilters;

namespace Web.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    [AdminAuth]
    public class AreaController : Controller
    {
        IAreaRepo repo;
        ICityRepo srepo;
        
        public AreaController( IAreaRepo repo,ICityRepo srepo)
        {
            this.repo = repo;
            this.srepo = srepo;
        }
        public IActionResult Index()
        {
            return View(this.repo.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            TempData["Message"] = null;
            ViewBag.city=new SelectList(this.srepo.GetAll(),"CityID","CityName");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Area rec)
        {
            TempData["Message"] = null;
            ViewBag.city = new SelectList(this.srepo.GetAll(), "CityID", "CityName");
           
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
            var rec=this.repo.GetById(id);
          
            ViewBag.city = new SelectList(this.srepo.GetAll(), "CityID", "CityName",rec.CityID);
            return View(rec);



        }

        [HttpPost]
        public IActionResult Edit(Area rec)
        {
            TempData["Message"] = null;

            ViewBag.city = new SelectList(this.srepo.GetAll(), "CityID", "CityName", rec.CityID);
          
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
