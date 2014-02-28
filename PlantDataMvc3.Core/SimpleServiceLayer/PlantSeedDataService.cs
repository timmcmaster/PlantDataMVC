using System;
using System.Collections.Generic;
using System.Linq;
using PlantDataMvc3.Core.DataAccess;
using PlantDataMvc3.Core.Domain.BusinessObjects;
using PlantDataMvc3.DAL.Entities;
using PlantDataMvc3.DAL.Interfaces;

namespace PlantDataMvc3.Core.SimpleServiceLayer
{
    public class PlantSeedDataService : BasicDataService<PlantSeed>
    {
        public PlantSeedDataService(IUnitOfWorkManager uowManager)
            : base(uowManager)
        {
        }

        protected override PlantSeed CreateItem(IUnitOfWork uow, PlantSeed requestItem)
        {
            // map 
            SeedBatch mappedItem = AutoMapper.Mapper.Map<PlantSeed, SeedBatch>(requestItem);

            SeedBatch item = uow.SeedBatchRepository.Add(mappedItem);

            PlantSeed finalItem = AutoMapper.Mapper.Map<SeedBatch, PlantSeed>(item);

            return finalItem;
        }

        protected override PlantSeed SelectItem(IUnitOfWork uow, int id)
        {
            // map 
            //SeedBatch mappedItem = AutoMapper.Mapper.Map<PlantSeed, SeedBatch>(requestItem);

            SeedBatch item = uow.SeedBatchRepository.GetItemById(id);

            PlantSeed finalItem = AutoMapper.Mapper.Map<SeedBatch, PlantSeed>(item);

            return finalItem;
        }

        protected override PlantSeed UpdateItem(IUnitOfWork uow, PlantSeed requestItem)
        {
            // map 
            SeedBatch mappedItem = AutoMapper.Mapper.Map<PlantSeed, SeedBatch>(requestItem);

            SeedBatch item = uow.SeedBatchRepository.Save(mappedItem);

            PlantSeed finalItem = AutoMapper.Mapper.Map<SeedBatch, PlantSeed>(item);

            return finalItem;
        }

        protected override void DeleteItem(IUnitOfWork uow, int id)
        {
            // map 
            //SeedBatch mappedItem = AutoMapper.Mapper.Map<PlantSeed, SeedBatch>(requestItem);

            uow.SeedBatchRepository.Delete(uow.SeedBatchRepository.GetItemById(id));
        }

        protected override IList<PlantSeed> ListItems(IUnitOfWork uow)
        {
            IList<SeedBatch> allItems = uow.SeedBatchRepository.GetAll();

            IList<PlantSeed> items = AutoMapper.Mapper.Map<IList<SeedBatch>, IList<PlantSeed>>(allItems);

            return items;
        }
    }
}
