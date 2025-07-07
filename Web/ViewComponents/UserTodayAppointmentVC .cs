using Entities.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace Web.ViewComponents
{
    public class UserTodayAppointmentVC:ViewComponent
    {
        IUserAppointmentRepo repo;
        public UserTodayAppointmentVC(IUserAppointmentRepo repo)
        {
            this.repo = repo;
        }

        public IViewComponentResult Invoke()
        {
            Int64 uid =  Convert.ToInt64(HttpContext.Session.GetString("UserID"));
            var res = this.repo.TodayUserBook(uid);
            return View(res);
        }
    }
}
