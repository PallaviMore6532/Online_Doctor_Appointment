using Entities.Repositories.Interfaces;
using Entities.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.Areas.ClinicAdminArea.Controllers
{
	[Area("ClinicAdminArea")]
	public class DailyCollectionController : Controller
	{
		IDoctorRepo repo;
		IReportRepo report;

		public DailyCollectionController(IDoctorRepo repo,IReportRepo report)
		{
			this.repo = repo;
			this.report = report;
		}
	
		public IActionResult Index()
		{
            Int64 cid = Convert.ToInt64(HttpContext.Session.GetString("ClinicID"));
            ViewBag.doctor= new SelectList(this.repo.GetAllById(cid), "DoctorID", "FirstName");
			return View();
		}

		[HttpPost]
		public IActionResult DailyCollection(DailycollectionVM rec)
		{
            Int64 cid = Convert.ToInt64(HttpContext.Session.GetString("ClinicID"));
            ViewBag.doctor = new SelectList(this.repo.GetAllById(cid), "DoctorID", "FirstName");
            var v=this.report.dailyrecord(rec);
			return View(v.ToList());
		}
	}
}
