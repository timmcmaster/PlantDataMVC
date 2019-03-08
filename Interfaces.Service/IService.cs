using System;
using System.Linq;
using System.Linq.Expressions;
using Interfaces.Domain.Entity;
using Interfaces.Domain.Repository;

namespace Interfaces.Service
{
    public interface IService<TEntity> where TEntity : IEntity
    {
        // Basically just wraps all IRepository/IRepositoryAsync methods

        IQueryable<TEntity> GetAll();

        TEntity GetItemById(int id);

        TEntity Add(TEntity item);

        TEntity Save(TEntity item);

        void Delete(TEntity item);

        IQueryFluent<TEntity> Query();

        IQueryFluent<TEntity> Query(IQueryObject<TEntity> queryObject);

        IQueryFluent<TEntity> Query(Expression<Func<TEntity, bool>> query);

        IQueryable<TEntity> Queryable();
    }
}