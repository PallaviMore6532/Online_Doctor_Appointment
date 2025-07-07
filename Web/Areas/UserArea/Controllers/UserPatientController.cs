using Core;
using Entities.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.Areas.UserArea.Controllers
{
	[Area("UserArea")]

	public class UserPatientController : Controller
	{

		IPatientinfo repo;
        IWebHostEnvironment env;
        public UserPatientController(IPatientinfo repo, IWebHostEnvironment env)
        {
            this.repo = repo;
            this.env = env;
        }
        public IActionResult Index()
		{
			Int64 uid = Convert.ToInt64(HttpContext.Session.GetString("UserID"));
			var v = this.repo.getbyUserID(uid);
			return View(v.ToList());
		}

		public IActionResult Edit(Int64 id)
		{
			var rec=this.repo.getbyPatientID(id);
			return View(rec);
		}

		[HttpPost]
		public IActionResult Edit(Patient rec)
		{
			TempData["Message"] = null;
			if (ModelState.IsValid)
			{
				if (rec.Photo != null)
                {
                    if (rec.Photo.Length > 0)
                    {
                        string relative = Path.Combine("ProjectPhpto", rec.Photo.FileName);
                        string actualpath = Path.Combine(this.env.WebRootPath, relative);
                        FileStream fs = new FileStream(actualpath, FileMode.Create);
                        rec.Photo.CopyTo(fs);
                        rec.PhotoPath = "\\" + relative;
                    }
                }
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

	}
}
