using RajaTestA.DomainEntities.Entities;
using RajaTestA.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RajaTestA.Services.Services.Interfaces
{
    public interface IPersonnelService
    {
        List<Personnel> GetAllPersonnel();
        Personnel GetPersonnelById(int id);
        Personnel InsertPersonnel(Personnel personnel);
        bool UpdatePersonnel(Personnel studdentInsert);
        bool DeletePersonnel(int id);
    }
}
