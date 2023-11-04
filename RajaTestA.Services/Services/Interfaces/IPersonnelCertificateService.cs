using RajaTestA.DomainEntities.Entities;
using RajaTestA.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RajaTestA.Services.Services.Interfaces
{
    public interface IPersonnelCertificateService
    {
        List<PersonnelCertificate> GetAllPersonnelCertificate();
        PersonnelCertificate GetPersonnelCertificateById(int id);

        List<PersonnelCertificate> GetPersonnelCertificateByPersonnelId(int personnelId);
        PersonnelCertificate InsertPersonnelCertificate(PersonnelCertificate personnelCertificate);
        bool UpdatePersonnelCertificate(PersonnelCertificate studdentInsert);
        bool DeletePersonnelCertificate(int id);
    }
}
