using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    [Table("UserTbl")]
    public class User
    {
        [Key]
        public Int64 UserID {  get; set; }
        public string FirstName {  get; set; }
        public string LastName { get; set; }
        [NotMapped]
        public string UserFullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
            
        }
        [Required(ErrorMessage ="EmailID Required")]
        [EmailAddress(ErrorMessage ="Invalid EmailID")]
        public string EmailID { get; set; }
        [Required(ErrorMessage = "MobileNo Required")]
        public string MobileNo {  get; set; }
        [Required(ErrorMessage = "Address Required")]
        public string Address {  get; set; }
        [Required(ErrorMessage = "Password Required")]
        [DataType(DataType.Password)]
        public string Password {  get; set; }
        [Required(ErrorMessage = "CountryID Required")]
        [ForeignKey("Country")]
        public Int64 CountryID {  get; set; }
        public virtual Country Country { get; set; }

        public virtual List<Patient> Patients { get; set; }

        public virtual List<ClinicRating> ClinicRatings { get; set; }
		public virtual List<DoctorRating> DoctorRatings { get; set; }








	}
}
