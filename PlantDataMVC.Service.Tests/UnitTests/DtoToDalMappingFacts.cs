using System;
using AutoMapper;
using PlantDataMVC.DTO.Mappers;
using Xunit;

namespace PlantDataMVC.Service.Tests.UnitTests
{
    public class DtoToDalMappingFacts : IDisposable
    {
        #region Setup/Teardown
        private readonly MapperConfiguration _mapperConfiguration;

        public DtoToDalMappingFacts()
        {
            // Configure the mapper at start of each test
            _mapperConfiguration = AutoMapperCoreConfiguration.Configure();
        }

        public void Dispose()
        {
            // Reset Mapper at end of each test
            //Mapper.Reset();
        }
        #endregion

        [Fact]
        public void TestMappingConfiguration()
        {
            _mapperConfiguration.AssertConfigurationIsValid();
        }

        //[Fact]
        //public void TestPlantToGenusMapping()
        //{
        //    // Arrange
        //    var plant = PlantBuilder.aPlant().withRandomValues().Build();
        //    var expectedGenus = new Genus()
        //    {
        //        Id = plant.Id,
        //        LatinName = plant.GenericName
        //    };

        //    // Act
        //    Genus result = _mapper.Map<Plant, Genus>(plant);

        //    // Assert
        //    result.Should().BeEquivalentTo(expectedGenus, options => options
        //                                                    .Including(g => g.LatinName));
        //}

        //[Fact]
        //public void TestPlantToSpeciesMapping()
        //{
        //    // Arrange
        //    var plant = PlantBuilder.aPlant().withRandomValues().Build();
        //    var expectedSpecies = new Species()
        //    {
        //        Id = plant.Id,
        //        SpecificName = plant.SpecificName,
        //        CommonName = plant.CommonName,
        //        Description = plant.Description,
        //        //GenusLatinName = plant.GenusLatinName,
        //        Native = plant.Native,
        //        PropagationTime = plant.PropagationTime
        //    };

        //    // Act
        //    Species result = _mapper.Map<Plant, Species>(plant);

        //    // Assert
        //    result.Should().BeEquivalentTo(expectedSpecies, options => options
        //                                                    .Including(s => s.Id)
        //                                                    .Including(s => s.SpecificName)
        //                                                    .Including(s => s.CommonName)
        //                                                    .Including(s => s.Description)
        //                                                    .Including(s => s.Native)
        //                                                    .Including(s => s.PropagationTime));
        //}
    }
}