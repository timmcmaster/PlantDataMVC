using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using PlantDataMvc3.DAL.Interfaces;
using PlantDataMvc3.DAL.LocalInterfaces;

namespace PlantDataMvc3.DAL.MappingRepositories
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
    public class MappingRepository<TDALEntity, TLocalEntity> : IRepository<TDALEntity>
        where TDALEntity : IEntity, new()
        where TLocalEntity : ILocalEntity
    {
        /// <summary>
        /// The local repository which contains objects in a format that suits the providing source
        /// </summary>
        protected ILocalRepository<TLocalEntity> LocalRepository { get; set; }

        /// <summary>
        /// Constructs a new mapping repository around a defined local repository
        /// </summary>
        /// <param name="localRepository">The local repository which defines the local object types</param>
        public MappingRepository(ILocalRepository<TLocalEntity> localRepository)
        {
            this.LocalRepository = localRepository;
        }

        #region IRepository implementation

        /// <summary>
        /// Gets all entities in the repository.
        /// Maps all elements from the local repo entity type to the DAL repo entity type
        /// </summary>
        /// <returns></returns>
        public virtual IList<TDALEntity> GetAll()
        {
            IList<TLocalEntity> localList = this.LocalRepository.GetAll();

            IList<TDALEntity> interfaceList = Mapper.Map<IList<TLocalEntity>, IList<TDALEntity>>(localList);

            return interfaceList;
        }

        public virtual TDALEntity GetItemById(int id)
        {
            // Note that there is an assumption here that id maps to the same value in both repositories

            TLocalEntity selectedItem = this.LocalRepository.GetItemById(id);

            TDALEntity interfaceItem = Mapper.Map<TLocalEntity, TDALEntity>(selectedItem);

            return interfaceItem;
        }


        public TDALEntity GetItemById(int id, params Expression<Func<TDALEntity, object>>[] includes)
        {
            // NOTE: There is an assumption here that id maps to the same value in both repositories
            // AND that include fields have the same names, which is VERY iffy...

            // TODO: Can we map the include fields to the corresponding fields?
            // OR make the property names part of the entity interface to ensure this...

            // Need to convert the includes to funcs of local entity
  //          Expression<Func<TLocalEntity, object>>[] localIncludes = MapIncludeExpressions(includes);


            //TLocalEntity selectedItem = this.LocalRepository.GetItemById(id, localIncludes);
            TLocalEntity selectedItem = this.LocalRepository.GetItemById(id);

            TDALEntity interfaceItem = Mapper.Map<TLocalEntity, TDALEntity>(selectedItem);

            return interfaceItem;
        }

/*
        private Expression<Func<TLocalEntity, object>>[] MapIncludeExpressions(Expression<Func<TDALEntity, object>>[] includes)
        {
            List<Expression<Func<TLocalEntity, object>>> localIncludes = new List<Expression<Func<TLocalEntity,object>>>();
            
            // use AutoMapper definitions to determine which properties need to be included to generate required include properties
            TypeMap mapToDAL = Mapper.FindTypeMapFor<TLocalEntity, TDALEntity>(); 

            foreach (Expression<Func<TDALEntity, object>> includeExpr in includes)
            {
                MemberExpression me = includeExpr.Body as MemberExpression;

                PropertyMap pm = mapToDAL.GetExistingPropertyMapFor((IMemberAccessor)me);

                pm
            }
            mapToDAL.GetExistingPropertyMapFor(
            return localIncludes.ToArray();
        }
*/
        public virtual TDALEntity Add(TDALEntity item)
        {
            TLocalEntity localItem = Mapper.Map<TDALEntity, TLocalEntity>(item);

            TLocalEntity addedItem = this.LocalRepository.Add(localItem);

            TDALEntity interfaceItem = Mapper.Map<TLocalEntity, TDALEntity>(addedItem);

            return interfaceItem;
        }

        /// <summary>
        /// Save/update an existing entity in the repository
        /// </summary>
        /// <param name="item">The entity to save</param>
        /// <returns>The saved entity</returns>
        public virtual TDALEntity Save(TDALEntity item)
        {
            TLocalEntity localItem = Mapper.Map<TDALEntity, TLocalEntity>(item);

            TLocalEntity savedItem = this.LocalRepository.Save(localItem);

            TDALEntity interfaceItem = Mapper.Map<TLocalEntity, TDALEntity>(savedItem);

            return interfaceItem;
        }

        /// <summary>
        /// Delete an entity from the repository.
        /// </summary>
        /// <param name="item">The entity to delete</param>
        public virtual void Delete(TDALEntity item)
        {
            TLocalEntity localItem = Mapper.Map<TDALEntity, TLocalEntity>(item);

            this.LocalRepository.Delete(localItem);
        }

        #endregion IRepository implementation
    }
}
