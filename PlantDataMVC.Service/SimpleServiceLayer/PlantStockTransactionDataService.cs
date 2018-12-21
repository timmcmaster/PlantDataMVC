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
    public class PlantStockTransactionDataService : DataServiceBase<PlantStockTransaction>, IPlantStockTransactionDataService
    {
        public PlantStockTransactionDataService(IUnitOfWorkAsync uow)
            : base(uow)
        {
        }

        protected override PlantStockTransaction CreateItem(IUnitOfWorkAsync uow, PlantStockTransaction requestItem)
        {
            // TODO: When we create a transaction, create stock record for this item type (if none exists)

            // TODO: When we create a transaction, recalculate stock for this item type
            //       Best done as total of transactions, rather than adjustment to stock level


            
            // map 
            JournalEntry mappedItem = Mapper.Map<PlantStockTransaction, JournalEntry>(requestItem);
            JournalEntry item = uow.Repository<JournalEntry>().Add(mappedItem);

            // Save changes before we map back
            uow.SaveChanges();
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
            // TODO: Should transactions be updatable?

            // map 
            JournalEntry mappedItem = Mapper.Map<PlantStockTransaction, JournalEntry>(requestItem);
            JournalEntry item = uow.Repository<JournalEntry>().Save(mappedItem);
            // Save changes before we map back
            uow.SaveChanges();
            PlantStockTransaction finalItem = Mapper.Map<JournalEntry, PlantStockTransaction>(item);

            return finalItem;
        }

        protected override void DeleteItem(IUnitOfWorkAsync uow, int id)
        {
            // TODO: Should transactions be deletable?

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
