using Microsoft.AspNetCore.Mvc;
using RajaTestA.DomainEntities.Entities;
using RajaTestA.Models.ViewModels;
using RajaTestA.Services.Services.Interfaces;
using RajaTestA.WebApi.DTOs;

namespace RajaTestA.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PersonnelCertificateController : ControllerBase
    {
        private readonly IPersonnelCertificateService _personnelCertificateService;
        public PersonnelCertificateController(IPersonnelCertificateService personnelCertificateService)
        {
            _personnelCertificateService = personnelCertificateService;
        }

        [HttpGet]
        public List<PersonnelCertificateDTO> GetAll()
        {
            //return _personnelCertificateService.GetAllPersonnelCertificate();
            var personnelCertificates = _personnelCertificateService.GetAllPersonnelCertificate();
            //return personnelCertificates.ConvertListTo<PersonnelCertificate, PersonnelCertificateDTO>();
            return PersonnelCertificateDTO.From(personnelCertificates);

        }

        [HttpGet]
        public PersonnelCertificateDTO GetById(int id)
        {
            //return _personnelCertificateService.GetPersonnelCertificateById(id);
            var personnelCertificate = _personnelCertificateService.GetPersonnelCertificateById(id);
            //return personnelCertificate.ConvertTo<PersonnelCertificate, PersonnelCertificateDTO>();
            return PersonnelCertificateDTO.From(personnelCertificate);
        }

        [HttpGet]
        public List<PersonnelCertificateDTO> GetByPersonnelId(int personnelId)
        {
            //return _personnelCertificateService.GetPersonnelCertificateByPersonnelId(personnelId);
            var personnelCertificates = _personnelCertificateService.GetPersonnelCertificateByPersonnelId(personnelId);
            //return personnelCertificates.ConvertListTo<PersonnelCertificate, PersonnelCertificateDTO>();
            return PersonnelCertificateDTO.From(personnelCertificates);
        }

        [HttpPost]
        public PersonnelCertificateDTO Create(PersonnelCertificateInsertDTO personnelCertificateInsertDTO)
        {
            //return _personnelCertificateService.InsertPersonnelCertificate(personnelCertificateDTO);
            var personnelCertificate = PersonnelCertificateInsertDTO.To(personnelCertificateInsertDTO);
            personnelCertificate = _personnelCertificateService.InsertPersonnelCertificate(personnelCertificate);
            //return personnelCertificate.ConvertTo<PersonnelCertificate, PersonnelCertificateDTO>();
            return PersonnelCertificateDTO.From(personnelCertificate);
        }

        [HttpPut]
        public bool Edit(PersonnelCertificateInsertDTO personnelCertificateInsertDTO)
        {
            //return _personnelCertificateService.UpdatePersonnelCertificate(personnelCertificateDTO);
            var personnelCertificate = PersonnelCertificateInsertDTO.To(personnelCertificateInsertDTO);
            return _personnelCertificateService.UpdatePersonnelCertificate(personnelCertificate);
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            return _personnelCertificateService.DeletePersonnelCertificate(id);
        }
    }
}
