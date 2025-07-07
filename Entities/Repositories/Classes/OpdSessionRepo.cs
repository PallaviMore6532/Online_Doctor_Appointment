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
	public class OpdSessionRepo : IOpdSessionRepo
	{
		TimeContext repo;
		public OpdSessionRepo(TimeContext repo)
		{
			this.repo = repo;
		}

		public RepoResultVM Add(OPDSession rec)
		{
			RepoResultVM vm = new RepoResultVM();

			try
			{
				this.repo.OPDSessions.Add(rec);
				this.repo.SaveChanges();
				vm.IsSuccess = true;
				vm.Message = "OpdSession updated Successfully";
			}
			catch (Exception ex) 
			{ 
			    vm.IsSuccess= false;
				vm.Message = ex.Message;
			}
			return vm;

		}

		public RepoResultVM Delete(long id)
		{
			RepoResultVM rv = new RepoResultVM();
			try
			{
				var rec = this.repo.OPDSessions.Find(id);
				this.repo.OPDSessions.Remove(rec);
				this.repo.SaveChanges();
				rv.IsSuccess = true;
				rv.Message = "OpD Session Deleted";
			}
			catch (Exception ex)
			{
				rv.IsSuccess = false;
				rv.Message = ex.Message;
			}
			return rv;
		}

		public RepoResultVM Edit(OPDSession rec)
		{
			RepoResultVM rv = new RepoResultVM();
			try
			{
				this.repo.Entry(rec).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
				this.repo.SaveChanges();
				rv.IsSuccess = true;
				rv.Message = "opd session Updated !...";
			}
			catch (Exception ex)
			{
				rv.IsSuccess = false;
				rv.Message = ex.Message;

			}
			return rv;
		}

		public List<OPDSession> GetAll()
		{
			return this.repo.OPDSessions.ToList();
		}

        public List<OPDSession> GetAllById(long clinicid)
        {
           return this.repo.OPDSessions.Where(d=>d.ClinicID==clinicid).ToList();
        }

        public OPDSession GetById(long id)
		{
			return this.repo.OPDSessions.Find(id);
		}
	}
}
