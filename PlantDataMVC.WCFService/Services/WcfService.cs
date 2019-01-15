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
    public abstract class WcfService<TDto, TEntity> : IWcfService<TDto> where TDto : IDtoEntity 
                                                                        where TEntity : IEntity
    {
        protected IService<TEntity> Service { get; set; }
        protected IUnitOfWorkAsync UnitOfWork { get; set; }

        public WcfService(IUnitOfWorkAsync uow, IService<TEntity> service)
        {
            this.UnitOfWork = uow;
            this.Service = service;
        }

        #region IWcfService implementation
        public virtual ICreateResponse<TDto> Create(TDto dtoItem)
        {
            using (var uow = this.UnitOfWork)
            {
                // map 
                TEntity mappedItem = Mapper.Map<TDto, TEntity>(dtoItem);

                TEntity item = Service.Add(mappedItem);

                // Save changes before we map back
                var changes = uow.SaveChanges();

                ServiceActionStatus status = changes > 0 ? ServiceActionStatus.Created : ServiceActionStatus.NothingModified;

                TDto createdItem = Mapper.Map<TEntity, TDto>(item);

                return new CreateResponse<TDto>(createdItem.Id, createdItem, status);
            }
        }

        public virtual IViewResponse<TDto> View(int id)
        {
            using (var uow = this.UnitOfWork)
            {
                TEntity item = Service.GetItemById(id);

                ServiceActionStatus status = item == null ? ServiceActionStatus.NotFound : ServiceActionStatus.Ok;

                TDto finalItem = Mapper.Map<TEntity, TDto>(item);

                return new ViewResponse<TDto>(finalItem, status);
            }
        }

        public virtual IUpdateResponse<TDto> Update(int id, TDto item)
        {
            using (var uow = this.UnitOfWork)
            {
                // Check for id matches Item.Id
                if (id != item.Id)
                {
                    return new UpdateResponse<TDto>(item, ServiceActionStatus.Error);
                }

                // map 
                TEntity mappedItem = Mapper.Map<TDto, TEntity>(item);

                TEntity updateditem = Service.Save(mappedItem);

                // Save changes before we map back
                var changes = uow.SaveChanges();

                ServiceActionStatus status = changes > 0 ? ServiceActionStatus.Updated : ServiceActionStatus.NothingModified;

                TDto finalItem = Mapper.Map<TEntity, TDto>(updateditem);

                return new UpdateResponse<TDto>(finalItem, status);
            }
        }

        public virtual IDeleteResponse<TDto> Delete(int id)
        {
            using (var uow = this.UnitOfWork)
            {
                var foundItem = Service.GetItemById(id);
                if (foundItem != null)
                {
                    Service.Delete(foundItem);

                    uow.SaveChanges();
                    return new DeleteResponse<TDto>(ServiceActionStatus.Deleted);

                }
                return new DeleteResponse<TDto>(ServiceActionStatus.NotFound);
            }
        }

        public virtual IListResponse<TDto> List()
        {
            using (var uow = this.UnitOfWork)
            {
                var context = Service.Queryable();

                IList<TDto> itemList = context.ProjectTo<TDto>().ToList();

                return new ListResponse<TDto>(itemList, ServiceActionStatus.Ok);
            }
        }
        #endregion
    }
}