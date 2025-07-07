using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModels
{
	public class BookVM
	{
		public bool IsSuccess {  get; set; }
		public string Message {  get; set; }
		
		public Int64 PatientID {  get; set; }
		public DateTime AppointmentDate { get; set; }
		public decimal Amount { get; set; }

		public string StartTime {  get; set; }
		public string EndTime {  get; set; }

	

	}
}
