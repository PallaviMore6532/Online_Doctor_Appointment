using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModels
{
    public class ClinicInfoVM
    {
        public Int64 areaID { get; set; }
        public string areaName { get; set; }
        public Int64 clinicID { get; set; }
        public string clinicName { get; set; }
        public Int64 clinicRating { get; set; }
        public string Address { get; set; }
        public string LogoPath { get; set; }
        public Int64 DoctorSpecialityID { get; set; }
        public Int64 Rating { get; set; }

        //public Clinic clinic { get; set; }
        //public City city { get; set; }
        public Doctor Doctor { get; set; }
        //public DoctorSpeciality speciality { get; set; }
        //public ClinicRating rating { get; set; }
        public Int64 doctorName {  get; set; }
        public Int64 DoctorSpeciality {  get; set; }
    }
}
