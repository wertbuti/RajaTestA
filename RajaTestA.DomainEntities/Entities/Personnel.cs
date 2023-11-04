using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RajaTestA.DomainEntities.Entities
{
    public class Personnel : BaseEntity<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Mobile { get; set; }

        public string FullName { get { return FirstName + " " + LastName; } }

        //public virtual ICollection<PersonnelCertificate> PersonnelCertificates { get; set; } = null!;
    }
}
