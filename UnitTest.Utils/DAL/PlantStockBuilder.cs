using PlantDataMVC.Entities.Models;
using UnitTest.Utils.Common;

namespace UnitTest.Utils.DAL
{
    /// <summary>
    /// Creates random data against the domain objects in the namespace <code>PlantDataMVC.Core.Domain.BusinessObjects</code>
    /// </summary>
    public class PlantStockBuilder
    {
        // Default members
        public static readonly int DEFAULT_QUANTITY = 0;

        // private members (for object properties)
        private int _id;
        private ProductType _productType;
        private Species _species;
        private int _quantity;

        private PlantStockBuilder()
        {
        }

        /// <summary>
        /// Starting point for creating plant test data
        /// </summary>
        /// <returns></returns>
        public static PlantStockBuilder aStockItem()
        {
            return new PlantStockBuilder();
        }

        public PlantStockBuilder withNoId()
        {
            _id = 0;
            return this;
        }

        public PlantStockBuilder withId()
        {
            _id = CommonTestData.GeneratRandomInt();
            return this;
        }

        public PlantStockBuilder withQuantity(int quantity)
        {
            _quantity = quantity;
            return this;
        }

        public PlantStockBuilder withSpecies(Species species)
        {
            _species = species;
            return this;
        }

        public PlantStockBuilder withProductType(ProductType productType)
        {
            _productType = productType;
            return this;
        }

        public PlantStockBuilder withRandomValues()
        {
            _id = CommonTestData.GeneratRandomInt();
            _quantity = CommonTestData.GeneratRandomInt();
            return this;
        }

        public PlantStock Build()
        {
            return new PlantStock()
            {
                Id = _id,
                ProductType = _productType,
                ProductTypeId = _productType.Id,
                QuantityInStock = _quantity,
                Species = _species,
                SpeciesId = _species.Id
            };
        }
    }
}