using Core;
using Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Repositories.Interfaces
{
    public interface ICountryRepo
    {
        List<Country>GetAll();
        Country GetById(Int64  id);

        RepoResultVM Add(Country rec);
        RepoResultVM Edit(Country rec);

        RepoResultVM Delete(Int64 id);

      
       
    }
}
