using Microsoft.AspNetCore.Mvc;

namespace Web.ViewComponents
{
    public class AddDoctorRatingVC:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
             return View();
        }
    }
}
