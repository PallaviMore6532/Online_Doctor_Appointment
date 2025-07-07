using Core;
using Entities.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.Areas.DoctorArea.Controllers
{
    [Area("DoctorArea")]

    public class TodayAppointmentController : Controller
    {
        IDoctorReportRepo repo;

        public TodayAppointmentController(IDoctorReportRepo repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            Int64 cid = Convert.ToInt64(HttpContext.Session.GetString("DoctorID"));
          
            decimal amt = Convert.ToDecimal(HttpContext.Session.GetString("VisitingCharges"));
            var v = this.repo.doctorToday(cid,amt);
            return View(v.ToList());
        }
    }
}
