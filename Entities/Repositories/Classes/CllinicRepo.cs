using Core;
using Entities.Repositories.Interfaces;
using Entities.ViewModels;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Repositories.Classes
{
    public class CllinicRepo : IClinicRepo
    {
        TimeContext repo;
        public CllinicRepo(TimeContext repo) 
        {
           this.repo = repo;
        }
        public List<Clinic> GetAll()
        {
            return this.repo.Clinics.ToList();
        }

		public Clinic getbyid(long id)
		{
			return this.repo.Clinics.Find(id);
		}

		public List<ClinicInfoVM> GetClinic(long areaID, long specialityID)
        {
            var v = from c in this.repo.Citys
                    join c1 in this.repo.Areas
                    on c.CityID equals c1.CityID
                    join c2 in this.repo.Clinics

                   on c1.AreaID equals c2.ClinicID
                    join c3 in this.repo.Doctors
                    on c2.ClinicID equals c3.ClinicID
                    join c4 in this.repo.DoctorSpecialities
                    on c3.DoctorID equals c4.DoctorID
                    where
                    (c1.AreaID == areaID && c4.SpecilityID == specialityID)
                    select new ClinicInfoVM
                    {
                        clinicID = c2.ClinicID,
                        Address = c2.Address,
                        clinicName = c2.ClinicName

                    };
            return v.ToList();
        }

        public List<Doctor> getdoctorbyclinicid(long clinicID)
        {
            var v = from t in this.repo.Doctors
                    where t.ClinicID == clinicID
                    select t;
                    
            return v.ToList();
        }

        public List<Clinic> GetClinicdetail(long AreaID, long SpecialityID)
        {
            //var v = from v1 in this.repo.Clinics
            //        join v2 in this.repo.Citys
            //        on v1.CityID equals v2.CityID
            //        join v3 in this.repo.Areas
            //        on v2.CityID equals v3.CityID
            //        join v4 in this.repo.Doctors
            //        on v1.ClinicID equals v4.ClinicID
            //        join v5 in this.repo.DoctorSpecialities
            //        on v4.DoctorID equals v5.DoctorID
            //        join v6 in this.repo.Specilities
            //        on v5.SpecilityID equals v6.SpecilityID
            //        join v7 in this.repo.ClinicRatings
            //        on v1.ClinicID equals v7.ClinicID
            //        where v3.AreaID == AreaID && v6.SpecilityID == SpecialityID

            var v = from v1 in this.repo.Citys
                    join v2 in this.repo.Areas
                    on v1.CityID equals v2.CityID
                    join v3 in this.repo.Clinics
                    on v1.CityID equals v3.CityID
                    join v4 in this.repo.Doctors
                    on v3.ClinicID equals v4.ClinicID
                    join v5 in this.repo.DoctorSpecialities
                    on v4.DoctorID equals v5.DoctorID
                    where (v2.AreaID == AreaID && v5.Specility.SpecilityID == SpecialityID)
                    select v3;


            return v.ToList();
        }

        //public List<ClinicInfoVM> getindex()
        //{
        //    var v = from v1 in this.repo.Clinics
        //            join v2 in this.repo.Citys
        //            on v1.CityID equals v2.CityID
        //            join v3 in this.repo.Areas
        //            on v2.CityID equals v3.CityID
        //            join v4 in this.repo.Doctors
        //            on v1.ClinicID equals v4.ClinicID
        //            join v5 in this.repo.DoctorSpecialities
        //            on v4.DoctorID equals v5.DoctorID
        //            join v6 in this.repo.Specilities
        //            on v5.SpecilityID equals v6.SpecilityID
        //            join v7 in this.repo.ClinicRatings
        //            on v1.ClinicID equals v7.ClinicID
        //            select t


        //    return v.ToList();
        //}
    }
}
