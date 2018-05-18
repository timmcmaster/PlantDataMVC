using AutoMapper;
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
    public class PlantStockTransactionDataService : BasicDataService<PlantStockTransaction>, IPlantStockTransactionDataService
    {
        public PlantStockTransactionDataService(IUnitOfWorkAsync uow)
            : base(uow)
        {
        }

        protected override PlantStockTransaction CreateItem(IUnitOfWorkAsync uow, PlantStockTransaction requestItem)
        {
            // map 
            JournalEntry mappedItem = Mapper.Map<PlantStockTransaction, JournalEntry>(requestItem);
            JournalEntry item = uow.Repository<JournalEntry>().Add(mappedItem);
            PlantStockTransaction finalItem = Mapper.Map<JournalEntry, PlantStockTransaction>(item);

            return finalItem;
        }

        protected override PlantStockTransaction SelectItem(IUnitOfWorkAsync uow, int id)
        {
            // map 
            //JournalEntry mappedItem = Mapper.Map<PlantStockTransaction, JournalEntry>(requestItem);
            JournalEntry item = uow.Repository<JournalEntry>().GetItemById(id);
            PlantStockTransaction finalItem = Mapper.Map<JournalEntry, PlantStockTransaction>(item);

            return finalItem;
        }

        protected override PlantStockTransaction UpdateItem(IUnitOfWorkAsync uow, PlantStockTransaction requestItem)
        {
            // map 
            JournalEntry mappedItem = Mapper.Map<PlantStockTransaction, JournalEntry>(requestItem);
            JournalEntry item = uow.Repository<JournalEntry>().Save(mappedItem);
            PlantStockTransaction finalItem = Mapper.Map<JournalEntry, PlantStockTransaction>(item);

            return finalItem;
        }

        protected override void DeleteItem(IUnitOfWorkAsync uow, int id)
        {
            // map 
            //JournalEntry mappedItem = Mapper.Map<PlantStockTransaction, JournalEntry>(requestItem);
            uow.Repository<JournalEntry>().Delete(uow.Repository<JournalEntry>().GetItemById(id));
        }

        protected override IList<PlantStockTransaction> ListItems(IUnitOfWorkAsync uow)
        {
            var context = uow.Repository<JournalEntry>().Queryable();
            IList<PlantStockTransaction> items = context.ProjectTo<PlantStockTransaction>().ToList();

            return items;
        }
    }
}
