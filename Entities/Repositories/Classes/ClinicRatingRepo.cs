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
    public class ClinicRatingRepo : IClinicRatingRepo
    {
        TimeContext repo;
        public ClinicRatingRepo(TimeContext repo) 
        {
           this.repo = repo;
        }
        public RepoResultVM Add(ClinicRating rec)
        {
            RepoResultVM rv=new RepoResultVM();
            try
            {
                this.repo.ClinicRatings.Add(rec);
                this.repo.SaveChanges();
                rv.IsSuccess = true;
                rv.Message = "Clinic Rating Added Successfully";
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
                var rec = this.repo.ClinicRatings.Find(id);
                this.repo.ClinicRatings.Remove(rec);
                this.repo.SaveChanges();
                rv.IsSuccess = true;
                rv.Message = "Clinic Rating Deleted";
            }
            catch (Exception ex) 
            {
              rv.IsSuccess= false;
                rv.Message = ex.Message;
            }
            return rv;
        }

       

        public RepoResultVM Edit(ClinicRating rec)
        {
            RepoResultVM rv= new RepoResultVM();
            try
            {
                this.repo.Entry(rec).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                this.repo.SaveChanges();
                rv.IsSuccess = true;
                rv.Message = "Clinic Rating Updated !...";
            }
            catch (Exception ex) 
            {
               rv.IsSuccess=false;
                rv.Message = ex.Message;

            }
            return rv;

        }

        public List<ClinicRating> GetAll()
        {
            return this.repo.ClinicRatings.ToList();
        }

        public List<ClinicRating> GetAllById(long clinicid)
        {
            return this.repo.ClinicRatings.Where(d=>d.ClinicID==clinicid).ToList();
           
        }

        public List<ClinicRating> GetByClinicID(long id)
        {
            var v = this.repo.ClinicRatings.Where(d => d.ClinicID == id);
            return v.ToList();
        }

        public ClinicRating GetById(long id)
        {
            return this.repo.ClinicRatings.Find(id);
        }

        public ClinicRating ratingbyclinicid(long id)
        {
            return this.repo.ClinicRatings.FirstOrDefault(d => d.ClinicID == id);
        }
    }
}
