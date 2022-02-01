using CommonServiceLocator;
using Interfaces.Domain.Entity;
using Interfaces.Domain.Repository;
using Interfaces.Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Threading;
using System.Threading.Tasks;

namespace Framework.Domain.EF
{
    /// <inheritdoc />
    /// <summary>
    ///     Implements the UnitOfWork pattern
    /// </summary>
    public class UnitOfWork : IUnitOfWorkAsync
    {
        private IDbContext _dbContext;
        private bool _disposed;
        private ObjectContext _objectContext;
        private readonly Dictionary<string, dynamic> _repositories;
        private IDbTransaction _transaction;

        public UnitOfWork(IDbContext dbContext)
        {
            _dbContext = dbContext;
            _repositories = new Dictionary<string, dynamic>();
        }

        #region IUnitOfWorkAsync Members
        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return _dbContext.SaveChangesAsync();
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return _dbContext.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        ///     Get the repository of a given type
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
                return (IRepositoryAsync<TEntity>) _repositories[type];
            }

            // 3. Create new one, add to dictionary and return instance
            var repositoryType = typeof(EFRepository<>);

            _repositories.Add(
                type, Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _dbContext, this));

            return _repositories[type];
        }

        public void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Unspecified)
        {
            _objectContext = ((IObjectContextAdapter)_dbContext).ObjectContext;

            if (_objectContext.Connection.State != ConnectionState.Open)
            {
                _objectContext.Connection.Open();
            }

            _transaction = _objectContext.Connection.BeginTransaction(isolationLevel);
        }

        public bool Commit()
        {
            _transaction.Commit();
            return true;
        }

        public void Rollback()
        {
            _transaction.Rollback();
            //_dataContext.SyncObjectsStatePostCommit();
        }
        #endregion

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    try
                    {
                        if (_objectContext != null && _objectContext.Connection.State == ConnectionState.Open)
                        {
                            _objectContext.Connection.Close();
                        }
                    }
                    catch (ObjectDisposedException)
                    {
                        // do nothing, the objectContext has already been disposed
                    }

                    if (_dbContext != null)
                    {
                        _dbContext.Dispose();
                        _dbContext = null;
                    }
                }
            }

            _disposed = true;
        }
    }
}