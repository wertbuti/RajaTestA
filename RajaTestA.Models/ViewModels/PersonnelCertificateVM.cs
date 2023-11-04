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
    public class PersonnelCertificateVM : BaseVM<int>
    {      
        [Display(Name = "شناسه پرسنل")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} را وارد نمایید")]
        public int PersonnelId { get; set; }

        [Display(Name = "مدرک")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} را وارد نمایید")]
        [Range(1, double.MaxValue, ErrorMessage = "{0} را وارد نمایید")]
        public int CertificateId { get; set; }

        [Display(Name = "سال اخذ")]
        [Required(ErrorMessage = "{0} را وارد نمایید")]
        [Range(1300,1500, ErrorMessage = "{0} باید بین {1} و {2} باشد")]
        public int YearCatch { get; set; }

        [Display(Name = "معدل")]
        [Required(ErrorMessage = "{0} را وارد نمایید")]
        public decimal Gpa { get; set; }
        
        
        public virtual PersonnelVM Personnel { get; set; }
        public virtual CertificateVM Certificate { get; set; }

        #region map
        public static PersonnelCertificate To(PersonnelCertificateVM source)
        {
            return MapperConfig().CreateMapper().Map<PersonnelCertificateVM, PersonnelCertificate>(source);
        }
        public static List<PersonnelCertificate> To(List<PersonnelCertificateVM> sources)
        {
            List<PersonnelCertificate> result = new List<PersonnelCertificate>();
            for (int i = 0; i < sources.Count; i++)
                result.Add(MapperConfig().CreateMapper().Map<PersonnelCertificateVM, PersonnelCertificate>(sources[i]));

            return result;
        }

        public static PersonnelCertificateVM From(PersonnelCertificate source)
        {
            return MapperConfig().CreateMapper().Map<PersonnelCertificate, PersonnelCertificateVM>(source);
        }
        public static List<PersonnelCertificateVM> From(List<PersonnelCertificate> sources)
        {
            List<PersonnelCertificateVM> result = new List<PersonnelCertificateVM>();
            for (int i = 0; i < sources.Count; i++)
                result.Add(MapperConfig().CreateMapper().Map<PersonnelCertificate, PersonnelCertificateVM>(sources[i]));

            return result;
        }

        public static MapperConfiguration MapperConfig()
        {
            var mapperConfig = new MapperConfiguration(conf =>
            {
                conf.CreateMap<PersonnelCertificate, PersonnelCertificateVM>().ReverseMap();
                conf.CreateMap<Certificate, CertificateVM>().ReverseMap();
                conf.CreateMap<Personnel, PersonnelVM>().ReverseMap();
                //.ForMember(p => p.CreatorUserId, p => p.MapFrom(q => q.CreatorUserId))
                //.ForMember(p => p.Age, p => p.MapFrom(q => q.Age));
            });
            return mapperConfig;
        }

        #endregion
    }
}
