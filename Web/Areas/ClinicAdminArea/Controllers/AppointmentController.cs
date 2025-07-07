using Entities.Repositories.Interfaces;
using Entities.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.Areas.ClinicAdminArea.Controllers
{
    [Area("ClinicAdminArea")]
    public class AppointmentController : Controller
    {
        IDoctorRepo repo;
        IReportRepo reportRepo;
     

        public AppointmentController(IDoctorRepo repo, IReportRepo reportRepo)
        {
            this.repo = repo;
            this.reportRepo = reportRepo;
        }
        public IActionResult Index()
        {
            Int64 cid = Convert.ToInt64(HttpContext.Session.GetString("ClinicID"));
            ViewBag.doctor = new SelectList(this.repo.GetAllById(cid), "DoctorID", "FirstName");
            return View();
        }

        [HttpPost]
        public IActionResult Appointment(DailycollectionVM rec)
        {
            Int64 cid = Convert.ToInt64(HttpContext.Session.GetString("ClinicID"));
            ViewBag.doctor = new SelectList(this.repo.GetAllById(cid), "DoctorID", "FirstName");
            var res = this.reportRepo.Appointmentdaily(rec);
            return View(res);
        }
    }
}
