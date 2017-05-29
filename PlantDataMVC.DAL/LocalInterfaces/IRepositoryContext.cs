using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace PlantDataMVC.DAL.Interfaces
{
    public interface IRepositoryContext
    {
        /// <summary>
        /// Gets the set of objects for a given Type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        //IDbSet<T> GetDbSet<T>() where T : class;

        /// <summary>
        /// The context for 
        /// </summary>
        //DbContext DbContext { get; }

        /// <summary>
        /// Save all changes to all repositories
        /// </summary>
        /// <returns>Integer with number of objects affected</returns>
        int SaveChanges();

        /// <summary>
        /// Terminates the current repository context
        /// </summary>
        void Terminate();
    }
}
