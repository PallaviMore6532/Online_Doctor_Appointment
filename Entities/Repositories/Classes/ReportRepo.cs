using Core;
using Entities.Repositories.Interfaces;
using Entities.ViewModels;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Repositories.Classes
{
	public class ReportRepo : IReportRepo
	{
		TimeContext repo;
		public ReportRepo(TimeContext repo) 
		{
		   this.repo = repo;
		}

        public List<Patient> Appointmentdaily(DailycollectionVM rec)
        {
           var v=from t in this.repo.Patients
				 join t1 in this.repo.BookedAppointments
				 on t.PatientID equals t1.PatientID
				 join t2 in this.repo.Doctors
				 on t1.DoctorSchedule.DoctorID equals t2.DoctorID
				 where(t2.DoctorID ==rec.DoctorID && t1.AppointmentDate.Date >= rec.FromDate.Date && t1.AppointmentDate.Date <= rec.ToDate.Date)
				 select t;
			return v.ToList();
        }

        public List<dailyPatientamtVM> dailyrecord(DailycollectionVM rec)
			{
			//dailyPatientamtVM r= new dailyPatientamtVM();
			var v = from t in this.repo.Patients
					join t1 in this.repo.BookedAppointments
					on t.PatientID equals t1.PatientID
					join t2 in this.repo.Doctors
					on t1.DoctorSchedule.DoctorID equals t2.DoctorID
					where (t2.DoctorID == rec.DoctorID && t1.AppointmentDate.Date >= rec.FromDate.Date && t1.AppointmentDate.Date <= rec.ToDate.Date)
					select new dailyPatientamtVM
					{
						  AppointmentDate = t1.AppointmentDate,
						  PatientName=t.FirstName,
						  Amount=t2.VisitingCharges,
						  PatientID=t1.PatientID,
						

					};


		        return(v.ToList());

				  



		}
	}
}
