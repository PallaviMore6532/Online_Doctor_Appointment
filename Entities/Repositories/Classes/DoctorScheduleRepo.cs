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
    public class DoctorScheduleRepo : IDoctorScheduleRepo
    {
        TimeContext repo;
        public DoctorScheduleRepo(TimeContext repo)
        {
            this.repo = repo;
        }

        public RepoResultVM Add(DoctorSchedule rec)
        {
            RepoResultVM rv = new RepoResultVM();
            try
            {
                this.repo.DoctorSchedules.Add(rec);
                this.repo.SaveChanges();
                rv.IsSuccess = true;
                rv.Message = "Schedule Created";
            }
            catch (Exception ex) 
            {
                  rv.IsSuccess = false;
                rv.Message = ex.Message;
            }
            return rv;
        }

        public RepoResultVM Delete(long id)
        {
            RepoResultVM rv = new RepoResultVM();
            try
            {
                var rec = this.repo.DoctorSchedules.Find(id);
                this.repo.DoctorSchedules.Remove(rec);
                this.repo.SaveChanges();
                rv.IsSuccess = true;
                rv.Message = "Doctor Schedule Deleted";
            }
            catch (Exception ex)
            {
                rv.IsSuccess = false;
                rv.Message = ex.Message;
            }
            return rv;
        }

      
        public List<DoctorSchedule> doctorschedulebydoctorid(long doctorid)
		{
			return this.repo.DoctorSchedules.Where(d => d.DoctorID == doctorid).ToList();
		}



		//public List<DoctorSchedule> doctorschedulebydoctorid(long doctorid)
		//{
		//    return this.repo.DoctorSchedules.Where(d=>d.DoctorID == doctorid).ToList();
		//}

		public RepoResultVM Edit(DoctorSchedule rec)
        {
            RepoResultVM rv = new RepoResultVM();
            try
            {
                this.repo.Entry(rec).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                this.repo.SaveChanges();
                rv.IsSuccess = true;
                rv.Message = "Doctor Schedule Updated";
            }
            catch (Exception ex) 
            {
                 rv.IsSuccess=false;
                rv.Message = ex.Message;
            }
            return rv;
            
        }

		public void EditSave(DoctorSchedule rec)
		{
            this.repo.Entry(rec).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
           // this.repo.DoctorSchedules.Add(rec);
			this.repo.SaveChanges();
		}

		public List<DoctorSpeciality> GetAll()
        {
            return this.repo.DoctorSpecialities.ToList();
        }

        public List<DoctorSpeciality> GetAllById(long clinicid)
        {
            return this.repo.DoctorSpecialities.Where(d=>d.Doctor.ClinicID == clinicid).ToList();
        }

        public DoctorSchedule getbyDoctorscheduleid(long DoctorScheduleid)
        {
            return this.repo.DoctorSchedules.FirstOrDefault(d => d.DoctorScheduleID == DoctorScheduleid);
        }

        public DoctorSchedule Getbyid(long id)
        {
            return this.repo.DoctorSchedules.Find(id);
        }

        public DoctorSchedule getdoctorschedulebydoctorid(long doctorid)
        {
            return this.repo.DoctorSchedules.FirstOrDefault(d => d.DoctorID == doctorid);
        }





      
    }
}
