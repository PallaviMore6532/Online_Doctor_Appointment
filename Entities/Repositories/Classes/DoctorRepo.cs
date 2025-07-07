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
    public class DoctorRepo : IDoctorRepo
    {
        TimeContext repo;
        public DoctorRepo(TimeContext repo)
        {
           this.repo = repo;
        }

        public RepoResultVM ChangePassword(ChangePasswordVM rec, long DoctorID)
        {
            RepoResultVM rv = new RepoResultVM();
            var v = this.repo.Doctors.Find(DoctorID);
            if (v.Password == rec.OldPassword)
            {
                try
                {
                    v.Password = rec.NewPassword;
                    this.repo.SaveChanges();
                    rv.IsSuccess = true;
                    rv.Message = " doctor Password Changed Successfully";
                }
                catch (Exception ex)
                {
                    rv.IsSuccess = false;
                    rv.Message = ex.Message.ToString();
                }
            }
            else
            {
                rv.IsSuccess = false;
                rv.Message = "Invalid Old Password";
            }
            return rv;
        }

        public List<Doctor> GetAll()
        {
            return this.repo.Doctors.ToList();  
        }

        public List<Doctor> GetAllById(long clinicid)
        {
           return this.repo.Doctors.Where(d=>d.ClinicID == clinicid).ToList();
        }

        public Doctor getbyDoctorid(long DoctorID)
        {
            return this.repo.Doctors.FirstOrDefault(d=>d.DoctorID==DoctorID);
        }

        public List<Doctor> getdocbyclinic(long clinicID)
        {
           // return this.repo.Doctors.SingleOrDefault(d => d.ClinicID == clinicID);
            // return this.repo.Doctors.Where(d => d.ClinicID == clinicID).ToList();
            var v=this.repo.Doctors.Where(d=>d.ClinicID== clinicID);
            return v.ToList();
        }

        public LoginResultVM SignIn(LoginDrVM rec)
        {
            LoginResultVM log = new LoginResultVM();
            var v = this.repo.Doctors.SingleOrDefault(p => p.MobileNo == rec.MobileNO && p.Password == rec.Password);

            if (v != null)
            {
                log.IsSuccess = true;
                log.LoggedInID = v.DoctorID;
                log.LoggedInName = v.FirstName;
                log.VisitingCharges=v.VisitingCharges;



            }
            else
            {
                log.IsSuccess = false;
                log.ErrorMessage = "Invalid Email ID or Password";
            }
            return log;
        }
    }
}
