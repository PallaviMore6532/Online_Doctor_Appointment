using Core;
using Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Repositories.Interfaces
{
	public interface IReportRepo
	{
	    List<dailyPatientamtVM> dailyrecord(DailycollectionVM rec);

		List<Patient> Appointmentdaily(DailycollectionVM rec);
	}
}
