using Microsoft.AspNetCore.Mvc;

namespace Web.Areas.UserArea.Controllers
{
    [Area("UserArea")]
    public class AppointmentUserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
