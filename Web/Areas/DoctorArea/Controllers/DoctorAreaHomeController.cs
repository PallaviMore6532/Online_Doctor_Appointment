using Entities.Repositories.Interfaces;
using Entities.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Web.Areas.DoctorArea.Controllers
{
    [Area("DoctorArea")]
    public class DoctorAreaHomeController : Controller
    {
        IDoctorRepo repo;
        public DoctorAreaHomeController(IDoctorRepo repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ChangePassword(ChangePasswordVM rec)
        {
            if (ModelState.IsValid)
            {
                Int64 drid = Convert.ToInt64(HttpContext.Session.GetString("DoctorID"));
                var res = this.repo.ChangePassword(rec, drid);
                ModelState.AddModelError("", res.Message);
                return View(rec);
            }
            return View(rec);
        }
    }
}
