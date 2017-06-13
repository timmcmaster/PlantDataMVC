using System;
using System.Collections.Generic;
using System.Linq;
using PlantDataMVC.Core.DataAccess;
using PlantDataMVC.Core.Domain.BusinessObjects;
using PlantDataMVC.DAL.Entities;
using PlantDataMVC.DAL.Interfaces;

namespace PlantDataMVC.Core.SimpleServiceLayer
{
    public class PlantStockTransactionTypeDataService : BasicDataService<PlantStockTransactionType>
    {
        public PlantStockTransactionTypeDataService(IUnitOfWork uow)
            : base(uow)
        {
        }

        protected override PlantStockTransactionType CreateItem(IUnitOfWork uow, PlantStockTransactionType requestItem)
        {
            // map 
            JournalEntryType mappedItem = AutoMapper.Mapper.Map<PlantStockTransactionType, JournalEntryType>(requestItem);

            JournalEntryType item = uow.JournalEntryTypeRepository.Add(mappedItem);

            PlantStockTransactionType finalItem = AutoMapper.Mapper.Map<JournalEntryType, PlantStockTransactionType>(item);

            return finalItem;
        }

        protected override PlantStockTransactionType SelectItem(IUnitOfWork uow, int id)
        {
            // map 
            //JournalEntryType mappedItem = AutoMapper.Mapper.Map<PlantStockTransactionType, JournalEntryType>(requestItem);

            JournalEntryType item = uow.JournalEntryTypeRepository.GetItemById(id);

            PlantStockTransactionType finalItem = AutoMapper.Mapper.Map<JournalEntryType, PlantStockTransactionType>(item);

            return finalItem;
        }

        protected override PlantStockTransactionType UpdateItem(IUnitOfWork uow, PlantStockTransactionType requestItem)
        {
            // map 
            JournalEntryType mappedItem = AutoMapper.Mapper.Map<PlantStockTransactionType, JournalEntryType>(requestItem);

            JournalEntryType item = uow.JournalEntryTypeRepository.Save(mappedItem);

            PlantStockTransactionType finalItem = AutoMapper.Mapper.Map<JournalEntryType, PlantStockTransactionType>(item);

            return finalItem;
        }

        protected override void DeleteItem(IUnitOfWork uow, int id)
        {
            // map 
            //JournalEntryType mappedItem = AutoMapper.Mapper.Map<PlantStockTransactionType, JournalEntryType>(requestItem);

            uow.JournalEntryTypeRepository.Delete(uow.JournalEntryTypeRepository.GetItemById(id));
        }

        protected override IList<PlantStockTransactionType> ListItems(IUnitOfWork uow)
        {
            IList<JournalEntryType> allItems = uow.JournalEntryTypeRepository.GetAll();

            IList<PlantStockTransactionType> items = AutoMapper.Mapper.Map<IList<JournalEntryType>, IList<PlantStockTransactionType>>(allItems);

            return items;
        }

    }
}
