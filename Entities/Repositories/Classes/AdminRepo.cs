using Entities.Repositories.Interfaces;
using Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Repositories.Classes
{

	public class AdminRepo : IAdminRepo
	{
		TimeContext cntx;
		public AdminRepo(TimeContext cntx)
		{
			this.cntx = cntx;
		}

        public RepoResultVM ChangePassword(ChangePasswordVM rec, long AdminID)
        {
            RepoResultVM rv = new RepoResultVM();
			var v = this.cntx.Admins.Find(AdminID);
			if(v.Password==rec.OldPassword)
			{
				try
				{
					v.Password = rec.NewPassword;
					this.cntx.SaveChanges();
					rv.IsSuccess = true;
					rv.Message = "Password Changed Successfully";
				}
				catch (Exception ex) 
				{
				    rv.IsSuccess = false;
					rv.Message = ex.Message.ToString();
				}
			}
			else
			{
			   rv.IsSuccess= false;
				rv.Message = "Invalid Old Password";
			}
			return rv;
        }

        public LoginResultVM SignIn(LoginVM rec)
		{
			LoginResultVM log = new LoginResultVM();
			var v=this.cntx.Admins.SingleOrDefault(p=>p.EmailID==rec.EmailID && p.Password==rec.Password );

			if(v != null ) 
			{
				log.IsSuccess = true;
				log.LoggedInID = v.AdminID;
				log.LoggedInName = v.FullName;
			
			
			
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
