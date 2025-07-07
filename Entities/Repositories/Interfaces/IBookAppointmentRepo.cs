using Core;
using Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Repositories.Interfaces
{
	public interface IBookAppointmentRepo
	{
		BookVM appointment(int Pmode,Int64 userid,Int64 dsid,Int64 pid,decimal Amount,DateTime da);

		
	}
}
