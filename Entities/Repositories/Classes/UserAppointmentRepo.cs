using Core;
using Entities.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Repositories.Classes
{
    public class UserAppointmentRepo : IUserAppointmentRepo
    {
        TimeContext repo;
        public UserAppointmentRepo(TimeContext cc) 
        {
           this.repo = cc;
        }

        public List<Patient> dayaftertomorrowBook(long Uid)
        {
            var booked = from t in this.repo.Users
                         join t1 in this.repo.Patients
                         on t.UserID equals t1.UserID
                         join t2 in this.repo.BookedAppointments
                         on t1.PatientID equals t2.PatientID
                         where t.UserID == Uid && t2.AppointmentDate.Date == DateTime.Today.AddDays(2).Date
                         select t1;

            return booked.ToList();
        }

        public List<Patient> TodayUserBook(Int64 UserID)
        {
            var booked = from t in this.repo.Users
                         join t1 in this.repo.Patients
                         on t.UserID equals t1.UserID
                         join t2 in this.repo.BookedAppointments
                         on t1.PatientID equals t2.PatientID
                         where t.UserID == UserID && t2.AppointmentDate.Date == DateTime.Now.Date
                         select t1;

            return booked.ToList();
           
        }

        public List<Patient> TommorrowUserBook(long UserID)
        {
            var booked = from t in this.repo.Users
                         join t1 in this.repo.Patients
                         on t.UserID equals t1.UserID
                         join t2 in this.repo.BookedAppointments
                         on t1.PatientID equals t2.PatientID
                         where t.UserID == UserID && t2.AppointmentDate.Date == DateTime.Today.AddDays(1).Date
                         select t1;

            return booked.ToList();
        }
    }
}
