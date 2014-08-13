using Xunit;
using PlantDataMvc3.DAL.Entities;
using PlantDataMvc3.DAL.Interfaces;

namespace PlantDataMvc3.Tests.DAL
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
            Assert.Null(species.LatinName);
            Assert.Equal<int>(0, species.Id);
            Assert.Equal<int>(0, species.GenusId);
            Assert.Null(species.GenusLatinName);
            Assert.Null(species.CommonName);
            Assert.Null(species.Description);
            Assert.Equal<bool>(false, species.Native);
            Assert.Null(species.PropagationTime);
            Assert.Null(species.LatinName);
        }

        [Fact]
        public void CanConstructWithProperties()
        {
            // Act
            var species = new Species()
                            {
                                Id = 1,
                                GenusId = 1,
                                GenusLatinName = "Eremophila",
                                CommonName = "Crimson emu bush",
                                Description = "Arid zone plant",
                                Native = true,
                                PropagationTime = 32,
                                LatinName = "glabra"
                            };

            // Assert
            var entity = Assert.IsAssignableFrom<IEntity>(species);
            Assert.Equal<int>(1, species.Id);
            Assert.Equal<int>(1, species.GenusId);
            Assert.Equal<string>("Eremophila", species.GenusLatinName);
            Assert.Equal<string>("Crimson emu bush", species.CommonName);
            Assert.Equal<string>("Arid zone plant", species.Description);
            Assert.Equal<bool>(true, species.Native);
            Assert.Equal<int?>(32, species.PropagationTime);
            Assert.Equal<string>("glabra", species.LatinName);
        }
    }
}