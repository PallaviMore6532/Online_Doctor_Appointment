using Core;
using Entities.Repositories.Interfaces;
using Entities.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.Controllers
{
    public class ManageUsersController : Controller
    {
        IUserRepo repo;
        ICountryRepo crepo;
        public ManageUsersController(IUserRepo repo,ICountryRepo crepo)
        {
             this.repo = repo;
            this.crepo = crepo;
        }
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignIn(LoginVM rec)
        {
              if(ModelState.IsValid) 
            {
               var rv=this.repo.SignIn(rec);
                if(rv.IsSuccess) 
                {
                   HttpContext.Session.SetString("UserID",rv.LoggedInID.ToString());
                    HttpContext.Session.SetString("UserName", rv.LoggedInName);
                    return RedirectToAction("Index", "Home", new { area = "" });
                }

                ModelState.AddModelError("", rv.ErrorMessage);
                return View(rec);
            
            }
              return View(rec);
        }


        [HttpGet]
        public IActionResult SignUp()
        {
           ViewBag.Countries = new SelectList(this.crepo.GetAll(), "CountryID", "CountryName");
            return View();
        }

        [HttpPost]
        public IActionResult Signup(UserSignUpVM rec)
        {
            ViewBag.Countries = new SelectList(this.crepo.GetAll(), "CountryID", "CountryName");
            if (ModelState.IsValid)
            {
                var res = this.repo.signUp(rec);
                if (res.IsSuccess)
                {
                    ViewBag.Message = res.Message;
                    return View("SignIn");
                }
                else
                {
                    ModelState.AddModelError("", res.Message);
                    return View(rec);
                }

            }
            return View(rec);
        }

        [HttpGet]
        public IActionResult SignOut()
        {
            this.HttpContext.Session.Clear();
            return RedirectToAction("SignIn");
        }


    }
}
