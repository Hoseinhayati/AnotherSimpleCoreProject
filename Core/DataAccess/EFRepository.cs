using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Asp.netCore_MVC_.Core.DataAccess
{
    public class EFRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _context;
        protected DbSet<TEntity> Entities { get; private set; }
        //Context just for save
        //operation do in entities

        public EFRepository(DbContext context)
        {
            _context = context;
            Entities = _context.Set<TEntity>();
        }

        public TEntity GetByPk(params object[] keyValues)
        {
            var entity = Entities.Find(keyValues);

            return entity;
        }


        public List<TEntity> GetAll()
        {
            return Entities.ToList();
        }

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null)
        {
            IQueryable<TEntity> query = Entities;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return query; //.AsNoTracking();
        }

        public virtual void Insert(TEntity entity)
        {
            Entities.Add(entity);
        }


        public virtual void Update(TEntity entity)
        {
            Entities.Update(entity);
        }


        public virtual void Delete(TEntity entity)
        {
            Entities.Remove(entity);
        }

        public void DeleteByPk(params object[] keyValues)
        {
            var entityToDelete = Entities.Find(keyValues);
            Delete(entityToDelete);
        }

    }
}
