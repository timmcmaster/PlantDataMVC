using Framework.DAL.Entity;
using Framework.DAL.Repository;
using System;

namespace Framework.DAL.UnitOfWork
{
    /// <summary>
    /// This is the base interface for the unit of work object that is exposed from the DAL to the business layer.
    /// If a new repository type is added to the model, an interface get property should be added here.
    /// </summary>
    public interface IUnitOfWork: IDisposable
    {
        // Function to return repository of given type
        IRepository<TEntity> Repository<TEntity>() where TEntity : class, IEntity;

        /// <summary>
        /// Commit the transaction to the repository collection.
        /// </summary>
        void Commit();
    }
}
