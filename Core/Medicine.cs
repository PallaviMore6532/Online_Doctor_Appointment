using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    [Table("MedicineTbl")]
    public class Medicine
    {
        [Key]
        public Int64 MedicineID {  get; set; }
        public string MedicineName { get; set; }
        public string MfgName {  get; set; }
        public DateTime ExpDate { get; set; }
        public DateTime MfgDate { get; set; }
        public decimal Price {  get; set; }
      

        public virtual List<PrescriptionDetail> PrescriptionDetails { get; set;}

    }
}
