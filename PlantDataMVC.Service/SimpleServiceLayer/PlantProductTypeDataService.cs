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
    public class PlantProductTypeDataService : BasicDataService<PlantProductType>
    {
        public PlantProductTypeDataService(IUnitOfWork uow)
            : base(uow)
        {
        }

        protected override PlantProductType CreateItem(IUnitOfWork uow, PlantProductType requestItem)
        {
            // map 
            ProductType mappedItem = AutoMapper.Mapper.Map<PlantProductType, ProductType>(requestItem);

            ProductType item = uow.Repository<ProductType>().Add(mappedItem);

            PlantProductType finalItem = AutoMapper.Mapper.Map<ProductType, PlantProductType>(item);

            return finalItem;
        }

        protected override PlantProductType SelectItem(IUnitOfWork uow, int id)
        {
            // map 
            //ProductType mappedItem = AutoMapper.Mapper.Map<PlantProductType, ProductType>(requestItem);

            ProductType item = uow.Repository<ProductType>().GetItemById(id);

            PlantProductType finalItem = AutoMapper.Mapper.Map<ProductType, PlantProductType>(item);

            return finalItem;
        }

        protected override PlantProductType UpdateItem(IUnitOfWork uow, PlantProductType requestItem)
        {
            // map 
            ProductType mappedItem = AutoMapper.Mapper.Map<PlantProductType, ProductType>(requestItem);

            ProductType item = uow.Repository<ProductType>().Save(mappedItem);

            PlantProductType finalItem = AutoMapper.Mapper.Map<ProductType, PlantProductType>(item);

            return finalItem;
        }

        protected override void DeleteItem(IUnitOfWork uow, int id)
        {
            // map 
            //ProductType mappedItem = AutoMapper.Mapper.Map<PlantProductType, ProductType>(requestItem);

            uow.Repository<ProductType>().Delete(uow.Repository<ProductType>().GetItemById(id));
        }

        protected override IList<PlantProductType> ListItems(IUnitOfWork uow)
        {
            IList<ProductType> allItems = uow.Repository<ProductType>().GetAll();

            IList<PlantProductType> items = AutoMapper.Mapper.Map<IList<ProductType>, IList<PlantProductType>>(allItems);

            return items;
        }
    }
}
