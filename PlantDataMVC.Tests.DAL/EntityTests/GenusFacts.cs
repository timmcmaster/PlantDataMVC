using Xunit;
using PlantDataMVC.Entities.Models;
using Framework.DAL.Entity;

namespace PlantDataMVC.Tests.DAL
{
    public class GenusFacts
    {
        [Fact]
        public void CanConstructEmptyObject()
        {
            // Act
            var genus = new Genus();

            // Assert
            var entity = Assert.IsAssignableFrom<IEntity>(genus);
            Assert.Null(genus.LatinName);
            Assert.Equal<int>(0, genus.Id);
        }

        [Fact]
        public void CanConstructWithProperties()
        {
            // Act
            var genus = new Genus()
                            {
                                Id = 1,
                                LatinName = "Eremophila"
                            };

            // Assert
            var entity = Assert.IsAssignableFrom<IEntity>(genus);
            Assert.Equal<int>(1, genus.Id);
            Assert.Equal("Eremophila", genus.LatinName);
        }

        [Fact]
        public void AllPropertiesMatch()
        {
            // Act
            var genus = new Genus();

            // Assert
            var entity = Assert.IsAssignableFrom<IEntity>(genus);
            Assert.Null(genus.LatinName);
            Assert.Equal<int>(0, genus.Id);
        }

    }
}