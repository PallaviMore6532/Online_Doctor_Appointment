using Core;
using Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Repositories.Interfaces
{
    public interface IMedicineRepo
    {
        List<Medicine> GetAll();

        List<Medicine> GetAllById(Int64 clinicid);

        Medicine GetByid(Int64  id);

        RepoResultVM Add(Medicine rec);

        RepoResultVM Edit(Medicine rec);

        RepoResultVM Delete(Int64 id);
    }
}
