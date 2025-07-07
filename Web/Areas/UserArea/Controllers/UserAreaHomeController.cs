using Entities.Repositories.Interfaces;
using Entities.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Web.Areas.UserArea.Controllers
{
    [Area("UserArea")]
    public class UserAreaHomeController : Controller
    {
        IUserRepo repo;
        public UserAreaHomeController(IUserRepo repo)
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
                Int64 userid = Convert.ToInt64(HttpContext.Session.GetString("UserID"));
                var res = this.repo.ChangePassword(rec, userid);
                ModelState.AddModelError("", res.Message);
                return View(rec);
            }
            return View(rec);
        }

        [HttpGet]
        public IActionResult EditProfile()
        {
            Int64 id = Convert.ToInt64(HttpContext.Session.GetString("UserID"));
            var rec = this.repo.GetForEditProfile(id);
            return View(rec);
        }

        [HttpPost]
        public IActionResult EditProfile(EditProfileVM rec)
        {
            if (ModelState.IsValid)
            {
                Int64 id = Convert.ToInt64(HttpContext.Session.GetString("UserID"));
                var res = this.repo.EditProfile(rec, id);
                ModelState.AddModelError("", res.Message);
                return View(rec);
            }
            return View(rec);
        }





    }
}
