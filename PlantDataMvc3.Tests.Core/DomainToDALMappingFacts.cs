using AutoMapper;
using PlantDataMvc3.Core.Domain.BusinessObjects;
using PlantDataMvc3.DAL.Entities;
using UnitTest.Utils.TestData;
using Xunit;

namespace PlantDataMvc3.Tests.Core
{
    public class DomainToDALMappingFacts : IUseFixture<CoreMappingFixture>
    {
        public DomainToDALMappingFacts()
        {
        }

        public void SetFixture(CoreMappingFixture mapping)
        {
            mapping.Configure();
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
                LatinName = plant.GenusLatinName
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
                LatinName = plant.SpeciesLatinName,
                CommonName = plant.CommonName,
                Description = plant.Description,
                GenusLatinName = plant.GenusLatinName,
                Native = plant.Native,
                PropagationTime = plant.PropagationTime
            };

            // Act
            Species result = Mapper.Map<Plant, Species>(plant);

            // Assert
            Assert.Equal(expectedSpecies.Id, result.Id);
            Assert.Equal(expectedSpecies.LatinName, result.LatinName);
            Assert.Equal(expectedSpecies.CommonName, result.CommonName);
            Assert.Equal(expectedSpecies.Description, result.Description);
            Assert.Equal(expectedSpecies.GenusLatinName, result.GenusLatinName);
            Assert.Equal(expectedSpecies.Native, result.Native);
            Assert.Equal(expectedSpecies.PropagationTime, result.PropagationTime);
        }

    }
}
