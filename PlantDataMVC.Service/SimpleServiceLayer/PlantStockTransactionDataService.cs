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
    public class PlantStockTransactionDataService : BasicDataService<PlantStockTransaction>
    {
        public PlantStockTransactionDataService(IUnitOfWorkAsync uow)
            : base(uow)
        {
        }

        protected override PlantStockTransaction CreateItem(IUnitOfWorkAsync uow, PlantStockTransaction requestItem)
        {
            // map 
            JournalEntry mappedItem = AutoMapper.Mapper.Map<PlantStockTransaction, JournalEntry>(requestItem);

            JournalEntry item = uow.Repository<JournalEntry>().Add(mappedItem);

            PlantStockTransaction finalItem = AutoMapper.Mapper.Map<JournalEntry, PlantStockTransaction>(item);

            return finalItem;
        }

        protected override PlantStockTransaction SelectItem(IUnitOfWorkAsync uow, int id)
        {
            // map 
            //JournalEntry mappedItem = AutoMapper.Mapper.Map<PlantStockTransaction, JournalEntry>(requestItem);

            JournalEntry item = uow.Repository<JournalEntry>().GetItemById(id);

            PlantStockTransaction finalItem = AutoMapper.Mapper.Map<JournalEntry, PlantStockTransaction>(item);

            return finalItem;
        }

        protected override PlantStockTransaction UpdateItem(IUnitOfWorkAsync uow, PlantStockTransaction requestItem)
        {
            // map 
            JournalEntry mappedItem = AutoMapper.Mapper.Map<PlantStockTransaction, JournalEntry>(requestItem);

            JournalEntry item = uow.Repository<JournalEntry>().Save(mappedItem);

            PlantStockTransaction finalItem = AutoMapper.Mapper.Map<JournalEntry, PlantStockTransaction>(item);

            return finalItem;
        }

        protected override void DeleteItem(IUnitOfWorkAsync uow, int id)
        {
            // map 
            //JournalEntry mappedItem = AutoMapper.Mapper.Map<PlantStockTransaction, JournalEntry>(requestItem);

            uow.Repository<JournalEntry>().Delete(uow.Repository<JournalEntry>().GetItemById(id));
        }

        protected override IList<PlantStockTransaction> ListItems(IUnitOfWorkAsync uow)
        {
            IList<JournalEntry> allItems = uow.Repository<JournalEntry>().GetAll();

            IList<PlantStockTransaction> items = AutoMapper.Mapper.Map<IList<JournalEntry>, IList<PlantStockTransaction>>(allItems);

            return items;
        }
    }
}
