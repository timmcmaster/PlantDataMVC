﻿using CommonServiceLocator;
using Interfaces.DAL.DataContext;
using Interfaces.DAL.Entity;
using Interfaces.DAL.Repository;
using Interfaces.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Threading;
using System.Threading.Tasks;

namespace Framework.DAL.EF
{
    /// <summary>
    /// Implements the UnitOfWork pattern 
    /// </summary>
    public class UnitOfWork : IUnitOfWorkAsync
    {
        #region Variables

        private bool _disposed = false;
        private IDataContextAsync _dataContext;
        private IDbTransaction _transaction;
        private Dictionary<string, dynamic> _repositories;

        #endregion Variables

        public UnitOfWork(IDataContextAsync dataContext)
        {
            _dataContext = dataContext;
            _repositories = new Dictionary<string, dynamic>();
        }

        public int SaveChanges()
        {
            return _dataContext.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return _dataContext.SaveChangesAsync();
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return _dataContext.SaveChangesAsync(cancellationToken);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dataContext.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Get the repository of a given type
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        public IRepository<TEntity> Repository<TEntity>() where TEntity : class, IEntity
        {
            // 1. Try to get current instance from IoC?
            // HACK: want to do constructor injection or delegate factory instead
            if (ServiceLocator.IsLocationProviderSet)
            {
                return ServiceLocator.Current.GetInstance<IRepository<TEntity>>();
            }

            return RepositoryAsync<TEntity>();
        }

        public IRepositoryAsync<TEntity> RepositoryAsync<TEntity>() where TEntity : class, IEntity
        {
            // 1. Try to get current instance from IoC?
            // HACK: want to do constructor injection or delegate factory instead
            if (ServiceLocator.IsLocationProviderSet)
            {
                return ServiceLocator.Current.GetInstance<IRepositoryAsync<TEntity>>();
            }

            // 2. Try dictionary
            var type = typeof(TEntity).Name;

            if (_repositories.ContainsKey(type))
            {
                return (IRepositoryAsync<TEntity>)_repositories[type];
            }

            // 3. Create new one, add to dictionary and return instance
            var repositoryType = typeof(Repository<>);

            //_repositories.Add(type, Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _dataContext, this));
            _repositories.Add(type, Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _dataContext));

            return _repositories[type];
        }

        public void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Unspecified)
        {
            var objectContext = ((IObjectContextAdapter) _dataContext).ObjectContext;
            if (objectContext.Connection.State != ConnectionState.Open)
            {
                objectContext.Connection.Open();
            }
            _transaction = objectContext.Connection.BeginTransaction(isolationLevel);
        }

        public bool Commit()
        {
            _transaction.Commit();
            return true;
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }
    }
}
