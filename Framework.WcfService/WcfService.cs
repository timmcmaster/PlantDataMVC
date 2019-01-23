using AutoMapper;
using AutoMapper.QueryableExtensions;
using Framework.WcfService.Responses;
using Interfaces.DAL.Entity;
using Interfaces.DAL.UnitOfWork;
using Interfaces.DTO;
using Interfaces.WcfService;
using Interfaces.WcfService.Responses;
using System.Collections.Generic;
using System.Linq;

namespace Framework.WcfService
{
    /// <summary>
    /// Note: Under the current model, this makes it the caller's responsibility to ensure
    /// that mappings exist between DTO types supplied to method and entity type defined by service 
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <seealso cref="Interfaces.WcfService.IWcfService" />
    public abstract class WcfService<TEntity> : IWcfService where TEntity : class, IEntity
    {
        protected IUnitOfWorkAsync UnitOfWork { get; set; }

        protected WcfService(IUnitOfWorkAsync unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        #region IWcfService implementation
        public virtual ICreateResponse<TDtoOut> Create<TDtoIn, TDtoOut>(TDtoIn dtoItem) 
            where TDtoIn : class, IDto 
            where TDtoOut : class, IDto
        {
            using (var unitOfWork = UnitOfWork)
            {
                // map 
                TEntity mappedItem = Mapper.Map<TDtoIn, TEntity>(dtoItem);

                var repository = unitOfWork.RepositoryAsync<TEntity>();
                TEntity item = repository.Add(mappedItem);

                // Save changes before we map back
                var changes = unitOfWork.SaveChanges();

                ServiceActionStatus status = changes > 0 ? ServiceActionStatus.Created : ServiceActionStatus.NothingModified;

                TDtoOut createdItem = Mapper.Map<TEntity, TDtoOut>(item);

                return new CreateResponse<TDtoOut>(createdItem, status);
            }
        }

        public virtual IViewResponse<TDtoOut> View<TDtoOut>(int id) where TDtoOut : class, IDto
        {
            using (var unitOfWork = UnitOfWork)
            {
                var repository = unitOfWork.RepositoryAsync<TEntity>();
                TEntity item = repository.GetItemById(id);

                ServiceActionStatus status = item == null ? ServiceActionStatus.NotFound : ServiceActionStatus.Ok;

                TDtoOut finalItem = Mapper.Map<TEntity, TDtoOut>(item);

                return new ViewResponse<TDtoOut>(finalItem, status);
            }
        }

        public virtual IUpdateResponse<TDtoOut> Update<TDtoIn, TDtoOut>(int id, TDtoIn item)
            where TDtoIn : class, IDto
            where TDtoOut : class, IDto
        {
            using (var unitOfWork = UnitOfWork)
            {
                var repository = unitOfWork.RepositoryAsync<TEntity>();
                TEntity retrievedItem = repository.GetItemById(id);

                if (retrievedItem == null)
                {
                    return new UpdateResponse<TDtoOut>(null,ServiceActionStatus.Error);
                }
                //// Check for id matches Item.Id
                //if (id != item.Id)
                //{
                //    // TODO: Map input item to output item?

                //    return new UpdateResponse<TDtoOut>(item, ServiceActionStatus.Error);
                //}

                // map 
                TEntity mappedItem = Mapper.Map<TDtoIn, TEntity>(item);

                TEntity updatedItem = repository.Save(mappedItem);

                // Save changes before we map back
                var changes = unitOfWork.SaveChanges();

                ServiceActionStatus status = changes > 0 ? ServiceActionStatus.Updated : ServiceActionStatus.NothingModified;

                TDtoOut finalItem = Mapper.Map<TEntity, TDtoOut>(updatedItem);

                return new UpdateResponse<TDtoOut>(finalItem, status);
            }
        }

        public virtual IDeleteResponse<TDtoOut> Delete<TDtoOut>(int id) where TDtoOut : class, IDto
        {
            using (var unitOfWork = UnitOfWork)
            {
                var repository = unitOfWork.RepositoryAsync<TEntity>();

                var foundItem = repository.GetItemById(id);
                if (foundItem != null)
                {
                    repository.Delete(foundItem);
                    unitOfWork.SaveChanges();

                    return new DeleteResponse<TDtoOut>(ServiceActionStatus.Deleted);
                }
                return new DeleteResponse<TDtoOut>(ServiceActionStatus.NotFound);
            }
        }

        public virtual IListResponse<TDtoOut> List<TDtoOut>() where TDtoOut : class, IDto
        {
            using (var unitOfWork = UnitOfWork)
            {
                var repository = unitOfWork.RepositoryAsync<TEntity>();
                var context = repository.Queryable();

                IList<TDtoOut> itemList = context.ProjectTo<TDtoOut>().ToList();

                return new ListResponse<TDtoOut>(itemList, ServiceActionStatus.Ok);
            }
        }

        #endregion
    }
}