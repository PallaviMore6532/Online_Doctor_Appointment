using Core;
using Entities.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Web.CustFilters;

namespace Web.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    [AdminAuth]
    public class CityController : Controller
    {
        ICityRepo repo;
        IStateRepo srepo;
        
        public CityController(ICityRepo repo, IStateRepo srepo)
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
            ViewBag.state=new SelectList(this.srepo.GetAll(),"StateID","StateName");
            return View();
        }

        [HttpPost]
        public IActionResult Create(City rec)
        {
            TempData["Message"] = null;
            ViewBag.state = new SelectList(this.srepo.GetAll(), "StateID", "StateName");
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
            ViewBag.state = new SelectList(this.srepo.GetAll(), "StateID", "StateName",rec.StateID);
            return View(rec);



        }

        [HttpPost]
        public IActionResult Edit(City rec)
        {
            TempData["Message"] = null;
            ViewBag.state = new SelectList(this.srepo.GetAll(), "StateID", "StateName", rec.StateID);
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
