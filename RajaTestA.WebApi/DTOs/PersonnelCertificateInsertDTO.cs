using AutoMapper;
using RajaTestA.DomainEntities.Entities;
using System.ComponentModel.DataAnnotations;

namespace RajaTestA.WebApi.DTOs
{
    public class PersonnelCertificateInsertDTO
    {
        [Display(Name = "شناسه")]
        public int Id { get; set; }

        [Display(Name = "شناسه پرسنل")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} را وارد نمایید")]
        public int PersonnelId { get; set; }

        [Display(Name = "مدرک")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} را وارد نمایید")]
        [Range(1, double.MaxValue, ErrorMessage = "{0} را وارد نمایید")]
        public int CertificateId { get; set; }

        [Display(Name = "سال اخذ")]
        [Required(ErrorMessage = "{0} را وارد نمایید")]
        [Range(1300, 1500, ErrorMessage = "{0} باید بین {1} و {2} باشد")]
        public int YearCatch { get; set; }

        [Display(Name = "معدل")]
        [Required(ErrorMessage = "{0} را وارد نمایید")]
        public decimal Gpa { get; set; }

        #region map
        public static PersonnelCertificate To(PersonnelCertificateInsertDTO source)
        {
            return MapperConfig().CreateMapper().Map<PersonnelCertificateInsertDTO, PersonnelCertificate>(source);
        }
        public static List<PersonnelCertificate> To(List<PersonnelCertificateInsertDTO> sources)
        {
            List<PersonnelCertificate> result = new List<PersonnelCertificate>();
            for (int i = 0; i < sources.Count; i++)
                result.Add(MapperConfig().CreateMapper().Map<PersonnelCertificateInsertDTO, PersonnelCertificate>(sources[i]));

            return result;
        }

        public static PersonnelCertificateInsertDTO From(PersonnelCertificate source)
        {
            return MapperConfig().CreateMapper().Map<PersonnelCertificate, PersonnelCertificateInsertDTO>(source);
        }
        public static List<PersonnelCertificateInsertDTO> From(List<PersonnelCertificate> sources)
        {
            List<PersonnelCertificateInsertDTO> result = new List<PersonnelCertificateInsertDTO>();
            for (int i = 0; i < sources.Count; i++)
                result.Add(MapperConfig().CreateMapper().Map<PersonnelCertificate, PersonnelCertificateInsertDTO>(sources[i]));

            return result;
        }

        public static MapperConfiguration MapperConfig()
        {
            var mapperConfig = new MapperConfiguration(conf =>
            {
                conf.CreateMap<PersonnelCertificate, PersonnelCertificateInsertDTO>().ReverseMap();
                //.ForMember(p => p.CreatorUserId, p => p.MapFrom(q => q.CreatorUserId))
                //.ForMember(p => p.Age, p => p.MapFrom(q => q.Age));
            });
            return mapperConfig;
        }

        #endregion
    }
}
