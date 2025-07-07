using Core;
using Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Repositories.Interfaces
{
	public interface IOpdSessionRepo
	{
		List<OPDSession> GetAll();

        List<OPDSession> GetAllById(Int64 clinicid);
        OPDSession GetById(Int64 id);

		RepoResultVM Add(OPDSession rec);
		RepoResultVM Edit(OPDSession rec);

		RepoResultVM Delete(Int64 id);



	}
}
