using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Repositories.Interfaces
{
    public interface ITimeRepo
    {
      

        public List<BookedAppointment> TodayBookDoctor(Int64 did);

        public List<BookedAppointment> TommorrowBookDoctor(Int64 did);

        public List<BookedAppointment> dayaftertomorrowBookDoctor(Int64 did);

    }
}
