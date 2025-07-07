using Core;
using Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Repositories.Interfaces
{
    public interface IStateRepo
    {
        List<State>GetAll();
        State GetById(Int64  id);

        RepoResultVM Add(State rec);
        RepoResultVM Edit(State rec);

        RepoResultVM Delete(Int64 id);

      
       
    }
}
