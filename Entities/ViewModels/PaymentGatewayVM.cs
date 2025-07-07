using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModels
{
    public class PaymentGatewayVM
    {
        public string CardNo { get; set; }
        public string ExpiryDate { get; set; }
        public string CVVCode { get; set; }
    }
}
