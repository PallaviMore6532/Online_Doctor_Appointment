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
    public class CityRepo : ICityRepo
    {
        TimeContext repo;
        public CityRepo(TimeContext repo) 
        {
           this.repo = repo;
        }

        public RepoResultVM Add(City rec)
        {
            RepoResultVM rv = new RepoResultVM();
            try
            {
                this.repo.Citys.Add(rec);
                this.repo.SaveChanges();
                rv.IsSuccess = true;
                rv.Message = "City Added Successfully";
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
                var rec = this.repo.Citys.Find(id);
                this.repo.Citys.Remove(rec);
                this.repo.SaveChanges();
                rv.IsSuccess = true;
                rv.Message = "City Deleted";
            }
            catch (Exception ex)
            {
                rv.IsSuccess = false;
                rv.Message = ex.Message;
            }
            return rv;
        }

        public RepoResultVM Edit(City rec)
        {
            RepoResultVM rv = new RepoResultVM();
            try
            {
                this.repo.Entry(rec).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                this.repo.SaveChanges();
                rv.IsSuccess = true;
                rv.Message = "City Updated !...";
            }
            catch (Exception ex)
            {
                rv.IsSuccess = false;
                rv.Message = ex.Message;

            }
            return rv;
        }

        public List<City> GetAll()
        {
            return this.repo.Citys.ToList();
        }

        public City GetById(long id)
        {
            return this.repo.Citys.Find(id);
        }
    }
}
