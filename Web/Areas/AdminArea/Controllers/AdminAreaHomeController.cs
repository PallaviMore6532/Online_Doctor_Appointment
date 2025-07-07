using Entities.Repositories.Interfaces;
using Entities.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Web.CustFilters;

namespace Web.Areas.AdminArea.Controllers
{
	[Area("AdminArea")]
	[AdminAuth]
	public class AdminAreaHomeController : Controller
	{
		IAdminRepo repo;
		public AdminAreaHomeController(IAdminRepo repo)
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
			if(ModelState.IsValid) 
			{
				Int64 adminid = Convert.ToInt64(HttpContext.Session.GetString("AdminID"));
				var res=this.repo.ChangePassword(rec, adminid);
				ModelState.AddModelError("", res.Message);
				return View(rec);
			}
			return View(rec);

		}
	}
}
