using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    [Table("BookedAppointmentTbl")]
    public class BookedAppointment
    {
        [Key]
        public Int64 BookedAppointmentID {  get; set; }
        [Required(ErrorMessage ="Appointment is Required")]
        public DateTime AppointmentDate { get; set; }
        [Required(ErrorMessage = "Start Time is Required")]
        public string StartTime {  get; set; }
        [Required(ErrorMessage = "End Time is Required")]
        public string EndTime { get; set; }
        [Required(ErrorMessage = "Ispaid is Required")]
        public bool IsPaid {  get; set; }
      
       
       
        [ForeignKey("Patient")]
        public Int64 PatientID {  get; set; }
        public virtual Patient Patient { get; set; }

        [ForeignKey("DoctorSchedule")]
        public Int64 DoctorScheduleID {  get; set; }
        public virtual DoctorSchedule DoctorSchedule { get; set; }

        public virtual List<BookedAppPayment> BookedAppPayments { get; set; }
        public virtual List<Prescription> Prescriptions { get; set; }

    
        
     }
}
