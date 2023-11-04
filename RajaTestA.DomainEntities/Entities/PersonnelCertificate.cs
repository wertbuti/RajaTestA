using RajaTestA.DomainEntities;
using System;
using System.Collections.Generic;

namespace RajaTestA.DomainEntities.Entities
{
    public partial class PersonnelCertificate : BaseEntity<int>
    {
        public int PersonnelId { get; set; }
        public int CertificateId { get; set; }
        public int YearCatch { get; set; }
        public decimal Gpa { get; set; }

        public virtual Personnel Personnel { get; set; }
        public virtual Certificate Certificate { get; set; }
    }
}
