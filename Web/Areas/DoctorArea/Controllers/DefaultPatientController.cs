using Entities.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Web.Areas.DoctorArea.Controllers
{
    [Area("DoctorArea")]
    public class DefaultPatientController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Patientinformation(DailycollectionVM rec)
        {
            return View();
        }
    }
}
