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
    public class AreaRepo : IAreaRepo
    {
        TimeContext repo;
        public AreaRepo(TimeContext repo) 
        {
           this.repo = repo;
        }

        public RepoResultVM Add(Area rec)
        {
            RepoResultVM rv = new RepoResultVM();
            try
            {
                this.repo.Areas.Add(rec);
                this.repo.SaveChanges();
                rv.IsSuccess = true;
                rv.Message = "Area Added Successfully";
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





                var rec = this.repo.Areas.Find(id);
                this.repo.Areas.Remove(rec);
                this.repo.SaveChanges();
                rv.IsSuccess = true;
                rv.Message = "Area Deleted";
            }
            catch (Exception ex)
            {
                rv.IsSuccess = false;
                rv.Message = ex.Message;
            }
            return rv;
        }

        public RepoResultVM Edit(Area rec)
        {
            RepoResultVM rv = new RepoResultVM();
            try
            {
                this.repo.Entry(rec).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                this.repo.SaveChanges();
                rv.IsSuccess = true;
                rv.Message = "Area Updated !...";
            }
            catch (Exception ex)
            {
                rv.IsSuccess = false;
                rv.Message = ex.Message;

            }
            return rv;
        }

        public List<Area> GetAll()
        {
            return this.repo.Areas.ToList();
        }

        public Area GetById(long id)
        {
            return this.repo.Areas.Find(id);
        }
    }
}
