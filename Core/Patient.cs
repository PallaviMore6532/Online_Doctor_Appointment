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
    [Table("PatientTbl")]
    public  class Patient
    {
        [Key]
        public Int64 PatientID { get; set; }
        [Required(ErrorMessage ="First Name Required")]
        public string FirstName {  get; set; }
        [Required(ErrorMessage = "last Name Required")]
        public string LastName { get; set; }
        public string Address {  get; set; }
        public string MobileNO {  get; set; }
        public string Gender { get; set; }
        public string EmailID {  get; set; }
      
        public string PhotoPath {  get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
        [Required(ErrorMessage = "UserId  Required")]
        [ForeignKey("User")]
        public Int64 UserID {  get; set; }
        public virtual User User { get; set; }

        public DateTime AppointmentDate { get; set; }

        public virtual List<BookedAppointment> BookedAppointments { get; set; }

        public virtual List<Prescription> Prescriptions { get; set; }
    }
}
