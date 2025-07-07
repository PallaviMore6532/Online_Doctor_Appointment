using Core;
using Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Repositories.Interfaces
{
    public interface IPatientinfo
    {
        RepoResultVM Patientinfo(Patient rec);

        Patient getbyPatientID(Int64 PatientID);

		RepoResultVM Edit(Patient rec);


		List<Patient> getbyUserID(Int64 uid);

       
    }
}
