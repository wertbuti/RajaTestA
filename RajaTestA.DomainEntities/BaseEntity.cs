using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RajaTestA.DomainEntities
{
    public class BaseEntity<TPrimaryKey> : IBaseEntity<TPrimaryKey>
    {
        public TPrimaryKey Id { get; set; }
    }
}
