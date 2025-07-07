using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    [Table("DcotorScheduleTbl")]
    public  class DoctorSchedule
    {
        [Key]
        public Int64 DoctorScheduleID {  get; set; }
        public Int64 DayOfWeek {  get; set; }
    
        public string StartTime {  get; set; }
    
        public string EndTime { get; set; }
        public Int64 Interval {  get; set; }
        [ForeignKey("Doctor")]

        public Int64 DoctorID {  get; set; }
        public virtual Doctor Doctor { get; set; }
        [ForeignKey("OpdSession")]

        public Int64 OPDSessionID {  get; set; }
        public virtual OPDSession OpdSession { get; set; }
        public virtual List<BookedAppointment> BookedAppointment { get; set; }
       
        
  
    }
}
