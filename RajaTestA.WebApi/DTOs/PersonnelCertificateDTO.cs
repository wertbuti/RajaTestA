using AutoMapper;
using RajaTestA.DomainEntities.Entities;
using System.ComponentModel.DataAnnotations;

namespace RajaTestA.WebApi.DTOs
{
    public class PersonnelCertificateDTO
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

        public virtual PersonnelDTO Personnel { get; set; }
        public virtual CertificateDTO Certificate { get; set; }

        #region map
        public static PersonnelCertificate To(PersonnelCertificateDTO source)
        {
            return MapperConfig().CreateMapper().Map<PersonnelCertificateDTO, PersonnelCertificate>(source);
        }
        public static List<PersonnelCertificate> To(List<PersonnelCertificateDTO> sources)
        {
            List<PersonnelCertificate> result = new List<PersonnelCertificate>();
            for (int i = 0; i < sources.Count; i++)
                result.Add(MapperConfig().CreateMapper().Map<PersonnelCertificateDTO, PersonnelCertificate>(sources[i]));

            return result;
        }

        public static PersonnelCertificateDTO From(PersonnelCertificate source)
        {
            return MapperConfig().CreateMapper().Map<PersonnelCertificate, PersonnelCertificateDTO>(source);
        }
        public static List<PersonnelCertificateDTO> From(List<PersonnelCertificate> sources)
        {
            List<PersonnelCertificateDTO> result = new List<PersonnelCertificateDTO>();
            for (int i = 0; i < sources.Count; i++)
                result.Add(MapperConfig().CreateMapper().Map<PersonnelCertificate, PersonnelCertificateDTO>(sources[i]));

            return result;
        }

        public static MapperConfiguration MapperConfig()
        {
            var mapperConfig = new MapperConfiguration(conf =>
            {
                conf.CreateMap<PersonnelCertificate, PersonnelCertificateDTO>().ReverseMap();
                conf.CreateMap<Certificate, CertificateDTO>().ReverseMap();
                conf.CreateMap<Personnel, PersonnelDTO>().ReverseMap();
                //.ForMember(p => p.CreatorUserId, p => p.MapFrom(q => q.CreatorUserId))
                //.ForMember(p => p.Age, p => p.MapFrom(q => q.Age));
            });
            return mapperConfig;
        }

        #endregion
    }
}
