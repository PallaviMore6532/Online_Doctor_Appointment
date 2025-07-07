using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    [Table("AreaTbl")]
    public class Area
    {
        [Key]
        public Int64 AreaID {  get; set; }
        [Required(ErrorMessage ="Area Name is Required")]
        public string AreaName { get; set; }
        [ForeignKey("City")]
        public Int64 CityID {  get; set; }
        public virtual City City { get; set; }
        public virtual List<Doctor> Doctors { get; set; }

    }
}
