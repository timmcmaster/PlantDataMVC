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
    public class PlantSeedDataService : BasicDataService<PlantSeed>
    {
        public PlantSeedDataService(IUnitOfWorkAsync uow)
            : base(uow)
        {
        }

        protected override PlantSeed CreateItem(IUnitOfWorkAsync uow, PlantSeed requestItem)
        {
            // map 
            SeedBatch mappedItem = AutoMapper.Mapper.Map<PlantSeed, SeedBatch>(requestItem);

            SeedBatch item = uow.Repository<SeedBatch>().Add(mappedItem);

            PlantSeed finalItem = AutoMapper.Mapper.Map<SeedBatch, PlantSeed>(item);

            return finalItem;
        }

        protected override PlantSeed SelectItem(IUnitOfWorkAsync uow, int id)
        {
            // map 
            //SeedBatch mappedItem = AutoMapper.Mapper.Map<PlantSeed, SeedBatch>(requestItem);

            SeedBatch item = uow.Repository<SeedBatch>().GetItemById(id);

            PlantSeed finalItem = AutoMapper.Mapper.Map<SeedBatch, PlantSeed>(item);

            return finalItem;
        }

        protected override PlantSeed UpdateItem(IUnitOfWorkAsync uow, PlantSeed requestItem)
        {
            // map 
            SeedBatch mappedItem = AutoMapper.Mapper.Map<PlantSeed, SeedBatch>(requestItem);

            SeedBatch item = uow.Repository<SeedBatch>().Save(mappedItem);

            PlantSeed finalItem = AutoMapper.Mapper.Map<SeedBatch, PlantSeed>(item);

            return finalItem;
        }

        protected override void DeleteItem(IUnitOfWorkAsync uow, int id)
        {
            // map 
            //SeedBatch mappedItem = AutoMapper.Mapper.Map<PlantSeed, SeedBatch>(requestItem);

            uow.Repository<SeedBatch>().Delete(uow.Repository<SeedBatch>().GetItemById(id));
        }

        protected override IList<PlantSeed> ListItems(IUnitOfWorkAsync uow)
        {
            IList<SeedBatch> allItems = uow.Repository<SeedBatch>().GetAll();

            IList<PlantSeed> items = AutoMapper.Mapper.Map<IList<SeedBatch>, IList<PlantSeed>>(allItems);

            return items;
        }
    }
}