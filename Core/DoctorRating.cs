using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    [Table("DoctorRatingTbl")]
    public class DoctorRating
    {
        [Key]
        public Int64 DoctorRatingID { get; set; }
        [Required(ErrorMessage = "Doctor Rating required")]
        public int Rating { get; set; }
        public string Remark {  get; set; }
		[ForeignKey("User")]
		public Int64 UserID {  get; set; }

        public virtual User User {  get; set; } 
        [ForeignKey("Doctor")]
        public Int64 DoctorID { get; set; }
        public virtual Doctor Doctor { get; set; }
        
    }
}
