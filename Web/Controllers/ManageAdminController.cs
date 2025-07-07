using Entities.Repositories.Interfaces;
using Entities.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class ManageAdminController : Controller
    {
        IAdminRepo repo;
        public ManageAdminController(IAdminRepo repo)
        {
            this.repo = repo;
        }
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignIn(LoginVM rec)
        {
           if(ModelState.IsValid) 
            {
                var c=this.repo.SignIn(rec);
                if(c.IsSuccess)
                {

                    HttpContext.Session.SetString("AdminID", c.LoggedInID.ToString());
                    HttpContext.Session.SetString("FullName", c.LoggedInName);

                    return RedirectToAction("Index", "AdminAreaHome", new {area="AdminArea"});
                }

                ModelState.AddModelError("",c.ErrorMessage);
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
