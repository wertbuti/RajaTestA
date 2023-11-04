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
using Microsoft.EntityFrameworkCore;

namespace RajaTestA.Services.Services
{
    public class PersonnelService : BaseServiceOne<Personnel,int> ,IPersonnelService
    {
        public PersonnelService(IRajaDbContext rajaDbContext) : base(rajaDbContext)
        {
        }
        public List<Personnel> GetAllPersonnel()
        {
          //return Personnel.MapperConfig().CreateMapper().ProjectTo<Personnel>(GetAll()).ToList();
          return GetAll().ToList();
        }

        public Personnel GetPersonnelById(int id)
        {
            //return Personnel.MapperConfig().CreateMapper().Map<Personnel, Personnel>(GettById(id).FirstOrDefault());
            return GettById(id).FirstOrDefault();
        }

        public Personnel InsertPersonnel(Personnel personnel)
        {
            //var personnel = Personnel.MapperConfig().CreateMapper().Map<Personnel,Personnel>(personnel);
            Insert(personnel);
            //return Personnel.MapperConfig().CreateMapper().Map<Personnel, Personnel>(personnel);
            return personnel;
        }

        public bool UpdatePersonnel(Personnel personnel)
        {
            //var personnel = Personnel.MapperConfig().CreateMapper().Map<Personnel, Personnel>(personnel);
            return Update(personnel);
        }
        public bool DeletePersonnel(int id)
        {
            return Delete(id);
        }
    }
}
