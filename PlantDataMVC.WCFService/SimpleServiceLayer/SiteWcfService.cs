using AutoMapper;
using AutoMapper.QueryableExtensions;
using Framework.Service.Entities;
using Interfaces.DAL.UnitOfWork;
using Interfaces.Service;
using PlantDataMVC.DTO.Entities;
using PlantDataMVC.Entities.Models;
using PlantDataMVC.WCFService.ServiceContractsWCF;
using System.Collections.Generic;
using System.Linq;

namespace PlantDataMVC.Service.SimpleServiceLayer
{
    public class SiteWcfService : ISiteWcfService
    {
        protected ISiteService Service { get; set; }
        protected IUnitOfWorkAsync UnitOfWork { get; set; }

        public SiteWcfService(IUnitOfWorkAsync uow, ISiteService service)
        {
            this.UnitOfWork = uow;
            this.Service = service;
        }

        #region IDataServiceBase implementation
        public virtual CreateResponse<SiteDTO> Create(SiteDTO dtoItem)
        {
            using (var uow = this.UnitOfWork)
            {
                // map 
                Site mappedItem = Mapper.Map<SiteDTO, Site>(dtoItem);
                Site item = uow.Repository<Site>().Add(mappedItem);
                // Save changes before we map back
                uow.SaveChanges();

                SiteDTO createdItem = Mapper.Map<Site, SiteDTO>(item);

                return new CreateResponse<SiteDTO>(createdItem.Id, createdItem, ServiceActionStatus.);
            }
        }

        public virtual IViewResponse<TEntity> View(int id)
        {
            using (var uow = this.UnitOfWork)
            {
                TEntity item = SelectItem(uow, id);

                return new ViewResponse<TEntity>(item);
            }
        }

        public virtual IUpdateResponse<TEntity> Update(int id, TEntity item)
        {
            using (var uow = this.UnitOfWork)
            {
                // TODO: Add check for id matches Item.Id

                TEntity updatedItem = UpdateItem(uow, item);

                //uow.SaveChanges();

                return new UpdateResponse<TEntity>(updatedItem);
            }
        }

        public virtual IDeleteResponse<TEntity> Delete(int id)
        {
            using (var uow = this.UnitOfWork)
            {
                var response = new DeleteResponse<TEntity>();

                try
                {
                    DeleteItem(uow, id);

                    uow.SaveChanges();
                }
                catch (SqlException ex)
                {
                    response.ErrorCode = ex.Number;
                    throw; // to ensure error is seen for now
                }
                finally
                {
                }

                return response;
            }
        }

        public virtual IListResponse<TEntity> List()
        {
            using (var uow = this.UnitOfWork)
            {
                IList<TEntity> itemList = ListItems(uow);

                return new ListResponse<TEntity>(itemList);
            }
        }
        #endregion

        protected override PlantSeedSite CreateItem(IUnitOfWorkAsync uow, PlantSeedSite requestItem)
        {
            // map 
            Site mappedItem = Mapper.Map<PlantSeedSite, Site>(requestItem);
            Site item = uow.Repository<Site>().Add(mappedItem);
            // Save changes before we map back
            uow.SaveChanges();
            PlantSeedSite finalItem = Mapper.Map<Site, PlantSeedSite>(item);

            return finalItem;
        }

        protected override PlantSeedSite SelectItem(IUnitOfWorkAsync uow, int id)
        {
            // map 
            //Site mappedItem = Mapper.Map<PlantSeedSite, Site>(requestItem);
            Site item = uow.Repository<Site>().GetItemById(id);
            PlantSeedSite finalItem = Mapper.Map<Site, PlantSeedSite>(item);

            return finalItem;
        }

        protected override PlantSeedSite UpdateItem(IUnitOfWorkAsync uow, PlantSeedSite requestItem)
        {
            // map 
            Site mappedItem = Mapper.Map<PlantSeedSite, Site>(requestItem);
            Site item = uow.Repository<Site>().Save(mappedItem);
            // Save changes before we map back
            uow.SaveChanges();
            PlantSeedSite finalItem = Mapper.Map<Site, PlantSeedSite>(item);

            return finalItem;
        }

        protected override void DeleteItem(IUnitOfWorkAsync uow, int id)
        {
            // map 
            //Site mappedItem = Mapper.Map<PlantSeedSite, Site>(requestItem);
            uow.Repository<Site>().Delete(uow.Repository<Site>().GetItemById(id));
        }

        protected override IList<PlantSeedSite> ListItems(IUnitOfWorkAsync uow)
        {
            var context = uow.Repository<Site>().Queryable();
            IList<PlantSeedSite> items = context.ProjectTo<PlantSeedSite>().ToList();

            return items;
        }
    }
}
