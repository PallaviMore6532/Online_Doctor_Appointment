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
    public class MedicineRepo : IMedicineRepo
    {
        TimeContext repo;
        public MedicineRepo(TimeContext repo)
        {
            this.repo = repo;
        }

        public RepoResultVM Add(Medicine rec)
        {
           RepoResultVM rv=new RepoResultVM();

            try
            {
                this.repo.Medicines.Add(rec);
                this.repo.SaveChanges();
                rv.IsSuccess = true;
                rv.Message = "Medicine Added Successfully";
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
                var v = this.repo.Medicines.Find(id);
                this.repo.Medicines.Remove(v);
                this.repo.SaveChanges();
                rv.IsSuccess = true;
                rv.Message = "Medicine Deleted Successfully";
            }
            catch (Exception ex)
            
            { 
                rv.IsSuccess=! false;
                rv.Message = ex.Message;
            
            }
            return rv;
        }

        public RepoResultVM Edit(Medicine rec)
        {
            RepoResultVM rv = new RepoResultVM();

            try
            {
                this.repo.Entry(rec).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                this.repo.SaveChanges();
                rv.IsSuccess = true;
                rv.Message = "Medicine Edited";
            }
            catch (Exception ex) 
            {
                rv.IsSuccess = false;
                rv.Message = ex.Message;
            
            }
            return rv;
        }

        public List<Medicine> GetAll()
        {
            return this.repo.Medicines.ToList();
        }

        public List<Medicine> GetAllById(long clinicid)
        {
            throw new NotImplementedException();
        }

        public Medicine GetByid(long id)
        {
            return this.repo.Medicines.Find(id);
        }
    }
}
