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
    public class ClinicCertificateRepo : IClinicCertificateRepo
    {
        TimeContext repo;
        public ClinicCertificateRepo(TimeContext repo) 
        {
          this.repo = repo;
        }
        public RepoResultVM Add(ClinicCertificate rec)
        {
            RepoResultVM rv= new RepoResultVM();
            try
            {
                this.repo.ClinicCertificates.Add(rec);
                this.repo.SaveChanges();
                rv.IsSuccess = true;
                rv.Message = "Clinic Certificate add successfully";
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
            RepoResultVM rv= new RepoResultVM();
            try
            {
                var v = this.repo.ClinicCertificates.Find(id);
                this.repo.ClinicCertificates.Remove(v);
                this.repo.SaveChanges();
                rv.IsSuccess = true;
                rv.Message = "Clinic Certificate Deleted";
            }
            catch (Exception ex)
            { 
                rv.IsSuccess=! false;
                rv.Message = ex.Message;
            }
            return rv;
        }

        public List<ClinicCertificate> GetAll()
        {
            return this.repo.ClinicCertificates.ToList();
        }

        public ClinicCertificate GetById(long id)
        {
            return this.repo.ClinicCertificates.Find(id);
        }

        public RepoResultVM Edit(ClinicCertificate rec)
        {
            RepoResultVM rv=new RepoResultVM();
            try
            {
                this.repo.Entry(rec).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                this.repo.SaveChanges();
                rv.IsSuccess = true;
                rv.Message = "Clinic Certificate Updated..............";
            }
            catch (Exception ex) 
            {
               rv.IsSuccess= false;
                rv.Message = ex.Message;
            }
            return rv;
        }

        public List<ClinicCertificate> GetAllById(long clinicid)
        {
            return this.repo.ClinicCertificates.Where(p => p.ClinicID == clinicid).ToList();
        }
    }
}
