using Core;
using Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Repositories.Interfaces
{
    public interface IDoctorRatingRepo
    {
      //  DoctorRating getbyDoctoranduserID(Int64 doctorID,Int64 UserID);

        List<DoctorRating> GetAll();

        RepoResultVM Add(DoctorRating rec);

        List<DoctorRating> GetbyClinicid(Int64 clinicID,Int64 DoctorID);
    }
}
