using System;
using System.Collections.Generic;
using System.Linq;
using PlantDataMvc3.Core.DataAccess;
using PlantDataMvc3.Core.Domain.BusinessObjects;
using PlantDataMvc3.DAL.Entities;
using PlantDataMvc3.DAL.Interfaces;

namespace PlantDataMvc3.Core.SimpleServiceLayer
{
    public class PlantSeedTrayDataService : BasicDataService<PlantSeedTray>
    {
        public PlantSeedTrayDataService(IUnitOfWorkManager uowManager)
            : base(uowManager)
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
