using System;
using System.Collections.Generic;
using System.Linq;
using PlantDataMvc3.Core.DataAccess;
using PlantDataMvc3.Core.Domain.BusinessObjects;
using PlantDataMVC.DAL.Entities;
using PlantDataMVC.DAL.Interfaces;

namespace PlantDataMvc3.Core.SimpleServiceLayer
{
    public class PlantProductTypeDataService : BasicDataService<PlantProductType>
    {
        public PlantProductTypeDataService(IUnitOfWorkManager uowManager)
            : base(uowManager)
        {
        }

        protected override PlantProductType CreateItem(IUnitOfWork uow, PlantProductType requestItem)
        {
            // map 
            ProductType mappedItem = AutoMapper.Mapper.Map<PlantProductType, ProductType>(requestItem);

            ProductType item = uow.ProductTypeRepository.Add(mappedItem);

            PlantProductType finalItem = AutoMapper.Mapper.Map<ProductType, PlantProductType>(item);

            return finalItem;
        }

        protected override PlantProductType SelectItem(IUnitOfWork uow, int id)
        {
            // map 
            //ProductType mappedItem = AutoMapper.Mapper.Map<PlantProductType, ProductType>(requestItem);

            ProductType item = uow.ProductTypeRepository.GetItemById(id);

            PlantProductType finalItem = AutoMapper.Mapper.Map<ProductType, PlantProductType>(item);

            return finalItem;
        }

        protected override PlantProductType UpdateItem(IUnitOfWork uow, PlantProductType requestItem)
        {
            // map 
            ProductType mappedItem = AutoMapper.Mapper.Map<PlantProductType, ProductType>(requestItem);

            ProductType item = uow.ProductTypeRepository.Save(mappedItem);

            PlantProductType finalItem = AutoMapper.Mapper.Map<ProductType, PlantProductType>(item);

            return finalItem;
        }

        protected override void DeleteItem(IUnitOfWork uow, int id)
        {
            // map 
            //ProductType mappedItem = AutoMapper.Mapper.Map<PlantProductType, ProductType>(requestItem);

            uow.ProductTypeRepository.Delete(uow.ProductTypeRepository.GetItemById(id));
        }

        protected override IList<PlantProductType> ListItems(IUnitOfWork uow)
        {
            IList<ProductType> allItems = uow.ProductTypeRepository.GetAll();

            IList<PlantProductType> items = AutoMapper.Mapper.Map<IList<ProductType>, IList<PlantProductType>>(allItems);

            return items;
        }
    }
}
