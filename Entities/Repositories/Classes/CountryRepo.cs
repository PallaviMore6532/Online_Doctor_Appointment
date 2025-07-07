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
    public class CountryRepo : ICountryRepo
    {
        TimeContext repo;
        public CountryRepo(TimeContext repo) 
        {
           this.repo = repo;
        }
        public RepoResultVM Add(Country rec)
        {
            RepoResultVM rv=new RepoResultVM();
            try
            {
                this.repo.Countrys.Add(rec);
                this.repo.SaveChanges();
                rv.IsSuccess = true;
                rv.Message = "Country Added Successfully";
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
                var rec = this.repo.Countrys.Find(id);
                this.repo.Countrys.Remove(rec);
                this.repo.SaveChanges();
                rv.IsSuccess = true;
                rv.Message = "Country Deleted";
            }
            catch (Exception ex) 
            {
              rv.IsSuccess= false;
                rv.Message = ex.Message;
            }
            return rv;
        }

       

        public RepoResultVM Edit(Country rec)
        {
            RepoResultVM rv= new RepoResultVM();
            try
            {
                this.repo.Entry(rec).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                this.repo.SaveChanges();
                rv.IsSuccess = true;
                rv.Message = "Country Updated !...";
            }
            catch (Exception ex) 
            {
               rv.IsSuccess=false;
                rv.Message = ex.Message;

            }
            return rv;

        }

        public List<Country> GetAll()
        {
            return this.repo.Countrys.ToList();
        }

        public Country GetById(long id)
        {
            return this.repo.Countrys.Find(id);
        }
    }
}
