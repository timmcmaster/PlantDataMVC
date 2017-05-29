using PlantDataMVC.DAL.Entities;
using PlantDataMVC.DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace PlantDataMVC.DAL.TestData
{
    public class TestProductTypeRepository : TestRepositoryBase<ProductType>, IProductTypeRepository
    {
        public TestProductTypeRepository()
            : base()
        { }
        public override ProductType CreateItem(ProductType requestItem)
        {
            requestItem.Id = _randomGen.Next();

            return requestItem;
        }

        public override ProductType SelectItem(int id)
        {
            return new ProductType() { Id = id, Name = "Tube" };
        }

        public override ProductType UpdateItem(ProductType requestItem)
        {
            return requestItem;
        }

        public override void DeleteItem(int id)
        {
            throw new NotImplementedException();
        }

        public override IList<ProductType> ListItems()
        {
            List<ProductType> productTypeList = new List<ProductType>();
            productTypeList.Add(new ProductType() { Id = 1, Name = "Tube" });
            productTypeList.Add(new ProductType() { Id = 2, Name = "Medium plant" });
            productTypeList.Add(new ProductType() { Id = 2, Name = "Large plant" });

            return productTypeList;
        }
    }
}
