using RajaTestA.Models.ViewModels;

namespace RajaTestA.WenAppMVC.Models
{
    public class PersonnelAndPersonnelCertificate
    {
        public PersonnelVM? PersonnelVM { get; set; }
        public List<PersonnelCertificateVM>? PersonnelCertificateVMs { get; set; }
    }
}
