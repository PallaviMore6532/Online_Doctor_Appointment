using Entities.Repositories.Interfaces;
using Entities.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class ManageDoctorsController : Controller
    {
        IDoctorRepo repo;
        public ManageDoctorsController(IDoctorRepo repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignIn(LoginDrVM rec)
        {
            if (ModelState.IsValid)
            {
                var c = this.repo.SignIn(rec);
                if (c.IsSuccess)
                {

                    HttpContext.Session.SetString("DoctorID", c.LoggedInID.ToString());
                    HttpContext.Session.SetString("FirstName", c.LoggedInName);
                    
                    HttpContext.Session.SetString("VisitingCharges", c.VisitingCharges.ToString());

                    return RedirectToAction("Index", "DoctorAreaHome", new { area = "DoctorArea" });
                }

                ModelState.AddModelError("", c.ErrorMessage);
                return View(rec);


            }
            return View(rec);
        }

        [HttpGet]
        public IActionResult Signout()
        {
            this.HttpContext.Session.Clear();
            return View();
        }
    }
}
