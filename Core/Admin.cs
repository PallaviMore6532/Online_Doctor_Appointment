using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    [Table("AdminTbl")]
    public class Admin
    {
        
        [Key]
        public Int64 AdminID {  get; set; }
        [Required(ErrorMessage ="First Name is Required")]
        public String FirstName {  get; set; }
        [Required(ErrorMessage = "Last Name is Required")]
        public String LastName { get; set; }

        [NotMapped]
        public string FullName
        {
            get
            {
                return FirstName + "" + LastName;
            }
        }
        [Required(ErrorMessage = "Address is Required")]
        public string Address {  get; set; }
        [Required(ErrorMessage = "Email ID is Required")]
        public string EmailID {  get; set; }
        [Required(ErrorMessage = "Password is Required")]
        public string Password {  get; set; }
    }
}
