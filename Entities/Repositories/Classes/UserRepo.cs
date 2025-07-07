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
    public class UserRepo : IUserRepo
    {
        TimeContext repo;
        public UserRepo(TimeContext repo)
        {
            this.repo = repo;
        }

        public RepoResultVM ChangePassword(ChangePasswordVM rec, long UserID)
        {
            RepoResultVM rv = new RepoResultVM();
            var urec = this.repo.Users.Find(UserID);
            if (urec.Password == rec.OldPassword)
            {
                try
                {
                    urec.Password = rec.NewPassword;
                    this.repo.SaveChanges();
                    rv.IsSuccess = true;
                    rv.Message = "Password Change Successfully";
                }
                catch (Exception ex)
                {
                    rv.IsSuccess = false;
                    rv.Message = ex.Message;
                }
               
            }
            return rv;
        }

        public RepoResultVM EditProfile(EditProfileVM rec, long id)
        {
            RepoResultVM res = new RepoResultVM();
            try
            {
                var oldrec = this.repo.Users.Find(id);
                oldrec.Address = rec.Address;
                oldrec.FirstName = rec.FirstName;
                oldrec.LastName = rec.LastName;
                oldrec.MobileNo = rec.MobileNo;
                this.repo.SaveChanges();
                res.IsSuccess = true;
                res.Message = "Profile Updated!";
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.Message = ex.Message.ToString();
            }

            return res;
        }

        public EditProfileVM GetForEditProfile(long id)
        {
            var rec = from t in this.repo.Users
                      where t.UserID == id
                      select new EditProfileVM
                      {
                          FirstName=t.FirstName,
                          LastName=t.LastName,
                          MobileNo=t.MobileNo,
                          Address=t.Address,

                      };
            return rec.FirstOrDefault();
        }

        public LoginResultVM SignIn(LoginVM rec)
        {
            LoginResultVM rv= new LoginResultVM();
            var urec=this.repo.Users.SingleOrDefault(p=>p.EmailID == rec.EmailID && p.Password ==rec.Password);
            if (urec != null) 
            {
                rv.IsSuccess = true;
                rv.LoggedInID = urec.UserID;
                rv.LoggedInName = urec.UserFullName;
            
            }
            else
            {
                rv.IsSuccess = false;
                rv.ErrorMessage = "Invalid EmailID or Password";
               
             

            }

            return rv;

                    
        }

        public RepoResultVM signUp(UserSignUpVM rec)
        {
            RepoResultVM rv =new RepoResultVM();
            try
            {
                User u = new User();
                u.FirstName = rec.FirstName;
                u.LastName = rec.LastName;
                u.EmailID = rec.EmailID;
                u.CountryID = rec.CountryID;
                u.MobileNo = rec.MobileNo;
                u.Address = rec.Address;
                u.Password = rec.Password;
                this.repo.Users.Add(u);
                this.repo.SaveChanges();

                rv.IsSuccess = true;
                rv.Message = "User Register Successfully";
               
            }
            catch (Exception ex)
            {
                rv.IsSuccess = false;
                rv.Message = ex.Message;
               

            }
            return rv;
        }
    }
}
