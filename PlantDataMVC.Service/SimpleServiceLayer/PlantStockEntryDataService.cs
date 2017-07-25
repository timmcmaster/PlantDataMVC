using AutoMapper;
using AutoMapper.QueryableExtensions;
using Framework.DAL.UnitOfWork;
using Framework.Service.ServiceLayer;
using PlantDataMVC.Domain.Entities;
using PlantDataMVC.Entities.Models;
using System.Collections.Generic;
using System.Linq;

namespace PlantDataMVC.Service.SimpleServiceLayer
{
    public class PlantStockEntryDataService : BasicDataService<PlantStockEntry>
    {
        public PlantStockEntryDataService(IUnitOfWorkAsync uow)
            : base(uow)
        {
        }

        protected override PlantStockEntry CreateItem(IUnitOfWorkAsync uow, PlantStockEntry requestItem)
        {
                // map 
                PlantStock mappedItem = Mapper.Map<PlantStockEntry, PlantStock>(requestItem);
                PlantStock item = uow.Repository<PlantStock>().Add(mappedItem);
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
            PlantStock item = uow.Repository<PlantStock>().Save(mappedItem);
            PlantStockEntry finalItem = Mapper.Map<PlantStock, PlantStockEntry>(item);

            return finalItem;
        }

        protected override void DeleteItem(IUnitOfWorkAsync uow, int id)
        {
            // map 
            //PlantStock mappedItem = Mapper.Map<PlantStockEntry, PlantStock>(requestItem);
            uow.Repository<PlantStock>().Delete(uow.Repository<PlantStock>().GetItemById(id));
        }

        protected override IList<PlantStockEntry> ListItems(IUnitOfWorkAsync uow)
        {
            var context = uow.Repository<PlantStock>().Queryable();
            IList<PlantStockEntry> items = context.ProjectTo<PlantStockEntry>().ToList();

            return items;
        }
    }
}
