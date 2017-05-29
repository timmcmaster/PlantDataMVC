using System;
using System.Collections.Generic;
using System.Linq;
using PlantDataMVC.Core.DataAccess;
using PlantDataMVC.Core.Domain.BusinessObjects;
using PlantDataMVC.DAL.Entities;
using PlantDataMVC.DAL.Interfaces;

namespace PlantDataMVC.Core.SimpleServiceLayer
{
    public class PlantStockEntryDataService : BasicDataService<PlantStockEntry>
    {
        public PlantStockEntryDataService(IUnitOfWorkManager uowManager)
            : base(uowManager)
        {
        }

        protected override PlantStockEntry CreateItem(IUnitOfWork uow, PlantStockEntry requestItem)
        {
                // map 
                PlantStock mappedItem = AutoMapper.Mapper.Map<PlantStockEntry, PlantStock>(requestItem);

                PlantStock item = uow.PlantStockRepository.Add(mappedItem);

                PlantStockEntry finalItem = AutoMapper.Mapper.Map<PlantStock, PlantStockEntry>(item);

                return finalItem;
        }

        protected override PlantStockEntry SelectItem(IUnitOfWork uow, int id)
        {
                // map 
                //PlantStock mappedItem = AutoMapper.Mapper.Map<PlantStockEntry, PlantStock>(requestItem);

                PlantStock item = uow.PlantStockRepository.GetItemById(id);

                PlantStockEntry finalItem = AutoMapper.Mapper.Map<PlantStock, PlantStockEntry>(item);

                return finalItem;
        }

        protected override PlantStockEntry UpdateItem(IUnitOfWork uow, PlantStockEntry requestItem)
        {
            // map 
            PlantStock mappedItem = AutoMapper.Mapper.Map<PlantStockEntry, PlantStock>(requestItem);

            PlantStock item = uow.PlantStockRepository.Save(mappedItem);

            PlantStockEntry finalItem = AutoMapper.Mapper.Map<PlantStock, PlantStockEntry>(item);

            return finalItem;
        }

        protected override void DeleteItem(IUnitOfWork uow, int id)
        {
            // map 
            //PlantStock mappedItem = AutoMapper.Mapper.Map<PlantStockEntry, PlantStock>(requestItem);

            uow.PlantStockRepository.Delete(uow.PlantStockRepository.GetItemById(id));
        }

        protected override IList<PlantStockEntry> ListItems(IUnitOfWork uow)
        {
            IList<PlantStock> allItems = uow.PlantStockRepository.GetAll();

            IList<PlantStockEntry> items = AutoMapper.Mapper.Map<IList<PlantStock>, IList<PlantStockEntry>>(allItems);

            return items;
        }
    }
}
