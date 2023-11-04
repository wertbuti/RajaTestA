using Microsoft.EntityFrameworkCore;
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
    public class PersonnelCertificateService : BaseServiceOne<PersonnelCertificate,int> ,IPersonnelCertificateService
    {
        public PersonnelCertificateService(IRajaDbContext rajaDbContext) : base(rajaDbContext)
        {
        }
        public List<PersonnelCertificate> GetAllPersonnelCertificate()
        {
            //return PersonnelCertificate.MapperConfig().CreateMapper().ProjectTo<PersonnelCertificate>(GetAll()).ToList();
            IQueryable<PersonnelCertificate> query = Table.Include(x => x.Personnel).Include(x => x.Certificate);
            //return GetAll().ToList();
            return query.ToList();
        }

        public PersonnelCertificate GetPersonnelCertificateById(int id)
        {
            IQueryable<PersonnelCertificate> query = Table.Include(x => x.Personnel).Include(x => x.Certificate).Where(e => e.Id.Equals(id));
            //return PersonnelCertificate.MapperConfig().CreateMapper().Map<PersonnelCertificate, PersonnelCertificate>(query.FirstOrDefault());
            return query.FirstOrDefault();
        }
        
        public List<PersonnelCertificate> GetPersonnelCertificateByPersonnelId(int personnelId)
        {
            IQueryable<PersonnelCertificate> query = Table.Include(x => x.Personnel).Include(x => x.Certificate).Where(e => e.PersonnelId.Equals(personnelId));
            //return PersonnelCertificate.MapperConfig().CreateMapper().ProjectTo<PersonnelCertificate>(query).ToList();
            return query.ToList();
        }

        public PersonnelCertificate InsertPersonnelCertificate(PersonnelCertificate personnelCertificate)
        {
            //var personnelCertificate = PersonnelCertificate.MapperConfig().CreateMapper().Map<PersonnelCertificate,PersonnelCertificate>(personnelCertificate);
            Insert(personnelCertificate);
            //return PersonnelCertificate.MapperConfig().CreateMapper().Map<PersonnelCertificate, PersonnelCertificate>(personnelCertificate);
            return personnelCertificate;
        }

        public bool UpdatePersonnelCertificate(PersonnelCertificate personnelCertificate)
        {
            //var personnelCertificate = PersonnelCertificate.MapperConfig().CreateMapper().Map<PersonnelCertificate, PersonnelCertificate>(personnelCertificate);
            return Update(personnelCertificate);
        }
        public bool DeletePersonnelCertificate(int id)
        {
            return Delete(id);
        }
    }
}
