using AutoMapper;
using PlantDataMVC.Domain.Entities;
using PlantDataMVC.Entities.Models;
using UnitTest.Utils.TestData;
using Xunit;

namespace PlantDataMVC.Tests.Core
{
    public class DomainToDALMappingFacts : IClassFixture<CoreMappingFixture>
    {
        public DomainToDALMappingFacts()
        {
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
            var plant = DomainTestData.GenerateRandomPlant();
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
            var plant = DomainTestData.GenerateRandomPlant();
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
