using Core;
using Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Repositories.Interfaces
{
    public interface IDoctorRepo
    {
        LoginResultVM SignIn(LoginDrVM rec);
        List<Doctor> GetAll();

        List<Doctor> GetAllById(Int64 clinicid);

        List<Doctor> getdocbyclinic(Int64 clinicID);

        Doctor getbyDoctorid(Int64 DoctorID);

        RepoResultVM ChangePassword(ChangePasswordVM rec, Int64 DoctorID);




    }
}
