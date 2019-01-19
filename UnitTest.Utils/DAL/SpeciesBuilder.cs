using PlantDataMVC.Entities.Models;
using UnitTest.Utils.Common;

namespace UnitTest.Utils.DAL
{
    /// <summary>
    /// Creates random data against the domain objects in the namespace <code>PlantDataMVC.Core.Domain.BusinessObjects</code>
    /// </summary>
    public class SpeciesBuilder
    {
        // Default members
        public static readonly string DEFAULT_SPECIES = "camaldulensis";
        public static readonly string DEFAULT_COMMON_NAME = "River red gum";
        public static readonly string DEFAULT_DESCRIPTION = "Large tree to 40m on river banks";
        public static readonly int DEFAULT_PROPAGATION = 7;
        public static readonly bool DEFAULT_NATIVE = true;

        // private members (for object properties)
        private int _id;
        private Genus _genus;
        private string _specificName = DEFAULT_SPECIES;
        private string _commonName = DEFAULT_COMMON_NAME;
        private string _description = DEFAULT_DESCRIPTION;
        private int _propagationTime = DEFAULT_PROPAGATION;
        private bool _native = DEFAULT_NATIVE;

        private SpeciesBuilder()
        {
        }

        /// <summary>
        /// Starting point for creating species test data
        /// </summary>
        /// <returns></returns>
        public static SpeciesBuilder aSpecies()
        {
            return new SpeciesBuilder();
        }

        public SpeciesBuilder withNoId()
        {
            _id = 0;
            return this;
        }

        public SpeciesBuilder withId()
        {
            _id = CommonTestData.GeneratRandomInt();
            return this;
        }

        public SpeciesBuilder withGenus(Genus genus)
        {
            _genus = genus;
            return this;
        }

        public SpeciesBuilder withSpecificName(string specificName)
        {
            _specificName = specificName;
            return this;
        }

        public SpeciesBuilder withCommonName(string commonName)
        {
            _commonName = commonName;
            return this;
        }

        public SpeciesBuilder withDescription(string description)
        {
            _description = description;
            return this;
        }

        public SpeciesBuilder withPropagationTime(int propagationTime)
        {
            _propagationTime = propagationTime;
            return this;
        }

        public SpeciesBuilder withNative(bool native)
        {
            _native = native;
            return this;
        }

        public SpeciesBuilder withRandomValues()
        {
            _id = CommonTestData.GeneratRandomInt();
            //_genus = GenusBuilder.aGenus().withId().Build();
            _commonName = CommonTestData.GenerateRandomAlphabetString(50);
            _description = CommonTestData.GenerateRandomAlphabetString(200);
            _propagationTime = CommonTestData.GeneratRandomInt();
            _native = CommonTestData.GenerateRandomBoolean();
            _specificName = CommonTestData.GenerateRandomAlphabetString(10);

            return this;
        }

        public Species Build()
        {
            return new Species()
            {
                Id = _id,
                CommonName = _commonName,
                Description = _description,
                PropagationTime = _propagationTime,
                Native = _native,
                SpecificName = _specificName,
                Genus = _genus,
                GenusId = _genus.Id // TODO: What if genus is null?
            };
        }
    }
}