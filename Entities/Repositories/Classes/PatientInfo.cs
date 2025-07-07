using Core;
using Entities.Repositories.Interfaces;
using Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Repositories.Classes
{
    public class PatientInfo : IPatientinfo
    {
        TimeContext repo;
        public PatientInfo(TimeContext repo) 
        {
           this.repo = repo;
        }

		public RepoResultVM Edit(Patient rec)
		{
			RepoResultVM rv = new RepoResultVM();
			try
			{
				this.repo.Entry(rec).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
				this.repo.SaveChanges();
				rv.IsSuccess = true;
				rv.Message = "Patient Detail is Updated !...";
			}
			catch (Exception ex)
			{
				rv.IsSuccess = false;
				rv.Message = ex.Message;

			}
			return rv;

		}

		public Patient getbyPatientID(long PatientID)
        {
            return this.repo.Patients.SingleOrDefault(d => d.PatientID == PatientID);
        }

        public List<Patient> getbyUserID(long uid)
        {
           return this.repo.Patients.Where(t=>t.UserID == uid).ToList();
        }

        public RepoResultVM Patientinfo(Patient rec)
        {
            RepoResultVM rv=new RepoResultVM();

            try
            {
               this.repo.Patients.Add(rec);

                this.repo.SaveChanges();
                rv.IsSuccess = true;
                rv.Message = "Patient Addded Successfully";
            }
            catch (Exception ex) 
            {
                rv.IsSuccess= false;
                rv.Message = ex.Message;
            }
            return rv;
        }
    }
}
