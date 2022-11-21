using PlantDataMVC.Entities.EntityModels;
using UnitTest.Utils.Common;

namespace UnitTest.Utils.Domain
{
    /// <summary>
    /// Creates random data against the domain objects in the namespace <code>PlantDataMVC.Core.Domain.BusinessObjects</code>
    /// </summary>
    public class GenusBuilder
    {
        // Default members
        public static readonly string DEFAULT_GENUS = "Eucalyptus";

        // private members (for object properties)
        private int _id;
        private string _latinName = DEFAULT_GENUS;

        private GenusBuilder()
        {
        }

        /// <summary>
        /// Starting point for creating plant test data
        /// </summary>
        /// <returns></returns>
        public static GenusBuilder aGenus()
        {
            return new GenusBuilder();
        }

        public GenusBuilder withNoId()
        {
            _id = 0;
            return this;
        }

        public GenusBuilder withId()
        {
            _id = CommonTestData.GenerateRandomInt();
            return this;
        }

        public GenusBuilder withLatinName(string latinName)
        {
            _latinName = latinName;
            return this;
        }

        public GenusBuilder withRandomValues()
        {
            _id = CommonTestData.GenerateRandomInt();
            _latinName = CommonTestData.GenerateRandomAlphabetString(10);
            return this;
        }

        public GenusEntityModel Build()
        {
            return new GenusEntityModel()
            {
                Id = _id,
                LatinName = _latinName
            };
        }
    }
}