using Core;
using Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Repositories.Interfaces
{
    public  interface IDoctorScheduleRepo
    {
        List<DoctorSpeciality> GetAll();

        List<DoctorSpeciality> GetAllById(Int64 clinicid);
        RepoResultVM Add(DoctorSchedule rec);

        //RepoResultVM Edit(DoctorSchedule rec);

        DoctorSchedule getdoctorschedulebydoctorid(Int64 doctorid);

        void EditSave(DoctorSchedule rec);

        RepoResultVM Delete(Int64 id);

        DoctorSchedule Getbyid(Int64 id);

        List<DoctorSchedule> doctorschedulebydoctorid(long doctorid);

        DoctorSchedule getbyDoctorscheduleid(Int64 DoctorScheduleid);






    }
}
