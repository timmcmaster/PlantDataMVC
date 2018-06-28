using Interfaces.DAL.DataContext;
using Interfaces.DAL.Entity;
using Interfaces.DAL.Repository;
using Interfaces.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
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
        private Dictionary<string, dynamic> _repositories;
        private IRepositoryFactory _repositoryFactory;

        #endregion Variables

        // TODO: While this is a "better" (more explicit) way to do it, it's still effectively a ServiceLocator pattern
        // Issues are that UoW is dependent on implementations of IRepositoryFactory defining each of the repository types needed
        // but there is no compulsion on the implementer to do this. AbstractFactory is better way, or redesign to register repo with uow.
        public UnitOfWork(IDataContextAsync dataContext, IRepositoryFactory repositoryFactory)
        //public UnitOfWork(IDataContextAsync dataContext)
        {
            _dataContext = dataContext;
            _repositories = new Dictionary<string, dynamic>();
            _repositoryFactory = repositoryFactory;
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
            return RepositoryAsync<TEntity>();
        }

        public IRepositoryAsync<TEntity> RepositoryAsync<TEntity>() where TEntity : class, IEntity
        {
            // 1. Try dictionary
            var type = typeof(TEntity).Name;

            if (_repositories.ContainsKey(type))
            {
                return (IRepositoryAsync<TEntity>)_repositories[type];
            }

            // 2. Create new one, add to dictionary and return instance
            // Call factory method to get repository instance
            var repo = _repositoryFactory.Create<TEntity>();
            // Add to dictionary
            // TODO: check lifetime scope issues
            _repositories.Add(type,repo);

            return _repositories[type];
        }
    }
}
