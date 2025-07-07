using Core;
using Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Repositories.Interfaces
{
    public interface IDoctorReportRepo
    {
        List<Patient> TodayPatient(Int64 DID,decimal amt);

        List<BookedAppointment> doctorToday(Int64 DID, decimal amt);
        List<DoctorReportVM> TodayPatients(Int64 DID, decimal amt);

    }
}
