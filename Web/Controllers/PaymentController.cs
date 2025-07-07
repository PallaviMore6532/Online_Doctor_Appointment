using Core;
using Entities.Enums;
using Entities.Repositories.Interfaces;
using Entities.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class PaymentController : Controller
    {
        IBookAppointmentRepo repo;
        public PaymentController(IBookAppointmentRepo repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MakePayment()
        {
            return View();
        }

        public IActionResult FinalBook(int PaymentMode)
        {
            if (PaymentMode == (int)PaymentModeEnum.CashOnDelivery)

            {
                return RedirectToAction("cash", new { pmode = PaymentMode });

            }
            else
            {
                return RedirectToAction("PaymentGateway");
            }



        }

        [HttpGet]
        public IActionResult PaymentGateway()
        {
            ///payment code 
            /// request payment gateway
            /// 
            return View();
        }

        [HttpPost]
        public IActionResult PaymentGateway(PaymentGatewayVM vm)
        {
            ///payment gateway
            ///response from payment 

            return RedirectToAction("cash",new {pmode=1});
        }


        public IActionResult cash(int Pmode)
        {
            Int64 dsid = Convert.ToInt64(HttpContext.Session.GetString("DoctorScheduleID"));
            Int64 uid = Convert.ToInt64(HttpContext.Session.GetString("UserID"));

            Int64 pid = Convert.ToInt64(HttpContext.Session.GetString("PatientID"));
            decimal amt = Convert.ToDecimal(HttpContext.Session.GetString("VisitingCharges"));
            DateTime da = Convert.ToDateTime(HttpContext.Session.GetString("AppointmentDate"));
            
            var res=this.repo.appointment( Pmode,uid, dsid, pid,amt,da);






            return View(res);

        }

        public IActionResult success()
        {
            return View();
        }

    }
}
