using RajaTestA.DataLayer.AppContext;
using RajaTestA.Services.BaseServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RajaTestA.Services.BaseServices
{
    public class BaseServiceZero : IBaseServiceZero
    {
        protected IRajaDbContext RajaDbContext { get;}
        public BaseServiceZero(IRajaDbContext rajaDbContext)
        {
            RajaDbContext = rajaDbContext;
        }

        public int SaveChanges()
        {
           return RajaDbContext.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return RajaDbContext.SaveChangesAsync();
        }
    }
}
