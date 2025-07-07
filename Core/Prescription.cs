using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    [Table("PrescriptionTbl")]
    public class Prescription
    {
        [Key]
        public Int64 PrescriptionID {  get; set; }
        public DateTime PrescriptionDate { get; set; }
        [ForeignKey("BookedAppointment")]
        public Int64 BookedAppointmentID {  get; set; }
        public virtual BookedAppointment BookedAppointment { get; set; }
        [ForeignKey("Doctor")]
        public Int64 DoctorID {  get; set; }
        public virtual Doctor Doctor { get; set; }
        [ForeignKey("Patient")]
        public Int64 PatientID {  get; set; }
        public virtual Patient Patient { get; set; }

        public virtual List<PrescriptionDetail> PrescriptionDetail { get; set;}

        public Prescription() 
        {
        
          this.PrescriptionDetail = new List<PrescriptionDetail>();
        }
    }
}
