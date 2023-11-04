using Microsoft.AspNetCore.Mvc;
using RajaTestA.DomainEntities.Entities;
using RajaTestA.Models.ViewModels;
using RajaTestA.Services.Services.Interfaces;
using RajaTestA.WebApi.DTOs;

namespace RajaTestA.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CertificateController : ControllerBase
    {
        private readonly ICertificateService _certificateService;
        public CertificateController(ICertificateService certificateService)
        {
            _certificateService = certificateService;
        }

        [HttpGet]
        public List<CertificateDTO> GetAll()
        {
            //return _certificateService.GetAllCertificate();
            var certificates = _certificateService.GetAllCertificate();
            return CertificateDTO.From(certificates);
        }

        [HttpGet]
        public CertificateDTO GetById(int id)
        {
            //return _certificateService.GetCertificateById(id);
            var certificate = _certificateService.GetCertificateById(id);
            return CertificateDTO.From(certificate);
        }

        [HttpPost]
        public CertificateDTO Create(CertificateDTO certificateDTO)
        {
            //return _certificateService.InsertCertificate(certificateDTO);
            var certificate = CertificateDTO.To(certificateDTO);
            certificate = _certificateService.InsertCertificate(certificate);
            return CertificateDTO.From(certificate);
        }

        [HttpPut]
        public bool Edit(CertificateDTO certificateDTO)
        {
            //return _certificateService.UpdateCertificate(certificateDTO);
            var certificate = CertificateDTO.To(certificateDTO);
            return _certificateService.UpdateCertificate(certificate);
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            return _certificateService.DeleteCertificate(id);
        }
    }
}
