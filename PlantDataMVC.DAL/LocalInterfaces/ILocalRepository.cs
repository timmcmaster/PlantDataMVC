using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace PlantDataMvc3.DAL.LocalInterfaces
{
    /// <summary>
    /// Defines base operations that must be provided by all repositories
    /// </summary>
    /// <typeparam name="T">The type of object that the repository works with.</typeparam>
    public interface ILocalRepository<T>
    {
        /// <summary>
        /// Get list of items 
        /// </summary>
        /// <returns></returns>
        IList<T> GetAll();

        /// <summary>
        /// Get single item 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetItemById(int id);

        /// <summary>
        /// Get single item 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetItemById(int id, params Expression<Func<T, object>>[] includes);

        /// <summary>
        /// Add a single item
        /// </summary>
        /// <param name="item"></param>
        T Add(T item);

        /// <summary>
        /// Save a single item 
        /// </summary>
        /// <param name="item"></param>
        T Save(T item);

       
        /// <summary>
        /// Delete a single item 
        /// </summary>
        /// <param name="item"></param>
        void Delete(T item);

        /// <summary>
        /// Get the queryable object for this type, used for LINQ queries
        /// </summary>
        /// <returns></returns>
        //IQueryable<T> GetQueryable();
    }
}
