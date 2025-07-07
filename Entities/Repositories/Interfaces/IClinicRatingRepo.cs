using Core;
using Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Repositories.Interfaces
{
    public interface IClinicRatingRepo
    {
        List<ClinicRating>GetAll();

        List<ClinicRating> GetAllById(Int64 clinicid);
        ClinicRating GetById(Int64  id);

        RepoResultVM Add(ClinicRating rec);
        RepoResultVM Edit(ClinicRating  rec);

        RepoResultVM Delete(Int64 id);

        ClinicRating ratingbyclinicid(Int64 id);

      //  RepoResultVM ratingbyclinic(Int64 id);

        List<ClinicRating> GetByClinicID(Int64 id);

      
       
    }
}
