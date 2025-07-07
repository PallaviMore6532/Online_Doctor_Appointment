using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    [Table("ClinicFacilityTbl")]
    public class ClinicFacility
    {
        [Key]
        public Int64 ClinicFacilityID {  get; set; }
        [Required(ErrorMessage ="Clinic Facillity name is required")]
        public string ClinicFacilityName { get; set;}
        [ForeignKey("Clinic")]
        public Int64 ClinicID {  get; set; }
        public virtual Clinic Clinic { get; set; }
    }
}
