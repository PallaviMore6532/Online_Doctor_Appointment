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
    public class DoctorRatingRepo : IDoctorRatingRepo
    {
        TimeContext repo;
        public DoctorRatingRepo(TimeContext repo)
        {
            this.repo = repo;
        }

        public RepoResultVM Add(DoctorRating rec)
        {
            RepoResultVM rv = new RepoResultVM();
            try
            {
                this.repo.DoctorRatings.Add(rec);
                this.repo.SaveChanges();
                rv.IsSuccess = true;
                rv.Message = "Doctor Rating Added Successfully";
            }
            catch (Exception ex)
            {
                rv.IsSuccess = false;
                rv.Message = ex.Message;

            }
            return rv;
        }

        public List<DoctorRating> GetAll()
        {
            return this.repo.DoctorRatings.ToList();
        }

        public List<DoctorRating> GetbyClinicid(long clinicID, long DoctorID)
        {
           return this.repo.DoctorRatings.Where(d=>d.DoctorID==DoctorID && d.Doctor.Clinic.ClinicID==clinicID).ToList();
        }

      
    }
}
