using Entities.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.ViewComponents
{
    public class DoctorRatingVC: ViewComponent
    {
        IDoctorRatingRepo repo;
        public DoctorRatingVC(IDoctorRatingRepo repo)
        {
            this.repo = repo;
        }

        public IViewComponentResult Invoke()
        {
            Int64 cid = Convert.ToInt64(HttpContext.Session.GetString("ClinicID"));
            Int64 did = Convert.ToInt64(HttpContext.Session.GetString("DoctorID"));
            var res = this.repo.GetbyClinicid(cid, did);
          //  var res = this.repo.GetAll();
            return View(res);
        }

    }
}
