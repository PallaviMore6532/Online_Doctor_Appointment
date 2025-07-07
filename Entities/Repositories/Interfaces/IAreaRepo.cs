using Core;
using Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Repositories.Interfaces
{
    public interface IAreaRepo
    {
        List<Area>GetAll();
        Area GetById(Int64  id);

        RepoResultVM Add(Area rec);
        RepoResultVM Edit(Area rec);

        RepoResultVM Delete(Int64 id);

      
       
    }
}
