using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModels
{
	public class PrescriptionVM
	{
		//public string MedicineName {  get; set; }

		//public Int64 Qty { get; set; }
		//public Int64 Dosage { get; set; }
		//public string Duration { get; set; }
		//public string Remark { get; set; }

		public virtual PrescriptionDetail prescriptionDetail { get; set; }

		public virtual List<PrescriptionDetail> prescriptions { get; set; }

		public PrescriptionVM() 
		{
		    this.prescriptionDetail = new PrescriptionDetail();
			this.prescriptions = new List<PrescriptionDetail>();
		}
	}
}
