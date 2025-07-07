using Entities.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.ViewComponents
{
	public class UserTomorrowAppointmentVC:ViewComponent
	{
		IUserAppointmentRepo repo;
		public UserTomorrowAppointmentVC(IUserAppointmentRepo repo)
		{
			this.repo = repo;
		}

		public IViewComponentResult Invoke()
		{
            Int64 uid = Convert.ToInt64(HttpContext.Session.GetString("UserID"));
            var res = this.repo.TommorrowUserBook(uid);
			return View(res);
		}
	}
}
