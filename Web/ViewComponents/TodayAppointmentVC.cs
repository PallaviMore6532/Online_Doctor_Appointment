using Entities.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.ViewComponents
{
    public class TodayAppointmentVC:ViewComponent
    {
        ITimeRepo repo;
        public TodayAppointmentVC(ITimeRepo repo)
        {
            this.repo = repo;
        }

        public IViewComponentResult Invoke()
        {
           
            Int64 uid = Convert.ToInt64(HttpContext.Session.GetString("DoctorID"));
            var res = this.repo.TodayBookDoctor(uid);
            return View(res);
        }
    }
}
