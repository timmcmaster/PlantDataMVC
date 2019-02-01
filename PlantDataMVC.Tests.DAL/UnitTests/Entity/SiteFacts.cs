using FluentAssertions;
using Interfaces.DAL.Entity;
using PlantDataMVC.Entities.Models;
using Xunit;

namespace PlantDataMVC.Tests.DAL.UnitTests.Entity
{
    public class SiteFacts
    {
        [Fact]
        public void CanConstructEmptyObject()
        {
            // Act
            var site = new Site();

            // Assert
            // can I assign object to IEntity?
            site.Should().BeAssignableTo<IEntity>();
            site.Should().BeOfType<Site>();
            site.Should().NotBeNull();

            // Check default values
            site.Id.Should().Be(0);
            site.SiteName.Should().BeNull();
            site.Suburb.Should().BeNull();
            site.Latitude.Should().BeNull();
            site.Longitude.Should().BeNull();
        }

        [Fact]
        public void CanConstructWithProperties()
        {
            // Act
            var site = new Site
            {
                Id = 1,
                SiteName = "Home",
                Suburb = "Moorooka",
                Latitude = 0.5m,
                Longitude = 0.5m
            };

            // Assert
            // can I assign object to IEntity?
            site.Should().BeAssignableTo<IEntity>();
            site.Should().BeOfType<Site>();
            site.Should().NotBeNull();

            // Check default values
            site.Id.Should().Be(1);
            site.SiteName.Should().Be("Home");
            site.Suburb.Should().Be("Moorooka");
            site.Latitude.Should().Be(0.5m);
            site.Longitude.Should().Be(0.5m);
        }
    }
}