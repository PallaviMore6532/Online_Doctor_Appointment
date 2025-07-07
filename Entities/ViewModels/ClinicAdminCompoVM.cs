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
    public class ClinicAdminCompoVM
    {
        [Required(ErrorMessage = "ClinicName is Required")]
        public string ClinicName { get; set; }
        [Required(ErrorMessage = "Address is Required")]
        public string Address { get; set; }
        [Required(ErrorMessage = "EmailID is Required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]

        public string EmailID { get; set; }
        [Required(ErrorMessage = "MobileNo is Required")]
        public string MobileNO { get; set; }
        [Required(ErrorMessage = "Contact Person name is Required")]
        public string ContactPersonName { get; set; }
        [Required(ErrorMessage = "RegisterDate is Required")]
        public DateTime RegisterDate { get; set; }
        [Required(ErrorMessage = "LandLineNo is Required")]
        public string LandLineNO { get; set; }
        [Required(ErrorMessage = "Websiteurl is Required")]
        public string WebsiteUrl { get; set; }
        
        public Int64 CityID { get; set; }

        [NotMapped]
        public IFormFile Photo { get; set; }

        public string Logopath { get; set; }

        //ClinicAdmin======

        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is Required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "EmailID is Required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string AdminEmailID { get; set; }
        [Required(ErrorMessage = "MobileNo is Required")]
        public string AdminMobileNo { get; set; }
        [Required(ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password Required!!!")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and Conform Password are not same!!")]
        public string ConformPassword { get; set; }
    }
}
