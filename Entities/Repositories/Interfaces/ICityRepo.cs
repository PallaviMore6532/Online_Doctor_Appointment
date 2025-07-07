using Core;
using Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Repositories.Interfaces
{
    public interface ICityRepo
    {
        List<City>GetAll();
        City GetById(Int64  id);

        RepoResultVM Add(City rec);
        RepoResultVM Edit(City rec);

        RepoResultVM Delete(Int64 id);

      
       
    }
}
