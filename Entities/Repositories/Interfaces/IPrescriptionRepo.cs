using Core;
using Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Repositories.Interfaces
{
	public interface IPrescriptionRepo
	{
		RepoResultVM Add(Prescription rec, Int64[] MedicineID, Int64[] Qty, Int64[] Dosage, string[] Duration, string[] Remark);
	  PrescriptionDetail getprescriptionbyappid(Int64 pid);

		List<PrescriptionDetail> getbyid(Int64 pid);

		RepoResultVM Edit(PrescriptionDetail rec);

		Prescription getbyprescriptionid(Int64 pid);



	}
}
