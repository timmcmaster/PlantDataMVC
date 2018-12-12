using AutoMapper;
using PlantDataMVC.Domain.Entities;
using PlantDataMVC.Domain.Mappers;
using PlantDataMVC.Entities.Models;
using System;
using UnitTest.Utils.Domain;
using Xunit;

namespace PlantDataMVC.Tests.Core
{
    public class DomainToDALMappingFacts : IDisposable
    {
        public DomainToDALMappingFacts()
        {
            // Configure the mapper at start of each test
            AutoMapperCoreConfiguration.Configure();
        }

        public void Dispose()
        {
            // Reset Mapper at end of each test
            Mapper.Reset();
        }

        [Fact]
        public void TestMappingConfiguration()
        {
            Mapper.AssertConfigurationIsValid();
        }

        [Fact]
        public void TestPlantToGenusMapping()
        {
            // Arrange
            var plant = PlantBuilder.aPlant().withRandomValues().Build();
            var expectedGenus = new Genus()
            {
                Id = plant.Id,
                LatinName = plant.GenericName
            };

            // Act
            Genus result = Mapper.Map<Plant, Genus>(plant);

            // Assert
            Assert.Equal(expectedGenus.LatinName, result.LatinName);
        }

        [Fact]
        public void TestPlantToSpeciesMapping()
        {
            // Arrange
            var plant = PlantBuilder.aPlant().withRandomValues().Build();
            var expectedSpecies = new Species()
            {
                Id = plant.Id,
                SpecificName = plant.SpecificName,
                CommonName = plant.CommonName,
                Description = plant.Description,
                //GenusLatinName = plant.GenusLatinName,
                Native = plant.Native,
                PropagationTime = plant.PropagationTime
            };

            // Act
            Species result = Mapper.Map<Plant, Species>(plant);

            // Assert
            Assert.Equal(expectedSpecies.Id, result.Id);
            Assert.Equal(expectedSpecies.SpecificName, result.SpecificName);
            Assert.Equal(expectedSpecies.CommonName, result.CommonName);
            Assert.Equal(expectedSpecies.Description, result.Description);
            //Assert.Equal(expectedSpecies.GenusLatinName, result.GenusLatinName);
            Assert.Equal(expectedSpecies.Native, result.Native);
            Assert.Equal(expectedSpecies.PropagationTime, result.PropagationTime);
        }

    }
}
