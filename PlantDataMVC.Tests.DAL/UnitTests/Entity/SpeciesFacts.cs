using Interfaces.DAL.Entity;
using PlantDataMVC.Entities.Models;
using Xunit;

namespace PlantDataMVC.Tests.DAL
{
    public class SpeciesFacts
    {
        [Fact]
        public void CanConstructEmptyObject()
        {
            // Act
            var species = new Species();

            // Assert
            var entity = Assert.IsAssignableFrom<IEntity>(species);
            Assert.Null(species.SpecificName);
            Assert.Equal<int>(0, species.Id);
            Assert.Equal<int>(0, species.GenusId);
            //Assert.Null(species.GenusLatinName);
            Assert.Null(species.CommonName);
            Assert.Null(species.Description);
            Assert.False(species.Native);
            Assert.Null(species.PropagationTime);
            Assert.Null(species.SpecificName);
        }

        [Fact]
        public void CanConstructWithProperties()
        {
            // Act
            var species = new Species()
                            {
                                Id = 1,
                                GenusId = 1,
                                //GenusLatinName = "Eremophila",
                                CommonName = "Crimson emu bush",
                                Description = "Arid zone plant",
                                Native = true,
                                PropagationTime = 32,
                                SpecificName = "glabra"
                            };

            // Assert
            var entity = Assert.IsAssignableFrom<IEntity>(species);
            Assert.Equal<int>(1, species.Id);
            Assert.Equal<int>(1, species.GenusId);
            //Assert.Equal<string>("Eremophila", species.GenusLatinName);
            Assert.Equal("Crimson emu bush", species.CommonName);
            Assert.Equal("Arid zone plant", species.Description);
            Assert.True(species.Native);
            Assert.Equal<int?>(32, species.PropagationTime);
            Assert.Equal("glabra", species.SpecificName);
        }
    }
}