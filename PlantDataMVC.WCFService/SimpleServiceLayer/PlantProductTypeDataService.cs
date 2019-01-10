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
    public class PlantProductTypeDataService : DataServiceBase<PlantProductType>, IPlantProductTypeDataService
    {
        public PlantProductTypeDataService(IUnitOfWorkAsync uow)
            : base(uow)
        {
        }

        protected override PlantProductType CreateItem(IUnitOfWorkAsync uow, PlantProductType requestItem)
        {
            // map 
            ProductType mappedItem = Mapper.Map<PlantProductType, ProductType>(requestItem);
            ProductType item = uow.Repository<ProductType>().Add(mappedItem);
            // Save changes before we map back
            uow.SaveChanges();
            PlantProductType finalItem = Mapper.Map<ProductType, PlantProductType>(item);

            return finalItem;
        }

        protected override PlantProductType SelectItem(IUnitOfWorkAsync uow, int id)
        {
            // map 
            //ProductType mappedItem = Mapper.Map<PlantProductType, ProductType>(requestItem);
            ProductType item = uow.Repository<ProductType>().GetItemById(id);
            PlantProductType finalItem = Mapper.Map<ProductType, PlantProductType>(item);

            return finalItem;
        }

        protected override PlantProductType UpdateItem(IUnitOfWorkAsync uow, PlantProductType requestItem)
        {
            // map 
            ProductType mappedItem = Mapper.Map<PlantProductType, ProductType>(requestItem);
            ProductType item = uow.Repository<ProductType>().Save(mappedItem);
            // Save changes before we map back
            uow.SaveChanges();
            PlantProductType finalItem = Mapper.Map<ProductType, PlantProductType>(item);

            return finalItem;
        }

        protected override void DeleteItem(IUnitOfWorkAsync uow, int id)
        {
            // map 
            //ProductType mappedItem = Mapper.Map<PlantProductType, ProductType>(requestItem);
            uow.Repository<ProductType>().Delete(uow.Repository<ProductType>().GetItemById(id));
        }

        protected override IList<PlantProductType> ListItems(IUnitOfWorkAsync uow)
        {
            var context = uow.Repository<ProductType>().Queryable();
            IList<PlantProductType> items = context.ProjectTo<PlantProductType>().ToList();

            return items;
        }
    }
}
