using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    [Table("BookedAppPaymentTbl")]
    public class BookedAppPayment
    {
        [Key ]
        public Int64 BookedAppointmentPaymentID {  get; set; }
        [Required(ErrorMessage ="Amount Required")]
        public decimal Amount {  get; set; }
        [Required(ErrorMessage = "PaymentMode Required")]
        public int PaymentMode {  get; set; }
        [ForeignKey("BookedAppointment")]
        public Int64 BookedAppointmentID {  get; set; }
        public virtual BookedAppointment BookedAppointment { get; set; }
    }
}
