using RajaTestA.DomainEntities.Entities;
using RajaTestA.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RajaTestA.Services.Services.Interfaces
{
    public interface ICertificateService
    {
        List<Certificate> GetAllCertificate();
        Certificate GetCertificateById(int id);
        Certificate InsertCertificate(Certificate certificate);
        bool UpdateCertificate(Certificate studdent);
        bool DeleteCertificate(int id);
    }
}
