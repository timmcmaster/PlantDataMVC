using PlantDataMVC.Domain.Entities;
using System;
using System.Collections.Generic;
using UnitTest.Utils.Common;

namespace UnitTest.Utils.Domain
{
    /// <summary>
    /// Creates random data against the domain objects in the namespace <code>PlantDataMVC.Core.Domain.BusinessObjects</code>
    /// </summary>
    public class PlantBuilder
    {
        // Default members
        public static readonly string DEFAULT_GENUS = "Eucalyptus";
        public static readonly string DEFAULT_SPECIES = "camaldulensis";
        public static readonly string DEFAULT_COMMON_NAME = "River red gum";
        public static readonly string DEFAULT_DESCRIPTION = "Large tree to 40m on river banks";
        public static readonly int DEFAULT_PROPAGATION = 7;
        public static readonly bool DEFAULT_NATIVE = true;

        // private members (for object properties)
        private int _id;
        private string _genericName = DEFAULT_GENUS;
        private string _specificName = DEFAULT_SPECIES;
        private string _commonName = DEFAULT_COMMON_NAME;
        private string _description = DEFAULT_DESCRIPTION;
        private int _propagationTime = DEFAULT_PROPAGATION;
        private bool _native = DEFAULT_NATIVE;

        private PlantBuilder()
        {
        }

        /// <summary>
        /// Starting point for creating plant test data
        /// </summary>
        /// <returns></returns>
        public static PlantBuilder aPlant()
        {
            return new PlantBuilder();
        }

        public PlantBuilder withNoId()
        {
            _id = 0;
            return this;
        }

        public PlantBuilder withId()
        {
            _id = CommonTestData.GeneratRandomInt();
            return this;
        }

        public PlantBuilder withGenericName(string genericName)
        {
            _genericName = genericName;
            return this;
        }

        public PlantBuilder withSpecificName(string specificName)
        {
            _specificName = specificName;
            return this;
        }

        public PlantBuilder withCommonName(string commonName)
        {
            _commonName = commonName;
            return this;
        }

        public PlantBuilder withDescription(string description)
        {
            _description = description;
            return this;
        }

        public PlantBuilder withPropagationTime(int propagationTime)
        {
            _propagationTime = propagationTime;
            return this;
        }

        public PlantBuilder withNative(bool native)
        {
            _native = native;
            return this;
        }

        public PlantBuilder withRandomValues()
        {
            _id = CommonTestData.GeneratRandomInt();
            _commonName = CommonTestData.GenerateRandomAlphabetString(50);
            _description = CommonTestData.GenerateRandomAlphabetString(200);
            _propagationTime = CommonTestData.GeneratRandomInt();
            _native = CommonTestData.GenerateRandomBoolean();
            _genericName = CommonTestData.GenerateRandomAlphabetString(10);
            _specificName = CommonTestData.GenerateRandomAlphabetString(10);

            return this;
        }

        public Plant Build()
        {
            return new Plant()
            {
                Id = _id,
                CommonName = _commonName,
                Description = _description,
                PropagationTime = _propagationTime,
                Native = _native,
                GenericName = _genericName,
                SpecificName = _specificName
            };
        }
    }
}