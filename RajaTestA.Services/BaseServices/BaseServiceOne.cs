using Microsoft.EntityFrameworkCore;
using RajaTestA.DataLayer.AppContext;
using RajaTestA.DomainEntities;
using RajaTestA.Services.BaseServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RajaTestA.Services.BaseServices
{
    public class BaseServiceOne<TEntity, TPrimaryKey> : BaseServiceZero, IBaseServiceOne<TEntity, TPrimaryKey>
        where TEntity : class, IBaseEntity<TPrimaryKey>
    {
        protected DbSet<TEntity> Table { get; }
        public BaseServiceOne(IRajaDbContext rajaDbContext) : base(rajaDbContext)
        {
            Table = rajaDbContext.Set<TEntity>();
        }
        public IQueryable<TEntity> GetAll()
        {
            return Table.AsQueryable();
        }

        public IQueryable<TEntity> GettById(TPrimaryKey id)
        {
            //var query = from t in Table
            //            where t.Id.Equals(id)
            //            select t;
            //return query.FirstOrDefault();

            return Table.Where(e => e.Id.Equals(id));
        }
        //public TEntity GettById(TPrimaryKey id)
        //{
        //    //var query = from t in Table
        //    //            where t.Id.Equals(id)
        //    //            select t;
        //    //return query.FirstOrDefault();

        //    return Table.Where(e => e.Id.Equals(id)).FirstOrDefault();
        //}

        public TEntity Insert(TEntity entity)
        {
            Table.Add(entity);
            SaveChanges();
            return entity;
        }

        public bool Update(TEntity entity)
        {
            RajaDbContext.Entry(entity).State = EntityState.Modified;
            return (SaveChanges() > 0);
        }

        public bool Delete(TPrimaryKey id)
        {
            var entity = Table.Find(id);
            //ShahinDbContext.Entry(entity).State = EntityState.Deleted;

            //or
            if (entity !=null)
                Table.Remove(entity);

            return (SaveChanges() > 0);
        }
    }
}
