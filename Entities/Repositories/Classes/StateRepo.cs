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
    public class StateRepo : IStateRepo
    {
        TimeContext repo;
        public StateRepo(TimeContext repo) 
        {
           this.repo = repo;
        }

        public RepoResultVM Add(State rec)
        {
            RepoResultVM rv = new RepoResultVM();
            try
            {
                this.repo.States.Add(rec);
                this.repo.SaveChanges();
                rv.IsSuccess = true;
                rv.Message = "State Added Successfully";
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
                var rec = this.repo.States.Find(id);
                this.repo.States.Remove(rec);
                this.repo.SaveChanges();
                rv.IsSuccess = true;
                rv.Message = "State Deleted";
            }
            catch (Exception ex)
            {
                rv.IsSuccess = false;
                rv.Message = ex.Message;
            }
            return rv;
        }

        public RepoResultVM Edit(State rec)
        {
            RepoResultVM rv = new RepoResultVM();
            try
            {
                this.repo.Entry(rec).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                this.repo.SaveChanges();
                rv.IsSuccess = true;
                rv.Message = "State Updated !...";
            }
            catch (Exception ex)
            {
                rv.IsSuccess = false;
                rv.Message = ex.Message;

            }
            return rv;
        }

        public List<State> GetAll()
        {
            return this.repo.States.ToList();
        }

        public State GetById(long id)
        {
            return this.repo.States.Find(id);
        }
    }
}
