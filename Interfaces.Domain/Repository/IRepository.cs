using System;
using System.Linq;
using System.Linq.Expressions;
using Interfaces.Domain.Entity;

namespace Interfaces.Domain.Repository
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
        /// Return a IQueryFluent object, with no initial query 
        /// </summary>
        /// <returns></returns>
        IQueryFluent<TEntity> Query();

        /// <summary>
        /// Return a IQueryFluent object that allows using fluent searches.
        /// Uses the provided initial query
        /// </summary>
        /// <param name="queryObject">The query object.</param>
        /// <returns></returns>
        IQueryFluent<TEntity> Query(IQueryObject<TEntity> queryObject);

        /// <summary>
        /// Return a IQueryFluent object that allows using fluent searches.
        /// Uses the provided expression as the initial query
        /// </summary>
        /// <param name="query">The query as a linq expression.</param>
        /// <returns></returns>
        IQueryFluent<TEntity> Query(Expression<Func<TEntity, bool>> query);

        
        /// <summary>
        /// Get the queryable object for this type, used for LINQ queries
        /// </summary>
        /// <returns></returns>
        IQueryable<TEntity> Queryable();

        
        /// <summary>
        /// Function to get repositories for other entity types via UnitOfWork
        /// </summary>
        /// <typeparam name="TOtherEntity">The type of the other entity.</typeparam>
        /// <returns></returns>
        IRepository<TOtherEntity> GetRepository<TOtherEntity>() where TOtherEntity : class, IEntity;

    }
}
