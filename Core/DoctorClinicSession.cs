using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    [Table("DoctorClinicSessionTbl")]
    public class DoctorClinicSession
    {
        [Key]
        public Int64 DoctorClinicSessionID {  get; set; }
        [Required(ErrorMessage ="Start Time is Required")]
       
        public string StartTime {  get; set; }
        [Required(ErrorMessage = "End Time is Required")]
        public string EndTime { get; set; }
        [Required(ErrorMessage = "Time Interval  is Required")]
        public int TimeInterval {  get; set; }
        [ForeignKey("Doctor")]
        public Int64 DoctorID {  get; set; }
        public virtual Doctor Doctor { get; set; }
        [ForeignKey("Clinic")]
        public Int64 ClinicID {  get; set; }
        public virtual Clinic Clinic { get; set; }
        [ForeignKey("OPDSessionID")]
        public Int64 OPDSessionID {  get; set; }
        public virtual OPDSession OPDSession { get; set; }

     

    }
}
