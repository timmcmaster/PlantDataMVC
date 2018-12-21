using AutoMapper;
using Framework.Service;
using Interfaces.DAL.UnitOfWork;
using PlantDataMVC.Domain.Entities;
using PlantDataMVC.Entities.Models;
using PlantDataMVC.Repository.Repositories;
using PlantDataMVC.Service.ServiceContracts;
using System;
using System.Collections.Generic;

namespace PlantDataMVC.Service.SimpleServiceLayer
{
    public class PlantStockEntryDataService : DataServiceBase<PlantStockEntry>, IPlantStockEntryDataService
    {
        public PlantStockEntryDataService(IUnitOfWorkAsync uow)
            : base(uow)
        {
        }

        protected override PlantStockEntry CreateItem(IUnitOfWorkAsync uow, PlantStockEntry requestItem)
        {
            // TODO: We probably shouldn't create a stock level, but instead generate it from a transaction
            //       Or else, only create with 0 stock

            // map 
            PlantStock mappedItem = Mapper.Map<PlantStockEntry, PlantStock>(requestItem);
            PlantStock item = uow.Repository<PlantStock>().Add(mappedItem);
            // Save changes before we map back
            uow.SaveChanges();
            PlantStockEntry finalItem = Mapper.Map<PlantStock, PlantStockEntry>(item);

            return finalItem;
        }

        protected override PlantStockEntry SelectItem(IUnitOfWorkAsync uow, int id)
        {
            // map 
            //PlantStock mappedItem = Mapper.Map<PlantStockEntry, PlantStock>(requestItem);
            PlantStock item = uow.Repository<PlantStock>().GetItemById(id);
            PlantStockEntry finalItem = Mapper.Map<PlantStock, PlantStockEntry>(item);

            return finalItem;
        }

        protected override PlantStockEntry UpdateItem(IUnitOfWorkAsync uow, PlantStockEntry requestItem)
        {
            // map 
            PlantStock mappedItem = Mapper.Map<PlantStockEntry, PlantStock>(requestItem);

            // TODO: If we update a stock level, we should not change the record directly but:
            //       - generate an adjustment transaction (new qty - current qty) and 
            //       - recalculate stock levels for this item ID

            // HACK: Do it locally, but probably want at lower level
            try
            {
                uow.BeginTransaction();

                var currentStockItem = uow.Repository<PlantStock>().GetItemById(mappedItem.Id);
                var stockChange = mappedItem.QuantityInStock - currentStockItem.QuantityInStock;

                if (stockChange != 0)
                {
                    // Create new transaction
                    var adjustmentTransaction = new JournalEntry
                    {
                        JournalEntryTypeId = 9,
                        PlantStockId = currentStockItem.Id,
                        Quantity = stockChange,
                        Notes = "Automatic adjustment transaction",
                        TransactionDate = System.DateTime.Now,
                        SeedTrayId = null,
                        Source = "My Adjustment"
                    };

                    var adjustedItem = uow.Repository<JournalEntry>().Add(adjustmentTransaction);

                    // Save changes before we recalculate
                    uow.SaveChanges();
                }

                // Recalculate stock
                var stockTotal = uow.Repository<JournalEntry>().GetStockCountForProduct(currentStockItem.Id);

                // Set and save new stock value
                mappedItem.QuantityInStock = stockTotal;

                PlantStock item = uow.Repository<PlantStock>().Save(mappedItem);
                // Save changes before we map back
                uow.SaveChanges();

                uow.Commit();

                PlantStockEntry finalItem = Mapper.Map<PlantStock, PlantStockEntry>(item);

                return finalItem;
            }
            catch (Exception)
            {
                uow.Rollback();
            }

            return null;
        }

        protected override void DeleteItem(IUnitOfWorkAsync uow, int id)
        {
            // TODO: Should stock level be deletable?

            // map 
            //PlantStock mappedItem = Mapper.Map<PlantStockEntry, PlantStock>(requestItem);
            uow.Repository<PlantStock>().Delete(uow.Repository<PlantStock>().GetItemById(id));
        }

        protected override IList<PlantStockEntry> ListItems(IUnitOfWorkAsync uow)
        {
            //var context = uow.Repository<PlantStock>().Queryable();
            //// TODO: This projection fails on use of Binomial calculated property
            //IList<PlantStockEntry> items = context.ProjectTo<PlantStockEntry>().ToList();

            IList<PlantStock> allItems = uow.Repository<PlantStock>().GetAll();
            IList<PlantStockEntry> items = Mapper.Map<IList<PlantStock>, IList<PlantStockEntry>>(allItems);

            return items;
        }
    }
}
