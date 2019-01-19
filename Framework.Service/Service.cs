using Interfaces.DAL.Entity;
using Interfaces.DAL.Repository;
using Interfaces.Service;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Framework.Service
{
    public abstract class Service<TEntity> : IService<TEntity> where TEntity : class, IEntity
    {
        private readonly IRepositoryAsync<TEntity> _repository;

        protected Service(IRepositoryAsync<TEntity> repository)
        {
            _repository = repository;
        }

        #region IService implementation
        public virtual IQueryable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public virtual TEntity GetItemById(int id)
        {
            return _repository.GetItemById(id);
        }

        public virtual TEntity Add(TEntity item)
        {
            return _repository.Add(item);
        }

        public virtual TEntity Save(TEntity item)
        {
            return _repository.Save(item);
        }

        public virtual void Delete(TEntity item)
        {
            _repository.Delete(item);
        }

        public virtual IQueryable<TEntity> Queryable()
        {
            return _repository.Queryable();
        }

        public virtual IQueryFluent<TEntity> Query()
        {
            return _repository.Query();
        }

        public virtual IQueryFluent<TEntity> Query(IQueryObject<TEntity> queryObject)
        {
            return _repository.Query(queryObject);
        }

        public virtual IQueryFluent<TEntity> Query(Expression<Func<TEntity, bool>> query)
        {
            return _repository.Query(query);
        }
        #endregion
    }
}