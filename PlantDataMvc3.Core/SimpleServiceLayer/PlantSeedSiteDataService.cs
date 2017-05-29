using System;
using System.Collections.Generic;
using System.Linq;
using PlantDataMvc3.Core.DataAccess;
using PlantDataMvc3.Core.Domain.BusinessObjects;
using PlantDataMVC.DAL.Entities;
using PlantDataMVC.DAL.Interfaces;

namespace PlantDataMvc3.Core.SimpleServiceLayer
{
    public class PlantSeedSiteDataService : BasicDataService<PlantSeedSite>
    {
        public PlantSeedSiteDataService(IUnitOfWorkManager uowManager)
            : base(uowManager)
        {
        }

        protected override PlantSeedSite CreateItem(IUnitOfWork uow, PlantSeedSite requestItem)
        {
            // map 
            Site mappedItem = AutoMapper.Mapper.Map<PlantSeedSite, Site>(requestItem);

            Site item = uow.SiteRepository.Add(mappedItem);

            PlantSeedSite finalItem = AutoMapper.Mapper.Map<Site, PlantSeedSite>(item);

            return finalItem;
        }

        protected override PlantSeedSite SelectItem(IUnitOfWork uow, int id)
        {
            // map 
            //Site mappedItem = AutoMapper.Mapper.Map<PlantSeedSite, Site>(requestItem);

            Site item = uow.SiteRepository.GetItemById(id);

            PlantSeedSite finalItem = AutoMapper.Mapper.Map<Site, PlantSeedSite>(item);

            return finalItem;
        }

        protected override PlantSeedSite UpdateItem(IUnitOfWork uow, PlantSeedSite requestItem)
        {
            // map 
            Site mappedItem = AutoMapper.Mapper.Map<PlantSeedSite, Site>(requestItem);

            Site item = uow.SiteRepository.Save(mappedItem);

            PlantSeedSite finalItem = AutoMapper.Mapper.Map<Site, PlantSeedSite>(item);

            return finalItem;
        }

        protected override void DeleteItem(IUnitOfWork uow, int id)
        {
            // map 
            //Site mappedItem = AutoMapper.Mapper.Map<PlantSeedSite, Site>(requestItem);

            uow.SiteRepository.Delete(uow.SiteRepository.GetItemById(id));
        }

        protected override IList<PlantSeedSite> ListItems(IUnitOfWork uow)
        {
            IList<Site> allItems = uow.SiteRepository.GetAll();

            IList<PlantSeedSite> items = AutoMapper.Mapper.Map<IList<Site>, IList<PlantSeedSite>>(allItems);

            return items;
        }
    }
}
