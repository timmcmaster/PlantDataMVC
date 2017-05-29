using System;
using System.Collections.Generic;
using System.Linq;
using PlantDataMVC.Core.DataAccess;
using PlantDataMVC.Core.Domain.BusinessObjects;
using PlantDataMVC.DAL.Entities;
using PlantDataMVC.DAL.Interfaces;

namespace PlantDataMVC.Core.SimpleServiceLayer
{
    public class PlantStockTransactionDataService : BasicDataService<PlantStockTransaction>
    {
        public PlantStockTransactionDataService(IUnitOfWorkManager uowManager)
            : base(uowManager)
        {
        }

        protected override PlantStockTransaction CreateItem(IUnitOfWork uow, PlantStockTransaction requestItem)
        {
            // map 
            JournalEntry mappedItem = AutoMapper.Mapper.Map<PlantStockTransaction, JournalEntry>(requestItem);

            JournalEntry item = uow.JournalEntryRepository.Add(mappedItem);

            PlantStockTransaction finalItem = AutoMapper.Mapper.Map<JournalEntry, PlantStockTransaction>(item);

            return finalItem;
        }

        protected override PlantStockTransaction SelectItem(IUnitOfWork uow, int id)
        {
            // map 
            //JournalEntry mappedItem = AutoMapper.Mapper.Map<PlantStockTransaction, JournalEntry>(requestItem);

            JournalEntry item = uow.JournalEntryRepository.GetItemById(id);

            PlantStockTransaction finalItem = AutoMapper.Mapper.Map<JournalEntry, PlantStockTransaction>(item);

            return finalItem;
        }

        protected override PlantStockTransaction UpdateItem(IUnitOfWork uow, PlantStockTransaction requestItem)
        {
            // map 
            JournalEntry mappedItem = AutoMapper.Mapper.Map<PlantStockTransaction, JournalEntry>(requestItem);

            JournalEntry item = uow.JournalEntryRepository.Save(mappedItem);

            PlantStockTransaction finalItem = AutoMapper.Mapper.Map<JournalEntry, PlantStockTransaction>(item);

            return finalItem;
        }

        protected override void DeleteItem(IUnitOfWork uow, int id)
        {
            // map 
            //JournalEntry mappedItem = AutoMapper.Mapper.Map<PlantStockTransaction, JournalEntry>(requestItem);

            uow.JournalEntryRepository.Delete(uow.JournalEntryRepository.GetItemById(id));
        }

        protected override IList<PlantStockTransaction> ListItems(IUnitOfWork uow)
        {
            IList<JournalEntry> allItems = uow.JournalEntryRepository.GetAll();

            IList<PlantStockTransaction> items = AutoMapper.Mapper.Map<IList<JournalEntry>, IList<PlantStockTransaction>>(allItems);

            return items;
        }
    }
}
