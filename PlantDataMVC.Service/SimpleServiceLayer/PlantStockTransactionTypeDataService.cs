﻿using AutoMapper;
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
    public class PlantStockTransactionTypeDataService : DataServiceBase<PlantStockTransactionType>, IPlantStockTransactionTypeDataService
    {
        public PlantStockTransactionTypeDataService(IUnitOfWorkAsync uow)
            : base(uow)
        {
        }

        protected override PlantStockTransactionType CreateItem(IUnitOfWorkAsync uow, PlantStockTransactionType requestItem)
        {
            // map 
            JournalEntryType mappedItem = Mapper.Map<PlantStockTransactionType, JournalEntryType>(requestItem);
            JournalEntryType item = uow.Repository<JournalEntryType>().Add(mappedItem);
            // Save changes before we map back
            uow.SaveChanges();
            PlantStockTransactionType finalItem = Mapper.Map<JournalEntryType, PlantStockTransactionType>(item);

            return finalItem;
        }

        protected override PlantStockTransactionType SelectItem(IUnitOfWorkAsync uow, int id)
        {
            // map 
            //JournalEntryType mappedItem = Mapper.Map<PlantStockTransactionType, JournalEntryType>(requestItem);
            JournalEntryType item = uow.Repository<JournalEntryType>().GetItemById(id);
            PlantStockTransactionType finalItem = Mapper.Map<JournalEntryType, PlantStockTransactionType>(item);

            return finalItem;
        }

        protected override PlantStockTransactionType UpdateItem(IUnitOfWorkAsync uow, PlantStockTransactionType requestItem)
        {
            // map 
            JournalEntryType mappedItem = Mapper.Map<PlantStockTransactionType, JournalEntryType>(requestItem);
            JournalEntryType item = uow.Repository<JournalEntryType>().Save(mappedItem);
            // Save changes before we map back
            uow.SaveChanges();
            PlantStockTransactionType finalItem = Mapper.Map<JournalEntryType, PlantStockTransactionType>(item);

            return finalItem;
        }

        protected override void DeleteItem(IUnitOfWorkAsync uow, int id)
        {
            // map 
            //JournalEntryType mappedItem = Mapper.Map<PlantStockTransactionType, JournalEntryType>(requestItem);
            uow.Repository<JournalEntryType>().Delete(uow.Repository<JournalEntryType>().GetItemById(id));
        }

        protected override IList<PlantStockTransactionType> ListItems(IUnitOfWorkAsync uow)
        {
            var context = uow.Repository<JournalEntryType>().Queryable();
            IList<PlantStockTransactionType> items = context.ProjectTo<PlantStockTransactionType>().ToList();

            return items;
        }
    }
}
