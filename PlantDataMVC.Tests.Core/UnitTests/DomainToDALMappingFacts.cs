using AutoMapper;
using FluentAssertions;
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
            // Reset Mapper before configuring
            Mapper.Reset();
            // Configure the mapper at start of each test
            AutoMapperCoreConfiguration.Configure();
        }

        public void Dispose()
        {
            // Reset Mapper at end of each test
            //Mapper.Reset();
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
            result.Should().BeEquivalentTo(expectedGenus, options => options
                                                            .Including(g => g.LatinName));
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
            result.Should().BeEquivalentTo(expectedSpecies, options => options
                                                            .Including(s => s.Id)
                                                            .Including(s => s.SpecificName)
                                                            .Including(s => s.CommonName)
                                                            .Including(s => s.Description)
                                                            .Including(s => s.Native)
                                                            .Including(s => s.PropagationTime));
        }

    }
}
