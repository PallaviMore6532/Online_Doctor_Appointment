using Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModels
{
    public  class DoctorScheduleVM
    {
        //public Int64 DoctorID {  get; set; }
        //[Required(ErrorMessage ="DoctorName is Required")]
        //public string DoctorName { get; set;}

        //public Int64 DayofWeek {  get; set; }
        //[Required(ErrorMessage = "start date is Required")]

        //[DataType(DataType.Date)]
        //public string StartDate {  get; set; }
        //[Required(ErrorMessage = "EndDate  is Required")]
        //[DataType(DataType.Date)]
        //public string EndDate { get; set; }
        //public Int64 Interval {  get; set; }

        public DoctorSpeciality doctorSpeciality { get; set; }
        public DoctorSchedule doctorSchedule { get; set; }

        public Int64 OPDSessionID {  get; set; }

    }
}
