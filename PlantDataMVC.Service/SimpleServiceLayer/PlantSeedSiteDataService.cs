﻿using AutoMapper;
using Framework.DAL.UnitOfWork;
using Framework.Service.ServiceLayer;
using PlantDataMVC.Domain.Entities;
using PlantDataMVC.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlantDataMVC.Service.SimpleServiceLayer
{
    public class PlantSeedSiteDataService : BasicDataService<PlantSeedSite>
    {
        public PlantSeedSiteDataService(IUnitOfWorkAsync uow)
            : base(uow)
        {
        }

        protected override PlantSeedSite CreateItem(IUnitOfWorkAsync uow, PlantSeedSite requestItem)
        {
            // map 
            Site mappedItem = AutoMapper.Mapper.Map<PlantSeedSite, Site>(requestItem);

            Site item = uow.Repository<Site>().Add(mappedItem);

            PlantSeedSite finalItem = AutoMapper.Mapper.Map<Site, PlantSeedSite>(item);

            return finalItem;
        }

        protected override PlantSeedSite SelectItem(IUnitOfWorkAsync uow, int id)
        {
            // map 
            //Site mappedItem = AutoMapper.Mapper.Map<PlantSeedSite, Site>(requestItem);

            Site item = uow.Repository<Site>().GetItemById(id);

            PlantSeedSite finalItem = AutoMapper.Mapper.Map<Site, PlantSeedSite>(item);

            return finalItem;
        }

        protected override PlantSeedSite UpdateItem(IUnitOfWorkAsync uow, PlantSeedSite requestItem)
        {
            // map 
            Site mappedItem = AutoMapper.Mapper.Map<PlantSeedSite, Site>(requestItem);

            Site item = uow.Repository<Site>().Save(mappedItem);

            PlantSeedSite finalItem = AutoMapper.Mapper.Map<Site, PlantSeedSite>(item);

            return finalItem;
        }

        protected override void DeleteItem(IUnitOfWorkAsync uow, int id)
        {
            // map 
            //Site mappedItem = AutoMapper.Mapper.Map<PlantSeedSite, Site>(requestItem);

            uow.Repository<Site>().Delete(uow.Repository<Site>().GetItemById(id));
        }

        protected override IList<PlantSeedSite> ListItems(IUnitOfWorkAsync uow)
        {
            IList<Site> allItems = uow.Repository<Site>().GetAll();

            IList<PlantSeedSite> items = AutoMapper.Mapper.Map<IList<Site>, IList<PlantSeedSite>>(allItems);

            return items;
        }
    }
}