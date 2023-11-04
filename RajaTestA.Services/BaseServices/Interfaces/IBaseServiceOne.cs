using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RajaTestA.Services.BaseServices.Interfaces
{
    public interface IBaseServiceOne<TEntity,TPrimaryKey> : IBaseServiceZero
    {
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GettById(TPrimaryKey id);
        //TEntity GettById(TPrimaryKey id);
        TEntity Insert(TEntity entity);
        bool Update(TEntity entity);
        bool Delete(TPrimaryKey id);
    }
}
