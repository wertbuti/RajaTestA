using RajaTestA.DataLayer.AppContext;
using RajaTestA.DomainEntities.Entities;
using RajaTestA.Models.ViewModels;
using RajaTestA.Services.BaseServices;
using RajaTestA.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RajaTestA.Services.Services
{
    public class CertificateService : BaseServiceOne<Certificate,int> ,ICertificateService
    {
        public CertificateService(IRajaDbContext rajaDbContext) : base(rajaDbContext)
        {
        }
        public List<Certificate> GetAllCertificate()
        {
            //return Certificate.MapperConfig().CreateMapper().ProjectTo<Certificate>(GetAll()).ToList();
            return GetAll().ToList();
        }

        public Certificate GetCertificateById(int id)
        {
          //return Certificate.MapperConfig().CreateMapper().Map<Certificate,Certificate>(GettById(id).FirstOrDefault());
          return GettById(id).FirstOrDefault();
        }

        public Certificate InsertCertificate(Certificate certificate)
        {
            //var certificate = Certificate.MapperConfig().CreateMapper().Map<Certificate,Certificate>(certificate);
            Insert(certificate);
            //return Certificate.MapperConfig().CreateMapper().Map<Certificate, Certificate>(certificate);
            return certificate;
        }

        public bool UpdateCertificate(Certificate certificate)
        {
            //var certificate = Certificate.MapperConfig().CreateMapper().Map<Certificate, Certificate>(certificate);
            return Update(certificate);
        }
        public bool DeleteCertificate(int id)
        {
            return Delete(id);
        }
    }
}
