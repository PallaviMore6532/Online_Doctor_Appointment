using Core;
using Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Repositories.Interfaces
{
    public interface IClinicFacilityRepo
    {
        List<ClinicFacility>GetAll();
        List<ClinicFacility> GetAllById(Int64 clinicid);
        ClinicFacility GetById(Int64  id);

        RepoResultVM Add(ClinicFacility rec);
        RepoResultVM Edit(ClinicFacility rec);

        RepoResultVM Delete(Int64 id);

      
       
    }
}
