using Interfaces.Domain.Entity;
using Interfaces.Domain.Repository;
using Interfaces.Domain.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
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
        private bool _disposed;
        private IDbContextTransaction _transaction;

        private IDbContext _dbContext;
        private readonly Dictionary<string, dynamic> _repositories;
        private readonly IServiceProvider _serviceProvider;

        public UnitOfWork(IDbContext dbContext, IServiceProvider serviceProvider)
        {
            _dbContext = dbContext;
            _repositories = new Dictionary<string, dynamic>();
            _serviceProvider = serviceProvider;
        }

        // TODO: Constructor for testing where no DI used - how do we get repos?
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
            // TODO: Effectively servicelocator pattern - can I do it better
            IRepository<TEntity> repo = _serviceProvider.GetService<IRepository<TEntity>>();
            
            return repo ?? RepositoryAsync<TEntity>();
        }

        public IRepositoryAsync<TEntity> RepositoryAsync<TEntity>() where TEntity : class, IEntity
        {
            // TODO: Effectively servicelocator pattern - can I do it better
            IRepositoryAsync<TEntity> repo = _serviceProvider.GetService<IRepositoryAsync<TEntity>>();

            if (repo != null)
            {
                return repo;
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
                type, Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _dbContext));

            return _repositories[type];
        }

        public void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Unspecified)
        {
            var dbConnection = _dbContext.Database.GetDbConnection();
            if (dbConnection.State != ConnectionState.Open)
            {
                dbConnection.Open();
            }

            _transaction = _dbContext.Database.BeginTransaction(isolationLevel);

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
                        if (_dbContext != null && _dbContext.Database.GetDbConnection().State == ConnectionState.Open)
                        {
                            _dbContext.Database.CloseConnection();
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