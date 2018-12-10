using Interfaces.DAL.Entity;
using Interfaces.DAL.Repository;
using System;
using System.Data;

namespace Interfaces.DAL.UnitOfWork
{
    /// <summary>
    /// This is the base interface for the unit of work object that is exposed from the DAL to the business layer.
    /// If a new repository type is added to the model, an interface get property should be added here.
    /// </summary>
    public interface IUnitOfWork: IDisposable
    {
        // Function to return repository of given type
        IRepository<TEntity> Repository<TEntity>() where TEntity : class, IEntity;

        int SaveChanges();
        void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Unspecified);
        bool Commit();
        void Rollback();
    }
}
