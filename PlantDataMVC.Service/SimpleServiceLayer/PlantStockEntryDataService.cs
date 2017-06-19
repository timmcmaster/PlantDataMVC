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
    public class PlantStockEntryDataService : BasicDataService<PlantStockEntry>
    {
        public PlantStockEntryDataService(IUnitOfWork uow)
            : base(uow)
        {
        }

        protected override PlantStockEntry CreateItem(IUnitOfWork uow, PlantStockEntry requestItem)
        {
                // map 
                PlantStock mappedItem = AutoMapper.Mapper.Map<PlantStockEntry, PlantStock>(requestItem);

                PlantStock item = uow.Repository<PlantStock>().Add(mappedItem);

                PlantStockEntry finalItem = AutoMapper.Mapper.Map<PlantStock, PlantStockEntry>(item);

                return finalItem;
        }

        protected override PlantStockEntry SelectItem(IUnitOfWork uow, int id)
        {
                // map 
                //PlantStock mappedItem = AutoMapper.Mapper.Map<PlantStockEntry, PlantStock>(requestItem);

                PlantStock item = uow.Repository<PlantStock>().GetItemById(id);

                PlantStockEntry finalItem = AutoMapper.Mapper.Map<PlantStock, PlantStockEntry>(item);

                return finalItem;
        }

        protected override PlantStockEntry UpdateItem(IUnitOfWork uow, PlantStockEntry requestItem)
        {
            // map 
            PlantStock mappedItem = AutoMapper.Mapper.Map<PlantStockEntry, PlantStock>(requestItem);

            PlantStock item = uow.Repository<PlantStock>().Save(mappedItem);

            PlantStockEntry finalItem = AutoMapper.Mapper.Map<PlantStock, PlantStockEntry>(item);

            return finalItem;
        }

        protected override void DeleteItem(IUnitOfWork uow, int id)
        {
            // map 
            //PlantStock mappedItem = AutoMapper.Mapper.Map<PlantStockEntry, PlantStock>(requestItem);

            uow.Repository<PlantStock>().Delete(uow.Repository<PlantStock>().GetItemById(id));
        }

        protected override IList<PlantStockEntry> ListItems(IUnitOfWork uow)
        {
            IList<PlantStock> allItems = uow.Repository<PlantStock>().GetAll();

            IList<PlantStockEntry> items = AutoMapper.Mapper.Map<IList<PlantStock>, IList<PlantStockEntry>>(allItems);

            return items;
        }
    }
}
