using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    [Table("PrescriptionDetailTbl")]
    public class PrescriptionDetail
    {
        [Key]
        public Int64 PrescriptionDetailID {  get; set; }
        public Int64 Qty {  get; set; }
        public Int64 Dosage { get; set; }
        public string Duration {  get; set; }
        public string Remark { get; set; }
        [ForeignKey("Prescription")]
        public Int64 PrescriptionID {  get; set; }
        public virtual Prescription Prescription { get; set; }
        [ForeignKey("Medicine")]
        public Int64 MedicineID {  get; set; }
        public virtual Medicine Medicine { get; set; }
    }
}
