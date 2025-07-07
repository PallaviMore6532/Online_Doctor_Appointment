using Core;
using Entities.Repositories.Interfaces;
using Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Repositories.Classes
{
    public class DoctorReportRepo : IDoctorReportRepo
    {
        TimeContext repo;
        public DoctorReportRepo(TimeContext repo)
        {
            this.repo = repo;
        }

        public List<BookedAppointment> doctorToday(long DID, decimal amt)
        {
            //var v = from t in this.repo.Patients
            //        join t1 in this.repo.BookedAppointments
            //        on t.PatientID equals t1.PatientID
            //        join t2 in this.repo.Doctors
            //        on t1.DoctorSchedule.DoctorID equals t2.DoctorID
            //        where (t2.DoctorID == DID && t1.AppointmentDate == DateTime.Now.Date && t2.VisitingCharges == amt)
            //        select t1;
            //return v.ToList();
            var booked = from t in this.repo.BookedAppointments
                         where t.DoctorSchedule.DoctorID == DID && t.AppointmentDate.Date == DateTime.Now.Date && t.DoctorSchedule.Doctor.VisitingCharges==amt
                         select t;
            return booked.ToList();

        }

        public List<Patient> TodayPatient(long DID,decimal amt)
        {
            var v = from t in this.repo.Patients
                    join t1 in this.repo.BookedAppointments
                    on t.PatientID equals t1.PatientID
                    join t2 in this.repo.Doctors
                    on t1.DoctorSchedule.DoctorID equals t2.DoctorID
                    where (t2.DoctorID == DID && t1.AppointmentDate == DateTime.Now.Date && t2.VisitingCharges==amt)
                    select t;
           return v.ToList();
        }

        public List<DoctorReportVM> TodayPatients(long DID, decimal amt)
        {
            var v = from t in this.repo.Patients
                    join t1 in this.repo.BookedAppointments
                    on t.PatientID equals t1.PatientID
                    join t2 in this.repo.Doctors
                    on t1.DoctorSchedule.DoctorID equals t2.DoctorID
                    where (t2.DoctorID == DID && t1.AppointmentDate == DateTime.Now.Date && t2.VisitingCharges == amt)
                    select new DoctorReportVM
                    {
                          PatientName=t.FirstName,
                          Amt=t2.VisitingCharges
                    };
            return v.ToList();

        }
    }
}
