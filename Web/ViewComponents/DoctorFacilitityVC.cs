
using Entities;
using Entities.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Web.ViewComponents
{
    public class DoctorFacilitityVC:ViewComponent
    {
        TimeContext cntx;
        public DoctorFacilitityVC(TimeContext cntx)
        {
            this.cntx = cntx;
        }

        public IViewComponentResult Invoke()
        {
            var v = from t in this.cntx.Specilities
                    select new CheckBoxVM
                    {
                        CheckBoxID = t.SpecilityID,
                        CheckBoxText = t.SpecilityName,
                        IsSelected = false
                    };
                   return View(v.ToList());

        }
    }
}
