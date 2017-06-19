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
    public class PlantSeedDataService : BasicDataService<PlantSeed>
    {
        public PlantSeedDataService(IUnitOfWork uow)
            : base(uow)
        {
        }

        protected override PlantSeed CreateItem(IUnitOfWork uow, PlantSeed requestItem)
        {
            // map 
            SeedBatch mappedItem = AutoMapper.Mapper.Map<PlantSeed, SeedBatch>(requestItem);

            SeedBatch item = uow.Repository<SeedBatch>().Add(mappedItem);

            PlantSeed finalItem = AutoMapper.Mapper.Map<SeedBatch, PlantSeed>(item);

            return finalItem;
        }

        protected override PlantSeed SelectItem(IUnitOfWork uow, int id)
        {
            // map 
            //SeedBatch mappedItem = AutoMapper.Mapper.Map<PlantSeed, SeedBatch>(requestItem);

            SeedBatch item = uow.Repository<SeedBatch>().GetItemById(id);

            PlantSeed finalItem = AutoMapper.Mapper.Map<SeedBatch, PlantSeed>(item);

            return finalItem;
        }

        protected override PlantSeed UpdateItem(IUnitOfWork uow, PlantSeed requestItem)
        {
            // map 
            SeedBatch mappedItem = AutoMapper.Mapper.Map<PlantSeed, SeedBatch>(requestItem);

            SeedBatch item = uow.Repository<SeedBatch>().Save(mappedItem);

            PlantSeed finalItem = AutoMapper.Mapper.Map<SeedBatch, PlantSeed>(item);

            return finalItem;
        }

        protected override void DeleteItem(IUnitOfWork uow, int id)
        {
            // map 
            //SeedBatch mappedItem = AutoMapper.Mapper.Map<PlantSeed, SeedBatch>(requestItem);

            uow.Repository<SeedBatch>().Delete(uow.Repository<SeedBatch>().GetItemById(id));
        }

        protected override IList<PlantSeed> ListItems(IUnitOfWork uow)
        {
            IList<SeedBatch> allItems = uow.Repository<SeedBatch>().GetAll();

            IList<PlantSeed> items = AutoMapper.Mapper.Map<IList<SeedBatch>, IList<PlantSeed>>(allItems);

            return items;
        }
    }
}
