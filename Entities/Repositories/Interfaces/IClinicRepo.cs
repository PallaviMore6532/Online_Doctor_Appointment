using Core;
using Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Repositories.Interfaces
{
    public interface IClinicRepo
    {
        List<Clinic>GetAll();
        List<ClinicInfoVM> GetClinic(Int64 areaID, Int64 specialityID);
        List<Clinic> GetClinicdetail(Int64 AreaID,Int64 SpecialityID);

        //List<ClinicInfoVM> getindex();

        List<Doctor> getdoctorbyclinicid(Int64 clinicID);

        Clinic getbyid(Int64 id);
      
       
    }
}
