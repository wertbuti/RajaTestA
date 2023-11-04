using AutoMapper;
using RajaTestA.DomainEntities.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RajaTestA.Models.ViewModels
{
    public class CertificateVM : BaseVM<int>
    {
        [Display(Name = "نام مدرک")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} را وارد نمایید")]
        [MaxLength(100, ErrorMessage = "{0} نمیتواند بیشتر از {1} کاراکتر باشد")]
        public string Name { get; set; }
        //public virtual ICollection<PersonnelCertificate> PersonnelCertificates { get; set; }

        #region map
        public static Certificate To(CertificateVM source)
        {
            return MapperConfig().CreateMapper().Map<CertificateVM, Certificate>(source);
        }
        public static List<Certificate> To(List<CertificateVM> sources)
        {
            List<Certificate> result = new List<Certificate>();
            for (int i = 0; i < sources.Count; i++)
                result.Add(MapperConfig().CreateMapper().Map<CertificateVM, Certificate>(sources[i]));

            return result;
        }

        public static CertificateVM From(Certificate source)
        {
            return MapperConfig().CreateMapper().Map<Certificate, CertificateVM>(source);
        }
        public static List<CertificateVM> From(List<Certificate> sources)
        {
            List<CertificateVM> result = new List<CertificateVM>();
            for (int i = 0; i < sources.Count; i++)
                result.Add(MapperConfig().CreateMapper().Map<Certificate, CertificateVM>(sources[i]));

            return result;
        }

        public static MapperConfiguration MapperConfig()
        {
            var mapperConfig = new MapperConfiguration(conf =>
            {
                conf.CreateMap<Certificate, CertificateVM>().ReverseMap();
                //.ForMember(p => p.CreatorUserId, p => p.MapFrom(q => q.CreatorUserId))
                //.ForMember(p => p.Age, p => p.MapFrom(q => q.Age));
            });
            return mapperConfig;
        }

        #endregion
    }
}
