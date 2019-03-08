using PlantDataMVC.Entities.Models;
using UnitTest.Utils.Common;

namespace UnitTest.Utils.Domain
{
    /// <summary>
    /// Creates random data against the domain objects in the namespace <code>PlantDataMVC.Core.Domain.BusinessObjects</code>
    /// </summary>
    public class ProductTypeBuilder
    {
        // Default members
        public static readonly string DEFAULT_NAME = "Standard tube";

        // private members (for object properties)
        private int _id;
        private string _name = DEFAULT_NAME;

        private ProductTypeBuilder()
        {
        }

        /// <summary>
        /// Starting point for creating plant test data
        /// </summary>
        /// <returns></returns>
        public static ProductTypeBuilder aProductType()
        {
            return new ProductTypeBuilder();
        }

        public ProductTypeBuilder withNoId()
        {
            _id = 0;
            return this;
        }

        public ProductTypeBuilder withId()
        {
            _id = CommonTestData.GeneratRandomInt();
            return this;
        }

        public ProductTypeBuilder withName(string name)
        {
            _name = name;
            return this;
        }

        public ProductTypeBuilder withRandomValues()
        {
            _id = CommonTestData.GeneratRandomInt();
            _name = CommonTestData.GenerateRandomAlphabetString(10);
            return this;
        }

        public ProductType Build()
        {
            return new ProductType()
            {
                Id = _id,
                Name = _name
            };
        }
    }
}