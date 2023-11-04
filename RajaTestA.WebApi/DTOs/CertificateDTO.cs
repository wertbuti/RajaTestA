using AutoMapper;
using RajaTestA.DomainEntities.Entities;
using System.ComponentModel.DataAnnotations;

namespace RajaTestA.WebApi.DTOs
{
    public class CertificateDTO
    {
        [Display(Name = "شناسه")]
        public int Id { get; set; }

        [Display(Name = "نام مدرک")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} را وارد نمایید")]
        [MaxLength(100, ErrorMessage = "{0} نمیتواند بیشتر از {1} کاراکتر باشد")]
        public string Name { get; set; }
        //public virtual ICollection<PersonnelCertificate> PersonnelCertificates { get; set; }

       

        #region map
        public static Certificate To(CertificateDTO source)
        {
            return MapperConfig().CreateMapper().Map<CertificateDTO, Certificate>(source);
        }
        public static List<Certificate> To(List<CertificateDTO> sources)
        {
            List<Certificate> result = new List<Certificate>();
            for (int i = 0; i < sources.Count; i++)
                result.Add(MapperConfig().CreateMapper().Map<CertificateDTO, Certificate>(sources[i]));

            return result;
        }

        public static CertificateDTO From(Certificate source)
        {
            return MapperConfig().CreateMapper().Map<Certificate, CertificateDTO>(source);
        }
        public static List<CertificateDTO> From(List<Certificate> sources)
        {
            List<CertificateDTO> result = new List<CertificateDTO>();
            for (int i = 0; i < sources.Count; i++)
                result.Add(MapperConfig().CreateMapper().Map<Certificate, CertificateDTO>(sources[i]));

            return result;
        }

        public static MapperConfiguration MapperConfig()
        {
            var mapperConfig = new MapperConfiguration(conf =>
            {
                conf.CreateMap<Certificate, CertificateDTO>().ReverseMap();
                //.ForMember(p => p.CreatorUserId, p => p.MapFrom(q => q.CreatorUserId))
                //.ForMember(p => p.Age, p => p.MapFrom(q => q.Age));
            });
            return mapperConfig;
        }

        #endregion
    }
}
