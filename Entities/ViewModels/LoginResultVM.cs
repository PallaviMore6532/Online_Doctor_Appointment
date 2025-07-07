using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModels
{
	public class LoginResultVM
	{
		public bool IsSuccess { get; set; }
		public string ErrorMessage {  get; set; }
		public Int64 LoggedInID {  get; set; }
		public string LoggedInName {  get; set; }
        public Int64? ClinicID { get; set; }

        public decimal VisitingCharges { get; set; }

    }
}
