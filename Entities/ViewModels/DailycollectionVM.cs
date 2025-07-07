using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModels
{
	public class DailycollectionVM
	{
		public DateTime FromDate { get; set; }
		public DateTime ToDate { get; set; }

		public Int64 DoctorID {  get; set; }
		public string DoctorName {  get; set; }

	}
}
