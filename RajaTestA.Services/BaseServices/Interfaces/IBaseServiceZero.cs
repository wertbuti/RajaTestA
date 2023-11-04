using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RajaTestA.Services.BaseServices.Interfaces
{
    public interface IBaseServiceZero
    {
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
