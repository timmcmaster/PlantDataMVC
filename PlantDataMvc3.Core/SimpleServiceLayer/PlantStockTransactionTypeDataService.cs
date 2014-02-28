using System;
using System.Collections.Generic;
using System.Linq;
using PlantDataMvc3.Core.DataAccess;
using PlantDataMvc3.Core.Domain.BusinessObjects;
using PlantDataMvc3.DAL.Entities;
using PlantDataMvc3.DAL.Interfaces;

namespace PlantDataMvc3.Core.SimpleServiceLayer
{
    public class PlantStockTransactionTypeDataService : BasicDataService<PlantStockTransactionType>
    {
        public PlantStockTransactionTypeDataService(IUnitOfWorkManager uowManager)
            : base(uowManager)
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
