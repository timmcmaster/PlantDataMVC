﻿using System;
using System.Linq;
using System.Linq.Expressions;
using Interfaces.Domain.Entity;
using Interfaces.Domain.Repository;
using Interfaces.Service;

namespace Framework.Service
{
    public abstract class Service<TEntity> : IService<TEntity> where TEntity : class, IEntity
    {
        private readonly IRepositoryAsync<TEntity> _repository;

        protected Service(IRepositoryAsync<TEntity> repository)
        {
            _repository = repository;
        }

        #region IService<TEntity> Members
        public virtual IQueryable<TEntity> GetAll()
        {
            return _repository.GetAllItems(useTracking: true);
        }

        public virtual TEntity GetItemById(int id)
        {
            return _repository.GetItemById(id);
        }

        public virtual void Add(TEntity item)
        {
            _repository.Add(item);
        }

        public virtual void Update(TEntity item)
        {
            _repository.Update(item);
        }

        public virtual void Delete(TEntity item)
        {
            _repository.Delete(item);
        }

        public virtual IQueryable<TEntity> Queryable(bool useTracking)
        {
            return _repository.Queryable(useTracking);
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