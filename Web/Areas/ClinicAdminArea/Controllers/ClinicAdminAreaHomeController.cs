using Entities.Repositories.Interfaces;
using Entities.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Web.Areas.ClinicAdminArea.Controllers
{
    [Area("ClinicAdminArea")]
    public class ClinicAdminAreaHomeController : Controller
    {
        IClinicAdminRepo repo;
        public ClinicAdminAreaHomeController(IClinicAdminRepo repo)
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
                Int64 cadminid = Convert.ToInt64(HttpContext.Session.GetString("ClinicAdminID"));
                var res = this.repo.ChangePassword(rec, cadminid);
                ModelState.AddModelError("", res.Message);
                return View(rec);
            }
            return View(rec);
        }


        [HttpGet]
        public IActionResult EditProfile()
        {
            Int64 cadminid = Convert.ToInt64(HttpContext.Session.GetString("ClinicAdminID"));
            var rec=this.repo.GetForEditProfile(cadminid);
            return View(rec);
        }

        [HttpPost]
        public IActionResult EditProfile(EditProfileVM rec)
        {
            if(ModelState.IsValid)
            {
                Int64 cadminid = Convert.ToInt64(HttpContext.Session.GetString("ClinicAdminID"));
                var res=this.repo.EditProfile(rec, cadminid);
                ModelState.AddModelError("", res.Message);
                    return View(rec);
            }
            return View(rec);
        }


    }
}
