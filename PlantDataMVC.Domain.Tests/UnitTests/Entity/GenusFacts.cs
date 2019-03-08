using FluentAssertions;
using Interfaces.Domain.Entity;
using PlantDataMVC.Entities.Models;
using Xunit;

namespace PlantDataMVC.Domain.Tests.UnitTests.Entity
{
    public class GenusFacts
    {
        /// <summary>
        ///     Determines whether empty object is constructed correctly.
        ///     Test is pretty redundant.
        /// </summary>
        [Fact]
        public void CanConstructEmptyObject()
        {
            // Act
            var genus = new Genus();

            // Assert
            // can I assign species object to IEntity?
            genus.Should().BeAssignableTo<IEntity>();
            genus.Should().BeOfType<Genus>();
            genus.Should().NotBeNull();

            // Check default values
            genus.Id.Should().Be(0);
            genus.LatinName.Should().BeNull();
        }

        /// <summary>
        ///     Determines whether object with properties is constructed correctly.
        ///     Test is pretty redundant.
        /// </summary>
        [Fact]
        public void CanConstructWithProperties()
        {
            // Act
            var genus = new Genus
            {
                Id = 1,
                LatinName = "Eremophila"
            };

            // Assert
            // can I assign species object to IEntity?
            genus.Should().BeAssignableTo<IEntity>();
            genus.Should().BeOfType<Genus>();
            genus.Should().NotBeNull();

            // Check default values
            genus.Id.Should().Be(1);
            genus.LatinName.Should().Be("Eremophila");
        }
    }
}