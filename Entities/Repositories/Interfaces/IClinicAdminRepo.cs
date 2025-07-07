using Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Repositories.Interfaces
{
	public interface IClinicAdminRepo
	{
        LoginResultVM SignIn(LoginVM rec);

        RepoResultVM SignUp(ClinicAdminCompoVM rec);
        RepoResultVM ChangePassword(ChangePasswordVM rec, Int64 ClinicAdminID);

        EditProfileVM GetForEditProfile(Int64 id);

        RepoResultVM EditProfile(EditProfileVM rec,Int64 id);
    }
}
