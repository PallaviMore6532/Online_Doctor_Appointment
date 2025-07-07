using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
	[Table("ClinicTbl")]
	public class Clinic
	{
		[Key]
		public Int64 ClinicID {  get; set; }
		[Required(ErrorMessage ="Clinic Name is Required")]
		public string ClinicName { get; set; }
		[Required(ErrorMessage = "Address is Required")]
		public string Address {  get; set; }
		[Required(ErrorMessage = "EmailID is Required")]
		[EmailAddress(ErrorMessage = "Invalid Email Address")]

		public string EmailID {  get; set; }
		[Required(ErrorMessage = "MobileNo is Required")]
		public string MobileNO {  get; set; }
		[Required(ErrorMessage = "Contact Person name is Required")]
		public string ContactPersonName {  get; set; }
		[Required(ErrorMessage = "RegisterDate is Required")]
		public DateTime RegisterDate { get; set; }
        [Required(ErrorMessage = "LandLineNo is Required")]
        public string LandLineNO {  get; set; }
        [Required(ErrorMessage = "Websiteurl is Required")]
        public string WebsiteUrl {  get; set; }

		public string Logopath {  get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
        [ForeignKey("City")]
		public Int64 CityID {  get; set; }
		public virtual City City { get; set; }

		public virtual List<ClinicAdmin> clinicAdmins { get; set; }
		public virtual List<OPDSession> OPDSessions { get; set; }

		public virtual List<ClinicFacility> ClinicFacilities { get; set; }

		public virtual List<ClinicRating> ClinicRatings { get; set; }

		public virtual List<DoctorClinicSession> DoctorClinicSessions { get; set; }

		public virtual List<ClinicCertificate> ClinicCertificates { get; set; }

		public virtual List<Doctor> Doctors { get; set; }

		
		public Clinic()
		{
			this.clinicAdmins = new List<ClinicAdmin>();
			this.ClinicRatings = new List<ClinicRating>();
		}

	}
}
