using Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Repositories.Interfaces
{
    public interface IUserRepo
    {
        LoginResultVM SignIn(LoginVM rec);
        RepoResultVM signUp(UserSignUpVM rec);

        RepoResultVM EditProfile(EditProfileVM rec, Int64 id);

        EditProfileVM GetForEditProfile(Int64 id);
        RepoResultVM ChangePassword(ChangePasswordVM rec,Int64 UserID);

    }
}
