using PlantDataMvc3.DAL.Entities;
using PlantDataMvc3.DAL.Interfaces;
using System.Collections.Generic;
using System;

namespace PlantDataMvc3.DAL.TestData
{
    public class TestPlantStockRepository : TestRepositoryBase<PlantStock>, IPlantStockRepository
    {
        public TestPlantStockRepository()
            : base()
        { }

        public override PlantStock CreateItem(PlantStock requestItem)
        {
            requestItem.Id = _randomGen.Next();

            return requestItem;
        }

        public override PlantStock SelectItem(int id)
        {
            return new PlantStock()
            {
                Id = id,
                SpeciesId = 1,
                ProductTypeId = 1,
                QuantityInStock = 7
            };
        }

        public override PlantStock UpdateItem(PlantStock requestItem)
        {
            return requestItem;
        }

        public override void DeleteItem(int id)
        {
            throw new NotImplementedException();
        }

        public override IList<PlantStock> ListItems()
        {
            List<PlantStock> stockList = new List<PlantStock>();
            stockList.Add(new PlantStock() { Id = 1, SpeciesId = 11, ProductTypeId = 1, QuantityInStock = 1 });
            stockList.Add(new PlantStock() { Id = 2, SpeciesId = 11, ProductTypeId = 2, QuantityInStock = 1 });
            stockList.Add(new PlantStock() { Id = 3, SpeciesId = 11, ProductTypeId = 3, QuantityInStock = 1 });
            stockList.Add(new PlantStock() { Id = 4, SpeciesId = 14, ProductTypeId = 2, QuantityInStock = 1 });

            return stockList;
        }

    }
}
