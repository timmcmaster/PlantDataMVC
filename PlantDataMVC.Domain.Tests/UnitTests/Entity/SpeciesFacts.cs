using FluentAssertions;
using Interfaces.Domain.Entity;
using PlantDataMVC.Entities.EntityModels;
using Xunit;

namespace PlantDataMVC.Domain.Tests.UnitTests.Entity
{
    public class SpeciesFacts
    {
        /// <summary>
        ///     Determines whether empty object is constructed correctly.
        ///     Test is pretty redundant.
        /// </summary>
        [Fact]
        public void CanConstructEmptyObject()
        {
            // Act
            var species = new SpeciesEntityModel();

            // Assert
            // can I assign species object to IEntity?
            species.Should().BeAssignableTo<IEntity>();
            species.Should().BeOfType<SpeciesEntityModel>();
            species.Should().NotBeNull();

            // Check default values
            species.Id.Should().Be(0);
            species.GenusId.Should().Be(0);
            species.SpecificName.Should().BeNull();
            species.Description.Should().BeNull();
            species.CommonName.Should().BeNull();
            species.PropagationTime.Should().BeNull();
            species.Native.Should().BeFalse();
        }

        /// <summary>
        ///     Determines whether object with properties is constructed correctly.
        ///     Test is pretty redundant.
        /// </summary>
        [Fact]
        public void CanConstructWithProperties()
        {
            // Act
            var species = new SpeciesEntityModel
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
            // can I assign species object to IEntity?
            species.Should().BeAssignableTo<IEntity>();
            species.Should().BeOfType<SpeciesEntityModel>();
            species.Should().NotBeNull();

            // Check default values
            species.Id.Should().Be(1);
            species.GenusId.Should().Be(1);
            species.SpecificName.Should().Be("glabra");
            species.Description.Should().Be("Arid zone plant");
            species.CommonName.Should().Be("Crimson emu bush");
            species.PropagationTime.Should().Be(32);
            species.Native.Should().BeTrue();
        }
    }
}