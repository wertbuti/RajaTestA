using RajaTestA.DomainEntities;
using System;
using System.Collections.Generic;

namespace RajaTestA.DomainEntities.Entities
{
    public partial class Certificate : BaseEntity<int>
    {
        public string? Name { get; set; }

        //public virtual ICollection<PersonnelCertificate> PersonnelCertificates { get; set; }
    }
}
