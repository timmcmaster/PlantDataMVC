using AutoMapper;
using Framework.DAL.UnitOfWork;
using Framework.Service.ServiceLayer;
using PlantDataMVC.Domain.Entities;
using PlantDataMVC.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlantDataMVC.Service.SimpleServiceLayer
{
    public class PlantSeedTrayDataService : BasicDataService<PlantSeedTray>
    {
        public PlantSeedTrayDataService(IUnitOfWork uow)
            : base(uow)
        {
        }

        protected override PlantSeedTray CreateItem(IUnitOfWork uow, PlantSeedTray requestItem)
        {
            // map 
            SeedTray mappedItem = AutoMapper.Mapper.Map<PlantSeedTray, SeedTray>(requestItem);

            SeedTray item = uow.Repository<SeedTray>().Add(mappedItem);

            PlantSeedTray finalItem = AutoMapper.Mapper.Map<SeedTray, PlantSeedTray>(item);

            return finalItem;
        }

        protected override PlantSeedTray SelectItem(IUnitOfWork uow, int id)
        {
            // map 
            //SeedTray mappedItem = AutoMapper.Mapper.Map<PlantSeedTray, SeedTray>(requestItem);

            SeedTray item = uow.Repository<SeedTray>().GetItemById(id);

            PlantSeedTray finalItem = AutoMapper.Mapper.Map<SeedTray, PlantSeedTray>(item);

            return finalItem;
        }

        protected override PlantSeedTray UpdateItem(IUnitOfWork uow, PlantSeedTray requestItem)
        {
            // map 
            SeedTray mappedItem = AutoMapper.Mapper.Map<PlantSeedTray, SeedTray>(requestItem);

            SeedTray item = uow.Repository<SeedTray>().Save(mappedItem);

            PlantSeedTray finalItem = AutoMapper.Mapper.Map<SeedTray, PlantSeedTray>(item);

            return finalItem;
        }

        protected override void DeleteItem(IUnitOfWork uow, int id)
        {
            // map 
            //SeedTray mappedItem = AutoMapper.Mapper.Map<PlantSeedTray, SeedTray>(requestItem);

            uow.Repository<SeedTray>().Delete(uow.Repository<SeedTray>().GetItemById(id));
        }

        protected override IList<PlantSeedTray> ListItems(IUnitOfWork uow)
        {
            IList<SeedTray> allItems = uow.Repository<SeedTray>().GetAll();

            IList<PlantSeedTray> items = AutoMapper.Mapper.Map<IList<SeedTray>, IList<PlantSeedTray>>(allItems);

            return items;
        }

    }
}
