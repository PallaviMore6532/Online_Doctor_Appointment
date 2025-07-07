using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Entities.ViewModels
{
    public class DoctorVm
    {
        public Int64 DoctorID {  get; set; }
		[Required(ErrorMessage = "First Name is required")]
		public string FirstName { get; set; }
        [Required(ErrorMessage = "last Name is required")]
        public string LastName { get; set; }
		[Required(ErrorMessage = "MobileNo is required")]
		public string MobileNo { get; set; }
		[Required(ErrorMessage = "last Name is required")]
        
		public bool IsAvailable { get; set; }=true;
		[Required(ErrorMessage = "Address is required")]
		public string Address { get; set; }
		[Required(ErrorMessage = "Doctor Experiance is required")]
		public string DoctorExperiance { get; set; }
        
        public string PhotoPath { get; set; }
        [NotMapped]
        public IFormFile photo { get; set; }
        [Required(ErrorMessage = "Doctor Qualification is required")]
        public string DoctorQualification { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
       
        public Int64 AreaID { get; set; }

        public string AreaName {  get; set; }

       


        public Int64 ClinicID {  get; set; }
        public string ClinicName {  get; set; }

        public decimal VisitingCharges {  get; set; }

        public int  doctorfacilitycount {  get; set; }

        public List<Int64> dfacility{  get; set; }

        public DoctorVm()
        {
            dfacility = new List<Int64>();
        }



    }
}
