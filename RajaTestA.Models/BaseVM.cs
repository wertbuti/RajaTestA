using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RajaTestA.Models
{
    public class BaseVM<TPrimaryKey> : IBaseVM<TPrimaryKey>
    {
        [Display(Name = "شناسه")]
        public TPrimaryKey Id { get; set; }
    }
}
