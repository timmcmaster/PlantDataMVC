using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using PlantDataMvc3.DAL.Interfaces;

namespace PlantDataMvc3.DAL.Repositories
{
    /// <summary>
    /// This class is built on the basic IRepository interface exposed to the DAL layer.
    /// Given the local and DAL entity types, this repo provides mappings 
    /// from the local repo to the DAL repo.
    /// The MappingRepository provides all the base methods defined by IRepository
    /// while also performing mappings between two repo types.
    /// There may be some overhead in doing these mappings every time.
    /// </summary>
    /// <typeparam name="TDALEntity">The type for the entity to be mapped to and used externally</typeparam>
    /// <typeparam name="TLocalEntity">The type for the local entity to be mapped from</typeparam>
    public abstract class Repository<TDALEntity> : IRepository<TDALEntity>
        where TDALEntity : IEntity, new()
    {
        /// <summary>
        /// Constructs a new mapping repository around a defined local repository
        /// </summary>
        /// <param name="localRepository">The local repository which defines the local object types</param>
        public Repository()
        {
        }

        #region IRepository implementation

        /// <summary>
        /// Gets all entities in the repository.
        /// Maps all elements from the local repo entity type to the DAL repo entity type
        /// </summary>
        /// <returns></returns>
        public abstract IList<TDALEntity> GetAll();

        public abstract TDALEntity GetItemById(int id);
        
        public abstract TDALEntity GetItemById(int id, params Expression<Func<TDALEntity, object>>[] includes);
        
        public abstract TDALEntity Add(TDALEntity item);

        /// <summary>
        /// Save/update an existing entity in the repository
        /// </summary>
        /// <param name="item">The entity to save</param>
        /// <returns>The saved entity</returns>
        public abstract TDALEntity Save(TDALEntity item);

        /// <summary>
        /// Delete an entity from the repository.
        /// </summary>
        /// <param name="item">The entity to delete</param>
        public abstract void Delete(TDALEntity item);

        #endregion IRepository implementation
    }
}
