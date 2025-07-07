using Core;
using Entities.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Web.CustFilters;

namespace Web.Areas.AdminArea.Controllers
{
    [Area("ClinicAdminArea")]
    
    public class ClinicRatingController : Controller
    {
        IClinicRatingRepo repo;
        IClinicRepo courepo;
        public ClinicRatingController(IClinicRatingRepo repo, IClinicRepo courepo)
        {
            this.repo = repo;
            this.courepo = courepo;
        }
        public IActionResult Index()
        {
            Int64 cid = Convert.ToInt64(HttpContext.Session.GetString("ClinicID"));
            return View(this.repo.GetAllById(cid));
        }

      

        [HttpGet]
        public IActionResult Delete(Int64 id) 
        {
            TempData["Message"] = null;
            var rec = this.repo.Delete(id);
            TempData["Message"] = rec.Message;
            return RedirectToAction("Index");
        }
    }
}
