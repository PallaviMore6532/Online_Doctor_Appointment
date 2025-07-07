using Core;
using Entities.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Repositories.Classes
{
    public class TimeRepo : ITimeRepo
    {
        TimeContext repo;
        public TimeRepo(TimeContext repo) 
        {
               this.repo = repo;
        }
      

        public List<BookedAppointment> TodayBookDoctor(long did)
        {
            var booked = from t in repo.BookedAppointments
                         where t.DoctorSchedule.DoctorID == did && t.AppointmentDate.Date == DateTime.Now.Date 
                         select t;

            return booked.ToList();
        }

        public List<BookedAppointment> TommorrowBookDoctor(long did)
        {
            var booked = from t in repo.BookedAppointments
                         where t.DoctorSchedule.DoctorID == did && t.AppointmentDate.Date == DateTime.Today.AddDays(1).Date
                         select t;

            return booked.ToList();
        }

        public List<BookedAppointment> dayaftertomorrowBookDoctor(long did)
        {
            var booked = from t in this.repo.BookedAppointments
                         where t.DoctorSchedule.DoctorID==did && t.AppointmentDate.Date == DateTime.Today.AddDays(2).Date
                         select t;
            return booked.ToList();
        }
    }

}
