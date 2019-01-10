using Interfaces.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Interfaces.DAL.Repository
{
    /// <summary>
    /// This is the base interface for generic repositories implemented within the 
    /// unit of work that is exposed at the DAL level.
    /// It defines base operations that must be provided by all repositories
    /// </summary>
    /// <typeparam name="TEntity">The type of object that the repository works with.</typeparam>
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        /// <summary>
        /// Get list of items 
        /// </summary>
        /// <returns></returns>
        IQueryable<TEntity> GetAll();

        /// <summary>
        /// Get single item 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity GetItemById(int id);

        /// <summary>
        /// Get single item 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //TEntity GetItemById(int id, params Expression<Func<TEntity, object>>[] includes);

        /// <summary>
        /// Add a single item
        /// </summary>
        /// <param name="item"></param>
        TEntity Add(TEntity item);

        /// <summary>
        /// Save a single item 
        /// </summary>
        /// <param name="item"></param>
        TEntity Save(TEntity item);

       
        /// <summary>
        /// Delete a single item 
        /// </summary>
        /// <param name="item"></param>
        void Delete(TEntity item);

        /// <summary>
        /// Get the queryable object for this type, used for LINQ queries
        /// </summary>
        /// <returns></returns>
        IQueryable<TEntity> Queryable();

        // Function to get repositories for other entity types via unitofwork
        //IRepository<T> GetRepository<T>() where T : class, IEntity;

    }
}
