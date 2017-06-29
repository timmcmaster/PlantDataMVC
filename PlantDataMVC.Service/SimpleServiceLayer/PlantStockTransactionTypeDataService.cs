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
    public class PlantStockTransactionTypeDataService : BasicDataService<PlantStockTransactionType>
    {
        public PlantStockTransactionTypeDataService(IUnitOfWorkAsync uow)
            : base(uow)
        {
        }

        protected override PlantStockTransactionType CreateItem(IUnitOfWorkAsync uow, PlantStockTransactionType requestItem)
        {
            // map 
            JournalEntryType mappedItem = AutoMapper.Mapper.Map<PlantStockTransactionType, JournalEntryType>(requestItem);

            JournalEntryType item = uow.Repository<JournalEntryType>().Add(mappedItem);

            PlantStockTransactionType finalItem = AutoMapper.Mapper.Map<JournalEntryType, PlantStockTransactionType>(item);

            return finalItem;
        }

        protected override PlantStockTransactionType SelectItem(IUnitOfWorkAsync uow, int id)
        {
            // map 
            //JournalEntryType mappedItem = AutoMapper.Mapper.Map<PlantStockTransactionType, JournalEntryType>(requestItem);

            JournalEntryType item = uow.Repository<JournalEntryType>().GetItemById(id);

            PlantStockTransactionType finalItem = AutoMapper.Mapper.Map<JournalEntryType, PlantStockTransactionType>(item);

            return finalItem;
        }

        protected override PlantStockTransactionType UpdateItem(IUnitOfWorkAsync uow, PlantStockTransactionType requestItem)
        {
            // map 
            JournalEntryType mappedItem = AutoMapper.Mapper.Map<PlantStockTransactionType, JournalEntryType>(requestItem);

            JournalEntryType item = uow.Repository<JournalEntryType>().Save(mappedItem);

            PlantStockTransactionType finalItem = AutoMapper.Mapper.Map<JournalEntryType, PlantStockTransactionType>(item);

            return finalItem;
        }

        protected override void DeleteItem(IUnitOfWorkAsync uow, int id)
        {
            // map 
            //JournalEntryType mappedItem = AutoMapper.Mapper.Map<PlantStockTransactionType, JournalEntryType>(requestItem);

            uow.Repository<JournalEntryType>().Delete(uow.Repository<JournalEntryType>().GetItemById(id));
        }

        protected override IList<PlantStockTransactionType> ListItems(IUnitOfWorkAsync uow)
        {
            IList<JournalEntryType> allItems = uow.Repository<JournalEntryType>().GetAll();

            IList<PlantStockTransactionType> items = AutoMapper.Mapper.Map<IList<JournalEntryType>, IList<PlantStockTransactionType>>(allItems);

            return items;
        }

    }
}
