using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.WebApi.Helpers;
using Xunit;

namespace PlantDataMVC.WebApi.Tests.UnitTests
{
    public class HelperTests
    {
        [Fact]
        public void TestDataShapedObject()
        {
            // Arrange
            var species = new SpeciesDto
            {
                CommonName = "Brisbane wattle",
                Description = "Small tree to 10m",
                GenusId = 1,
                Id = 1,
                Native = true,
                PropagationTime = 17,
                SpecificName = "fimbriata",
                PlantStocks = new List<PlantStockDto>
                {
                    new PlantStockDto
                    {
                        Id = 2, ProductTypeId = 1, SpeciesId = 1, QuantityInStock = 10
                    },
                    new PlantStockDto
                    {
                        Id = 3, ProductTypeId = 2, SpeciesId = 1, QuantityInStock = 5
                    }
                },
                SeedBatches = new List<SeedBatchDto>
                {
                    new SeedBatchDto
                    {
                        Id = 6, DateCollected = new DateTime(2016, 1, 30), SpeciesId = 1, Location = "Home",
                        Notes = "Notes 1"
                    },
                    new SeedBatchDto
                    {
                        Id = 3, DateCollected = new DateTime(2018, 11, 3), SpeciesId = 1, Location = "Grandchester",
                        Notes = "Notes 2"
                    },
                    new SeedBatchDto
                    {
                        Id = 11, DateCollected = new DateTime(2017, 7, 23), SpeciesId = 1, Location = "Tingalpa",
                        Notes = "Notes 3"
                    }
                }
            };

            var fields =
                "commonName,plantStocks,plantStocks.quantityInStock,seedBatches.DateCollected,seedBatches.location";

            var fieldList = fields.Split(',').ToList();

            // Act
            var dataShapedObject = DataShaping.CreateDataShapedObject(species, fieldList);

            var x = JsonConvert.SerializeObject(dataShapedObject);

            // Assert
        }

        [Fact]
        public void TestGetRelatedObjects()
        {
            var relatedObjs = DataShaping.GetRelatedDtoPropInfos<SpeciesDto>();
        }
    }
}