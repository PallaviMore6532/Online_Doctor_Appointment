using Entities.Repositories.Interfaces;
using Entities.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.Controllers
{
    
    public class ManageClinicAdminController : Controller
    {
        IClinicAdminRepo repo;
        ICityRepo crepo;
        IWebHostEnvironment env;
		public ManageClinicAdminController(IClinicAdminRepo repo,ICityRepo crepo,IWebHostEnvironment env)
        {
            this.repo = repo;
            this.crepo = crepo;
            this.env = env;
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

                    HttpContext.Session.SetString("ClinicAdminID", c.LoggedInID.ToString());
                    HttpContext.Session.SetString("FullName", c.LoggedInName);
                    HttpContext.Session.SetString("ClinicID", c.ClinicID.ToString());

                    return RedirectToAction("Index", "ClinicAdminAreaHome", new {area="ClinicAdminArea"});
               
                }

                ModelState.AddModelError("",c.ErrorMessage);
                return View(rec);
            
            
            }
           return View(rec);
        }


        [HttpGet]
        public IActionResult SignUp()
        {
            ViewBag.cities = new SelectList(this.crepo.GetAll(), "CityID", "CityName");
            return View();
        }

        [HttpPost]
        public IActionResult Signup(ClinicAdminCompoVM rec)
        {
            ViewBag.cities = new SelectList(this.crepo.GetAll(), "CityID", "CityName");
            if (ModelState.IsValid)
            {
                if (rec.Photo == null)
                {
                    ModelState.AddModelError("Photo", "Please Select File to Upload!");
                    return View(rec);
                }

                if (rec.Photo.Length <= 0)
                {
                    ModelState.AddModelError("Photo", "Please Select File to Upload!");
                    return View(rec);
                }

                string relative = Path.Combine("ProjectPhpto", rec.Photo.FileName);
                string actualpath = Path.Combine(this.env.WebRootPath, relative);
                FileStream fs = new FileStream(actualpath, FileMode.Create);
                rec.Photo.CopyTo(fs);
                rec.Logopath = "\\" + relative;

                var res = this.repo.SignUp(rec);
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
        public IActionResult Signout()
        {
            this.HttpContext.Session.Clear();
            return View();
        }

    }
}
