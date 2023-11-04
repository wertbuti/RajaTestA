using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RajaTestA.DomainEntities
{
    public interface IBaseEntity<TPrimaryKey>
    {
        TPrimaryKey Id { get; set; }
    }
}
