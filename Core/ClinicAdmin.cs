using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
	[Table("ClinicAdminTbl")]
	public class ClinicAdmin
	{
		[Key]
		public Int64 ClinicAdminID {  get; set; }
		[Required(ErrorMessage = "First Name is Required")]
		public string FirstName {  get; set; }
		[Required(ErrorMessage = "Last Name is Required")]
		public string LastName { get; set; }
		[Required(ErrorMessage = "EmailID is Required")]
		[EmailAddress(ErrorMessage ="Invalid Email Address")]

		[NotMapped]
		public string FullName
		{
			get
			{
				return FirstName + "" + LastName;
			}
		}
		public string EmailID {  get; set; }
		[Required(ErrorMessage = "MobileNo is Required")]
		public string MobileNo {  get; set; }
		[Required(ErrorMessage = "Password is Required")]
		public string Password {  get; set; }
		[ForeignKey("Clinic")]
		public Int64 ClinicID {  get; set; }
		public virtual Clinic Clinic { get; set; }
	}
}
