using Framework.DAL.DataContext;
using Framework.DAL.EF.Repository;
using Framework.DAL.Entity;
using Framework.DAL.Repository;
using Framework.DAL.UnitOfWork;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Framework.DAL.EF.UnitOfWork
{
    /// <summary>
    /// Implements the UnitOfWork pattern 
    /// </summary>
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        #region Variables

        private bool _disposed = false;
        private IDataContext _dataContext;
        private Dictionary<string, dynamic> _repositories;

        #endregion Variables

        public UnitOfWork(IDataContext dataContext)
        {
            _dataContext = dataContext;
            _repositories = new Dictionary<string, dynamic>();
        }

        public void Commit()
        {
            _dataContext.SaveChanges();
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

            // 2. Try dictionary
            var type = typeof(TEntity).Name;

            if (_repositories.ContainsKey(type))
            {
                return (IRepository<TEntity>)_repositories[type];
            }

            // 3. Create new one, add to dictionary and return instance
            var repositoryType = typeof(Repository<>);

            _repositories.Add(type, Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _dataContext, this));

            return _repositories[type];
        }
    }
}
