using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModels
{
	public class dailyPatientamtVM
	{
		public string PatientName {  get; set; }
		
		public DateTime AppointmentDate { get; set; }
		public decimal Amount {  get; set; }
		public decimal Total {  get; set; }

		public Int64 PatientID {  get; set; }

	}
}
