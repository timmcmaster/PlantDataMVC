using System;
using System.Collections.Generic;
using System.Linq;
using PlantDataMVC.Core.DataAccess;
using PlantDataMVC.Core.Domain.BusinessObjects;
using PlantDataMVC.DAL.Entities;
using PlantDataMVC.DAL.Interfaces;

namespace PlantDataMVC.Core.SimpleServiceLayer
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

            SeedTray item = uow.SeedTrayRepository.Add(mappedItem);

            PlantSeedTray finalItem = AutoMapper.Mapper.Map<SeedTray, PlantSeedTray>(item);

            return finalItem;
        }

        protected override PlantSeedTray SelectItem(IUnitOfWork uow, int id)
        {
            // map 
            //SeedTray mappedItem = AutoMapper.Mapper.Map<PlantSeedTray, SeedTray>(requestItem);

            SeedTray item = uow.SeedTrayRepository.GetItemById(id);

            PlantSeedTray finalItem = AutoMapper.Mapper.Map<SeedTray, PlantSeedTray>(item);

            return finalItem;
        }

        protected override PlantSeedTray UpdateItem(IUnitOfWork uow, PlantSeedTray requestItem)
        {
            // map 
            SeedTray mappedItem = AutoMapper.Mapper.Map<PlantSeedTray, SeedTray>(requestItem);

            SeedTray item = uow.SeedTrayRepository.Save(mappedItem);

            PlantSeedTray finalItem = AutoMapper.Mapper.Map<SeedTray, PlantSeedTray>(item);

            return finalItem;
        }

        protected override void DeleteItem(IUnitOfWork uow, int id)
        {
            // map 
            //SeedTray mappedItem = AutoMapper.Mapper.Map<PlantSeedTray, SeedTray>(requestItem);

            uow.SeedTrayRepository.Delete(uow.SeedTrayRepository.GetItemById(id));
        }

        protected override IList<PlantSeedTray> ListItems(IUnitOfWork uow)
        {
            IList<SeedTray> allItems = uow.SeedTrayRepository.GetAll();

            IList<PlantSeedTray> items = AutoMapper.Mapper.Map<IList<SeedTray>, IList<PlantSeedTray>>(allItems);

            return items;
        }

    }
}
