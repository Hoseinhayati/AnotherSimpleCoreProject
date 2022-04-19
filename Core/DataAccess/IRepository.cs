using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Asp.netCore_MVC_.Core.DataAccess
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Insert(TEntity newEntity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        List<TEntity> GetAll();
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null);
    }
}
