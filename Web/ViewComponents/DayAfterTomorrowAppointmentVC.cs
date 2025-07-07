using Entities.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.ViewComponents
{
	public class DayAfterTomorrowAppointmentVC:ViewComponent
	{
		ITimeRepo repo;
		public DayAfterTomorrowAppointmentVC(ITimeRepo repo)
		{
			this.repo = repo;
		}

		public IViewComponentResult Invoke()
		{
            //var res = this.repo.dayaftertomorrowBook();
            Int64 uid = Convert.ToInt64(HttpContext.Session.GetString("DoctorID"));
            var res = this.repo.dayaftertomorrowBookDoctor(uid);
            return View(res);
		}
	}
}
