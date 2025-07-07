using Core;
using Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Repositories.Interfaces
{
    public interface IClinicCertificateRepo
    {
        List<ClinicCertificate> GetAll();

        List<ClinicCertificate> GetAllById(Int64 clinicid);
        ClinicCertificate GetById(Int64 id);

        RepoResultVM Add(ClinicCertificate rec);
        RepoResultVM Edit(ClinicCertificate rec);
        RepoResultVM Delete(Int64 id);

    }
}
