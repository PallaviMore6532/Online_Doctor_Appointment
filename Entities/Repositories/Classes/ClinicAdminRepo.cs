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
	public class ClinicAdminRepo : IClinicAdminRepo
	{
		TimeContext cntx;
		public ClinicAdminRepo(TimeContext cntx)
		{
			this.cntx = cntx;
		}

        public RepoResultVM ChangePassword(ChangePasswordVM rec, long ClinicAdminID)
        {
            RepoResultVM rv = new RepoResultVM();
            var v = this.cntx.ClinicsAdmins.Find(ClinicAdminID);
            if (v.Password == rec.OldPassword)
            {
                try
                {
                    v.Password = rec.NewPassword;
                    this.cntx.SaveChanges();
                    rv.IsSuccess = true;
                    rv.Message = " clinic Password Changed Successfully";
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

        public RepoResultVM EditProfile(EditProfileVM rec, long id)
        {
            RepoResultVM rv=new RepoResultVM();

            try
            {
                var oldrec = this.cntx.ClinicsAdmins.Find(id);
                oldrec.FirstName = rec.FirstName;
                oldrec.LastName = rec.LastName;
                oldrec.MobileNo = rec.MobileNo;
                this.cntx.SaveChanges();
                rv.IsSuccess = true;
                rv.Message = "Profile Updated";
            }
            catch (Exception ex) 
            
            {
                rv.IsSuccess= false;
                rv.Message = ex.Message.ToString();
            }
            return rv;
        }

        public EditProfileVM GetForEditProfile(long id)
        {
            var rec = from t in this.cntx.ClinicsAdmins
                      where t.ClinicAdminID == id
                      select new EditProfileVM
                      {
                          FirstName = t.FirstName,
                          LastName = t.LastName,
                          MobileNo = t.MobileNo,

                      };
            return rec.SingleOrDefault();
        }

        public LoginResultVM SignIn(LoginVM rec)
		{
			LoginResultVM log = new LoginResultVM();
			var v = this.cntx.ClinicsAdmins.SingleOrDefault(p => p.EmailID == rec.EmailID && p.Password == rec.Password);

			if (v != null)
			{
				log.IsSuccess = true;
				log.LoggedInID = v.ClinicAdminID;
				log.LoggedInName = v.FullName;
                log.ClinicID = v.ClinicID;



			}
			else
			{
				log.IsSuccess = false;
				log.ErrorMessage = "Invalid Email ID or Password";
			}
			return log;
		}

        public RepoResultVM SignUp(ClinicAdminCompoVM rec)
        {
            RepoResultVM rv=new RepoResultVM();
            try
            {
                

                ClinicAdmin ca = new ClinicAdmin();
                ca.FirstName = rec.FirstName;
                ca.LastName = rec.LastName;
                ca.EmailID = rec.AdminEmailID;
                ca.MobileNo = rec.AdminMobileNo;
                ca.Password = rec.Password;
              
                
                //this.cntx.ClinicsAdmins.Add(ca);
                //this.cntx.SaveChanges();

                Clinic c = new Clinic();
                c.ClinicName = rec.ClinicName;
                c.Address = rec.Address;
                c.MobileNO = rec.MobileNO;
                c.EmailID = rec.EmailID;
                c.ContactPersonName = rec.ContactPersonName;
                c.LandLineNO = rec.LandLineNO;
                c.WebsiteUrl = rec.WebsiteUrl;
                c.CityID = rec.CityID;
                c.Logopath = rec.Logopath;
                c.Photo = rec.Photo;
                c.RegisterDate = rec.RegisterDate;
                c.ClinicID = ca.ClinicID;
                c.clinicAdmins.Add(ca);
                this.cntx.Clinics.Add(c);
                this.cntx.SaveChanges();

                rv.IsSuccess = true;
                rv.Message = "Clinic Admin Register successfully";
            }
            catch (Exception ex) 
            {
                rv.IsSuccess= false;
                rv.Message = ex.Message;
            
            }
            return rv;
        }
    }
}
