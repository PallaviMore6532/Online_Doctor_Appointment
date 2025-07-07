using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    [Table("ClinicRatingTbl")]
    public  class ClinicRating
    {
        [Key]
        public Int64 ClinicRatingID {  get; set; }
        [Required(ErrorMessage ="Clinic Rating required")]
        public int Rating { get; set; }

        public string Remark {  get; set; }
        [ForeignKey("User")]
        public Int64 UserID {  get; set; }
        public virtual User User { get; set; }  
        [ForeignKey("Clinic")]
        public Int64 ClinicID {  get; set; }
        public virtual Clinic Clinic { get; set; }
    }
}
