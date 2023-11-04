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
    public class PersonnelVM : BaseVM<int>
    {
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


        [Display(Name = "نام و نام خانوادگی")]
        public string FullName { get { return FirstName + " " + LastName; } }

        //public virtual ICollection<PersonnelCertificate> PersonnelCertificates { get; set; } = null!;

        #region map
        public static Personnel To(PersonnelVM source)
        {
            return MapperConfig().CreateMapper().Map<PersonnelVM, Personnel>(source);
        }
        public static List<Personnel> To(List<PersonnelVM> sources)
        {
            List<Personnel> result = new List<Personnel>();
            for (int i = 0; i < sources.Count; i++)
                result.Add(MapperConfig().CreateMapper().Map<PersonnelVM, Personnel>(sources[i]));

            return result;
        }

        public static PersonnelVM From(Personnel source)
        {
            return MapperConfig().CreateMapper().Map<Personnel, PersonnelVM>(source);
        }
        public static List<PersonnelVM> From(List<Personnel> sources)
        {
            List<PersonnelVM> result = new List<PersonnelVM>();
            for (int i = 0; i < sources.Count; i++)
                result.Add(MapperConfig().CreateMapper().Map<Personnel, PersonnelVM>(sources[i]));

            return result;
        }

        public static MapperConfiguration MapperConfig()
        {
            var mapperConfig = new MapperConfiguration(conf =>
            {
                conf.CreateMap<Personnel, PersonnelVM>().ReverseMap();
                //.ForMember(p => p.CreatorUserId, p => p.MapFrom(q => q.CreatorUserId))
                //.ForMember(p => p.Age, p => p.MapFrom(q => q.Age));
            });
            return mapperConfig;
        }

        #endregion
    }
}
