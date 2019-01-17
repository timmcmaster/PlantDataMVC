using AutoMapper;
using AutoMapper.QueryableExtensions;
using Framework.Service.Responses;
using Interfaces.DAL.Entity;
using Interfaces.DAL.UnitOfWork;
using Interfaces.DTO;
using Interfaces.Service;
using Interfaces.Service.Responses;
using Interfaces.WCFService;
using System.Collections.Generic;
using System.Linq;

namespace PlantDataMVC.WCFService.Services
{
    /// <summary>
    /// Note: Under the current model, this makes it the caller's responsibility to ensure
    /// that mappings exist between DTO types supplied to method and entity type defined by service 
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <seealso cref="Interfaces.WCFService.IWcfService" />
    public abstract class WcfService<TEntity> : IWcfService where TEntity : IEntity
    {
        protected IService<TEntity> Service { get; set; }
        protected IUnitOfWorkAsync UnitOfWork { get; set; }

        public WcfService(IUnitOfWorkAsync uow, IService<TEntity> service)
        {
            this.UnitOfWork = uow;
            this.Service = service;
        }

        #region IWcfService implementation
        public virtual ICreateResponse<TDtoOut> Create<TDtoIn, TDtoOut>(TDtoIn dtoItem) 
            where TDtoIn : class, IDto 
            where TDtoOut : class, IDto
        {
            using (var uow = this.UnitOfWork)
            {
                // map 
                TEntity mappedItem = Mapper.Map<TDtoIn, TEntity>(dtoItem);

                TEntity item = Service.Add(mappedItem);

                // Save changes before we map back
                var changes = uow.SaveChanges();

                ServiceActionStatus status = changes > 0 ? ServiceActionStatus.Created : ServiceActionStatus.NothingModified;

                TDtoOut createdItem = Mapper.Map<TEntity, TDtoOut>(item);

                return new CreateResponse<TDtoOut>(createdItem, status);
            }
        }

        public virtual IViewResponse<TDtoOut> View<TDtoOut>(int id) where TDtoOut : class, IDto
        {
            using (var uow = this.UnitOfWork)
            {
                TEntity item = Service.GetItemById(id);

                ServiceActionStatus status = item == null ? ServiceActionStatus.NotFound : ServiceActionStatus.Ok;

                TDtoOut finalItem = Mapper.Map<TEntity, TDtoOut>(item);

                return new ViewResponse<TDtoOut>(finalItem, status);
            }
        }

        public virtual IUpdateResponse<TDtoOut> Update<TDtoIn, TDtoOut>(int id, TDtoIn item)
            where TDtoIn : class, IDto
            where TDtoOut : class, IDto
        {
            using (var uow = this.UnitOfWork)
            {
                var retrievedItem = Service.GetItemById(id);
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

                TEntity updateditem = Service.Save(mappedItem);

                // Save changes before we map back
                var changes = uow.SaveChanges();

                ServiceActionStatus status = changes > 0 ? ServiceActionStatus.Updated : ServiceActionStatus.NothingModified;

                TDtoOut finalItem = Mapper.Map<TEntity, TDtoOut>(updateditem);

                return new UpdateResponse<TDtoOut>(finalItem, status);
            }
        }

        public virtual IDeleteResponse<TDtoOut> Delete<TDtoOut>(int id) where TDtoOut : class, IDto
        {
            using (var uow = this.UnitOfWork)
            {
                var foundItem = Service.GetItemById(id);
                if (foundItem != null)
                {
                    Service.Delete(foundItem);

                    uow.SaveChanges();
                    return new DeleteResponse<TDtoOut>(ServiceActionStatus.Deleted);

                }
                return new DeleteResponse<TDtoOut>(ServiceActionStatus.NotFound);
            }
        }

        public virtual IListResponse<TDtoOut> List<TDtoOut>() where TDtoOut : class, IDto
        {
            using (var uow = this.UnitOfWork)
            {
                var context = Service.Queryable();

                IList<TDtoOut> itemList = context.ProjectTo<TDtoOut>().ToList();

                return new ListResponse<TDtoOut>(itemList, ServiceActionStatus.Ok);
            }
        }

        #endregion
    }
}