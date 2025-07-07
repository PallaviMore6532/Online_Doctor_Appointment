using Core;
using Entities.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Web.CustFilters;

namespace Web.Controllers
{
    public class RatingController : Controller
    {
        IClinicRatingRepo repo;

        public RatingController(IClinicRatingRepo repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            return View();
        }


        [UserAuth]
        [HttpGet]
        public IActionResult AddRating(Int64 id)
        {
            
            HttpContext.Session.SetString("ClinicID",id.ToString());
            Int64 cid = Convert.ToInt64(HttpContext.Session.GetString("ClinicID"));
          //  var a=this.repo.ratingbyclinicid(cid);
            return View();
        }

        [HttpPost]
        public IActionResult AddRating(ClinicRating rec)
        {
            this.repo.Add(rec);
            return RedirectToAction("Index","Home");
        }

        [HttpGet]
        public IActionResult ViewRating(Int64 id)
        {
            var v=this.repo.GetByClinicID(id);

            return View(v.ToList());
        }
    }
}
