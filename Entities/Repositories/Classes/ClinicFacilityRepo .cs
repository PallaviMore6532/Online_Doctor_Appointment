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
    public class ClinicFacilityRepo : IClinicFacilityRepo
    {
        TimeContext repo;
        public ClinicFacilityRepo(TimeContext repo) 
        {
           this.repo = repo;
        }
        public RepoResultVM Add(ClinicFacility rec)
        {
            RepoResultVM rv=new RepoResultVM();
            try
            {
                this.repo.ClinicFacilities.Add(rec);
                this.repo.SaveChanges();
                rv.IsSuccess = true;
                rv.Message = "Clinic Facility Added Successfully";
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
            RepoResultVM rv= new RepoResultVM();
            try
            {
                var rec = this.repo.ClinicFacilities.Find(id);
                this.repo.ClinicFacilities.Remove(rec);
                this.repo.SaveChanges();
                rv.IsSuccess = true;
                rv.Message = "Clinic facility Deleted";
            }
            catch (Exception ex) 
            {
              rv.IsSuccess= false;
                rv.Message = ex.Message;
            }
            return rv;
        }

       

        public RepoResultVM Edit(ClinicFacility rec)
        {
            RepoResultVM rv= new RepoResultVM();
            try
            {
                this.repo.Entry(rec).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                this.repo.SaveChanges();
                rv.IsSuccess = true;
                rv.Message = "Clinic facility Updated !...";
            }
            catch (Exception ex) 
            {
               rv.IsSuccess=false;
                rv.Message = ex.Message;

            }
            return rv;

        }

        public List<ClinicFacility> GetAll()
        {
            return this.repo.ClinicFacilities.ToList();
        }

        public List<ClinicFacility> GetAllById(long clinicid)
        {
            return this.repo.ClinicFacilities.Where(p=>p.ClinicID==clinicid).ToList();
        }

        public ClinicFacility GetById(long id)
        {
            return this.repo.ClinicFacilities.Find(id);
        }
    }
}
