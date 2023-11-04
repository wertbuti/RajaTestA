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
    public class PersonnelCertificateInsertVM : BaseVM<int>
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
        

        #region map
        public static PersonnelCertificate To(PersonnelCertificateInsertVM source)
        {
            return MapperConfig().CreateMapper().Map<PersonnelCertificateInsertVM, PersonnelCertificate>(source);
        }
        public static List<PersonnelCertificate> To(List<PersonnelCertificateInsertVM> sources)
        {
            List<PersonnelCertificate> result = new List<PersonnelCertificate>();
            for (int i = 0; i < sources.Count; i++)
                result.Add(MapperConfig().CreateMapper().Map<PersonnelCertificateInsertVM, PersonnelCertificate>(sources[i]));

            return result;
        }

        public static PersonnelCertificateInsertVM From(PersonnelCertificate source)
        {
            return MapperConfig().CreateMapper().Map<PersonnelCertificate, PersonnelCertificateInsertVM>(source);
        }
        public static List<PersonnelCertificateInsertVM> From(List<PersonnelCertificate> sources)
        {
            List<PersonnelCertificateInsertVM> result = new List<PersonnelCertificateInsertVM>();
            for (int i = 0; i < sources.Count; i++)
                result.Add(MapperConfig().CreateMapper().Map<PersonnelCertificate, PersonnelCertificateInsertVM>(sources[i]));

            return result;
        }

        public static MapperConfiguration MapperConfig()
        {
            var mapperConfig = new MapperConfiguration(conf =>
            {
                conf.CreateMap<PersonnelCertificate, PersonnelCertificateInsertVM>().ReverseMap();
                //.ForMember(p => p.CreatorUserId, p => p.MapFrom(q => q.CreatorUserId))
                //.ForMember(p => p.Age, p => p.MapFrom(q => q.Age));
            });
            return mapperConfig;
        }

        #endregion
    }
}
