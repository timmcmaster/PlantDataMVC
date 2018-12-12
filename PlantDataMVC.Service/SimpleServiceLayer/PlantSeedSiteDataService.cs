using AutoMapper;
using AutoMapper.QueryableExtensions;
using Framework.Service;
using Interfaces.DAL.UnitOfWork;
using PlantDataMVC.Domain.Entities;
using PlantDataMVC.Entities.Models;
using PlantDataMVC.Service.ServiceContracts;
using System.Collections.Generic;
using System.Linq;

namespace PlantDataMVC.Service.SimpleServiceLayer
{
    public class PlantSeedSiteDataService : DataServiceBase<PlantSeedSite>, IPlantSeedSiteDataService
    {
        public PlantSeedSiteDataService(IUnitOfWorkAsync uow)
            : base(uow)
        {
        }

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
