using AutoMapper;
using RajaTestA.DomainEntities.Entities;
using System.ComponentModel.DataAnnotations;

namespace RajaTestA.WebApi.DTOs
{
    public class PersonnelDTO
    {
        [Display(Name = "شناسه")]
        public int Id { get; set; }


        [Display(Name = "نام")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} را وارد نمایید")]
        [MaxLength(100, ErrorMessage = "{0} نمیتواند بیشتر از {1} کاراکتر باشد")]
        public string FirstName { get; set; }

        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = "{0} را وارد نمایید")]
        [MinLength(3, ErrorMessage = "{0} نمیتواند کمتر از {1} کاراکتر باشد")]
        public string LastName { get; set; }

        [Display(Name = "سن")]
        [Required(ErrorMessage = "{0} را وارد نمایید")]
        public int Age { get; set; }

        [Display(Name = "موبایل")]
        [Required(ErrorMessage = "{0} را وارد نمایید")]
        [RegularExpression(@"(0|\+98)?([ ]|-|[()]){0,2}9[1|2|3|4]([ ]|-|[()]){0,2}(?:[0-9]([ ]|-|[()]){0,2}){8}", ErrorMessage = "شماره {0} صحیح وارد نمایید")]
        public string Mobile { get; set; }


        //public virtual ICollection<PersonnelCertificate> PersonnelCertificates { get; set; } = null!;

       

        #region map
        public static Personnel To(PersonnelDTO source)
        {
            return MapperConfig().CreateMapper().Map<PersonnelDTO, Personnel>(source);
        }
        public static List<Personnel> To(List<PersonnelDTO> sources)
        {
            List<Personnel> result = new List<Personnel>();
            for (int i = 0; i < sources.Count; i++)
                result.Add(MapperConfig().CreateMapper().Map<PersonnelDTO, Personnel>(sources[i]));

            return result;
        }

        public static PersonnelDTO From(Personnel source)
        {
            return MapperConfig().CreateMapper().Map<Personnel, PersonnelDTO>(source);
        }
        public static List<PersonnelDTO> From(List<Personnel> sources)
        {
            List<PersonnelDTO> result = new List<PersonnelDTO>();
            for (int i = 0; i < sources.Count; i++)
                result.Add(MapperConfig().CreateMapper().Map<Personnel, PersonnelDTO>(sources[i]));

            return result;
        }

        public static MapperConfiguration MapperConfig()
        {
            var mapperConfig = new MapperConfiguration(conf =>
            {
                conf.CreateMap<Personnel, PersonnelDTO>().ReverseMap();
                //.ForMember(p => p.CreatorUserId, p => p.MapFrom(q => q.CreatorUserId))
                //.ForMember(p => p.Age, p => p.MapFrom(q => q.Age));
            });
            return mapperConfig;
        }

        #endregion
    }
}
