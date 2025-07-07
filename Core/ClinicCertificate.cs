using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    [Table("ClinicCertificateTbl")]
    public class ClinicCertificate
    {
        [Key]
        public Int64 ClinicCertificateID {  get; set; }
        [ForeignKey("Clinic")]
        public Int64 ClinicID {  get; set; }
        public virtual Clinic Clinic { get; set; }

        public string CertificateName {  get; set; }
        public DateTime CertificateDate { get; set; }
        public string FilePath {  get; set; }


    }
}
