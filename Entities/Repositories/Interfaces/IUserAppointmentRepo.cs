using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Repositories.Interfaces
{
    public interface IUserAppointmentRepo
    {
        public List<Patient> TodayUserBook(Int64 UserID);

        public List<Patient> TommorrowUserBook(Int64 UserID);

        public List<Patient> dayaftertomorrowBook(Int64 Uid);

    }
}
