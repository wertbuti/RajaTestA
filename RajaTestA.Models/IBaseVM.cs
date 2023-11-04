using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RajaTestA.Models
{
    public interface IBaseVM<TPrimaryKey>
    {
        TPrimaryKey Id { get; set; }
    }
}
