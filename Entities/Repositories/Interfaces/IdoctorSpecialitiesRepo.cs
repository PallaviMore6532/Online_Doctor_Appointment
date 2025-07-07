using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Repositories.Interfaces
{
    public interface IdoctorSpecialitiesRepo
    {
        List<DoctorSpeciality> GetAll();
        DoctorSpeciality GetDoctorSpecialitydoctorid(Int64 doctorid);

        List<DoctorSpeciality> getdocbyclinicnew(Int64 clinicID);


    }
}
