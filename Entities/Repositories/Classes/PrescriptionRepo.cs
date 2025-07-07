using Core;
using Entities.Repositories.Interfaces;
using Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Repositories.Classes
{
	public class PrescriptionRepo : IPrescriptionRepo
	{
		TimeContext repo;
		public PrescriptionRepo(TimeContext repo) 
		{
		
		  this.repo = repo;
		}
		public RepoResultVM Add(Prescription rec, long[] MedicineID, long[] Qty, long[] Dosage, string[] Duration, string[] Remark)
		{
			RepoResultVM rv=new RepoResultVM();

			try
			{
				for(int i=0;i<8;i++)
				{
					PrescriptionDetail p = new PrescriptionDetail();
					p.MedicineID = MedicineID[i];
					p.Qty = Qty[i];
					p.Dosage = Dosage[i];
					p.Duration = Duration[i];
					p.Remark = Remark[i];
					rec.PrescriptionDetail.Add(p);
				}

				this.repo.Prescriptions.Add(rec);
				this.repo.SaveChanges();

				rv.IsSuccess = true;
				rv.Message = "Prescription Added";
			}
			catch (Exception ex) 
			{ 
			     rv.IsSuccess = false;
				rv.Message = ex.Message;
			}
			return rv;
		}

		public RepoResultVM Edit(PrescriptionDetail rec)
		{
			RepoResultVM rv = new RepoResultVM();
			try
			{
				this.repo.Entry(rec).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
				this.repo.SaveChanges();
				rv.IsSuccess = true;
				rv.Message = "Prescription Detail Updated Updated !...";
			}
			catch (Exception ex)
			{
				rv.IsSuccess = false;
				rv.Message = ex.Message;

			}
			return rv;
		}

		
		public List<PrescriptionDetail> getbyid(long pid)
		{
			return this.repo.PrescriptionsDetail.Where(d => d.Prescription.PatientID == pid).ToList();



		}

		public Prescription getbyprescriptionid(long pid)
		{
			return this.repo.Prescriptions.FirstOrDefault(d => d.PrescriptionID == pid);
		}

		public PrescriptionDetail getprescriptionbyappid(long pid)
		{
			//return this.repo.PrescriptionsDetail.FirstOrDefault(d => d.Prescription.BookedAppointmentID == appid);
			//return this.repo.PrescriptionsDetail.Where(d => d.MedicineID==mid).FirstOrDefault();
			return this.repo.PrescriptionsDetail.Find(pid);
		}
	}
}
