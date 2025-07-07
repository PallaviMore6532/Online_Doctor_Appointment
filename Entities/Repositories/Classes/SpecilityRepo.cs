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
    public class SpecilityRepo : ISpecilityRepo
    {
        TimeContext repo;
        public SpecilityRepo(TimeContext repo) 
        {
           this.repo = repo;
        }
        public RepoResultVM Add(Specility rec)
        {
            RepoResultVM rv=new RepoResultVM();
            try
            {
                this.repo.Specilities.Add(rec);
                this.repo.SaveChanges();
                rv.IsSuccess = true;
                rv.Message = "Specility Added Successfully";
            }
            catch (Exception ex) 
            {
               rv.IsSuccess= false;
                rv.Message = ex.Message;
            }
            return rv;
        }

        public RepoResultVM Delete(long id)
        {
            RepoResultVM rv = new RepoResultVM();
            try
            {
               var v= this.repo.Specilities.Find(id);
                this.repo.Specilities.Remove(v);
                this.repo.SaveChanges();
                rv.IsSuccess = true;
                rv.Message = "Specility Deleted";
            }
            catch(Exception ex)
            {
                rv.IsSuccess= false;
                rv.Message = ex.Message;
            }
            return rv;
        }

        public RepoResultVM Edit(Specility rec)
        {

            RepoResultVM rv = new RepoResultVM();
            try
            {
                this.repo.Entry(rec).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                this.repo.SaveChanges();
                rv.IsSuccess = true;
                rv.Message = "Specility Updated";
            }
            catch (Exception ex) 
            {
                rv.IsSuccess=! false;
                rv.Message = ex.Message;
            }
            return rv;

        }

        public List<Specility> GetAll()
        {
            return this.repo.Specilities.ToList();
        }

        public Specility GetByID(long id)
        {
            return this.repo.Specilities.Find(id);
        }
    }
}
