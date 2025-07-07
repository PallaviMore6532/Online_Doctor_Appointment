using Core;
using Entities.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Repositories.Classes
{
    public class DoctorSpecilitiesrepo : IdoctorSpecialitiesRepo
    {
        TimeContext repo;
        public DoctorSpecilitiesrepo(TimeContext repo) 
        {
            this.repo = repo;
        }
        public List<DoctorSpeciality> GetAll()
        {
           return this.repo.DoctorSpecialities.ToList();
        }

        public List<DoctorSpeciality> getdocbyclinicnew(long clinicID)
        {
            var v = this.repo.DoctorSpecialities.Where(d => d.Doctor.ClinicID == clinicID);
            return v.ToList();
        }

        public DoctorSpeciality GetDoctorSpecialitydoctorid(long doctorid)
        {
            return this.repo.DoctorSpecialities.FirstOrDefault(d=>d.DoctorID==doctorid);
        }

     
    }
}
