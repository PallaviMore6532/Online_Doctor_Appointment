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
    [Table("DoctorTbl")]
    public class Doctor
    {
        [Key]
        public Int64 DoctorID {  get; set; }
        [Required(ErrorMessage ="First Name is required")]
        public string FirstName {  get; set; }
        [Required(ErrorMessage = "last Name is required")]
        public string LastName { get; set; }
        public string MobileNo {  get; set; }
        public bool IsAvailable {  get; set; }
        public string Address {  get; set; }
        public string DoctorExperiance {  get; set; }
        
        public string PhotoPath {  get; set; }
        [NotMapped]
        public IFormFile photo {  get; set; }
        [Required(ErrorMessage = "Doctor Qualification is required")]
        public string DoctorQualification {  get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password {  get; set; }
        [ForeignKey("Area")]
        public Int64 AreaID {  get; set; }
        public virtual Area Area { get; set; }
        [ForeignKey("Clinic")]
        public Int64 ClinicID {  get; set; }
        public virtual Clinic Clinic { get; set; }

        public decimal VisitingCharges {  get; set; }

        public virtual List<DoctorRating> DoctorRatings { get; set; }

        public virtual List<DoctorClinicSession> DoctorClinicSessions { get; set; }

        public virtual List<DoctorSpeciality> DoctorSpecialities { get; set; }

        public virtual List<DoctorSchedule> DoctorSchedules { get; set; }

        public virtual List<Prescription> Prescriptions { get; set; }

        public Doctor()
        {
            this.DoctorSpecialities = new List<DoctorSpeciality>();
        }
    }
}
