using Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Repositories.Interfaces
{
	public interface IAdminRepo
	{
		LoginResultVM SignIn(LoginVM rec);

		RepoResultVM ChangePassword(ChangePasswordVM rec,Int64 AdminID);

	}
}
