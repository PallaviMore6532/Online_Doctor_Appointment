using Core;
using Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Repositories.Interfaces
{
    public interface ISpecilityRepo
    {
        List<Specility> GetAll();
        Specility GetByID(Int64 id);

        RepoResultVM Add(Specility rec);

        RepoResultVM Edit(Specility rec);

        RepoResultVM Delete(Int64 id);

    }
}
