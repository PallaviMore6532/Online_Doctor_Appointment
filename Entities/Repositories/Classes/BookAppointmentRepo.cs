using Core;
using Entities.Enums;
using Entities.Repositories.Interfaces;
using Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Repositories.Classes
{
	public class BookAppointmentRepo : IBookAppointmentRepo
	{
		TimeContext repo;
		public BookAppointmentRepo(TimeContext repo) 
		{
		   this.repo = repo;
		
		}

        public BookVM appointment(int Pmode, long userid, long dsid, Int64 pid, decimal Amount,DateTime da)
        {
			BookVM bookVM = new BookVM();
			try
			{
                var pa = this.repo.Patients.Where(d => d.UserID == userid);
                var ds = this.repo.DoctorSchedules.Where(d => d.DoctorScheduleID == dsid);

              if(pa != null && ds != null) 
                {
                   BookedAppointment ba=new BookedAppointment();
                    {
                        foreach (var temp in ds)

                        {
                            ba.AppointmentDate = da;
                            ba.StartTime = temp.StartTime;
                            ba.EndTime = temp.EndTime;
                            ba.DoctorScheduleID = temp.DoctorScheduleID;
                            ba.PatientID = pid;
                            ba.IsPaid = false;
                        }

                    }

                        if (Pmode ==(int)PaymentModeEnum.CashOnDelivery)
                        {
                            ba.IsPaid = false;
                        }
                        else
                        {
                            ba.IsPaid= true;
                        }

                        this.repo.BookedAppointments.Add(ba);
                        this.repo.SaveChanges();


                    BookedAppPayment payment = new BookedAppPayment();
                    {
                        payment.BookedAppointmentID = ba.BookedAppointmentID;
                        payment.Amount = Amount;
                        payment.PaymentMode = Pmode;

                    }

                    this.repo.BookedAppPayments.Add(payment);
                    this.repo.SaveChanges();


                    bookVM.AppointmentDate = DateTime.Now;
                    bookVM.StartTime = ba.StartTime;
                    bookVM.EndTime = ba.EndTime;
                    bookVM.Amount = Amount;
                    bookVM.PatientID = pid;
                    bookVM.IsSuccess = true;
                    
                    bookVM.Message = "Appointment Successfully";

                }


               

            }
            catch (Exception ex)
            {
                bookVM.IsSuccess = false;
                bookVM.Message = ex.Message;

            }

            return bookVM;







        }

       
    }
}
