using Entities.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.ViewComponents
{
	public class TomorrowAppointmentVC:ViewComponent
	{
		ITimeRepo repo;
		public TomorrowAppointmentVC(ITimeRepo repo)
		{
			this.repo = repo;
		}

		public IViewComponentResult Invoke()
		{
            //var res = this.repo.TomorrowBook();
            Int64 uid = Convert.ToInt64(HttpContext.Session.GetString("DoctorID"));
            var res = this.repo.TommorrowBookDoctor(uid);
            return View(res);
		}
	}
}
