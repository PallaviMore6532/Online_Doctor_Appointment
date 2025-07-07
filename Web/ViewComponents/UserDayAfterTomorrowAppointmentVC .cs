using Entities.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.ViewComponents
{
	public class UserDayAfterTomorrowAppointmentVC:ViewComponent
	{
		IUserAppointmentRepo repo;
		public UserDayAfterTomorrowAppointmentVC(IUserAppointmentRepo repo)
		{
			this.repo = repo;
		}

		public IViewComponentResult Invoke()
		{
            Int64 uid = Convert.ToInt64(HttpContext.Session.GetString("UserID"));
            var res = this.repo.dayaftertomorrowBook(uid);
			return View(res);
		}
	}
}
