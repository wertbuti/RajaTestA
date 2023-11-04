using Microsoft.AspNetCore.Mvc;
using RajaTestA.DomainEntities.Entities;
using RajaTestA.Services.Services.Interfaces;
using RajaTestA.WebApi.DTOs;

namespace RajaTestA.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PersonnelController : ControllerBase
    {
        private readonly IPersonnelService _personnelService;
        public PersonnelController(IPersonnelService personnelService)
        {
            _personnelService = personnelService;
        }

        [HttpGet]
        public List<PersonnelDTO> GetAll()
        {
            //return PersonnelDTO.MapperConfig().CreateMapper().ProjectTo<PersonnelDTO>(_personnelService.GetAllPersonnel()).ToList();
            //return _personnelService.GetAllPersonnel();
            var personnels = _personnelService.GetAllPersonnel();
            return PersonnelDTO.From(personnels);
        }

        [HttpGet]
        public PersonnelDTO GetById(int id)
        {
            //return _personnelService.GetPersonnelById(id);
            var personnel = _personnelService.GetPersonnelById(id);
            return PersonnelDTO.From(personnel);
        }

        [HttpPost]
        public PersonnelDTO Create(PersonnelDTO personnelDTO)
        {
            //return _personnelService.InsertPersonnel(personnelDTO);
            var personnel = PersonnelDTO.To(personnelDTO);
            personnel = _personnelService.InsertPersonnel(personnel);
            return PersonnelDTO.From(personnel);
        }

        [HttpPut]
        public bool Edit(PersonnelDTO personnelDTO)
        {
            //return _personnelService.UpdatePersonnel(personnelDTO);
            var personnel = PersonnelDTO.To(personnelDTO);
            return _personnelService.UpdatePersonnel(personnel);
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            return _personnelService.DeletePersonnel(id);
        }
    }
}
