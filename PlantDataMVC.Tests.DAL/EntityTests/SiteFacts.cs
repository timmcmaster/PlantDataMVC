using Interfaces.DAL.Entity;
using PlantDataMVC.Entities.Models;
using Xunit;

namespace PlantDataMVC.Tests.DAL
{
    public class SiteFacts
    {
        [Fact]
        public void CanConstructEmptyObject()
        {
            // Act
            var site = new Site();

            // Assert
            var entity = Assert.IsAssignableFrom<IEntity>(site);
            Assert.Equal(0, site.Id);
            Assert.Null(site.SiteName);
            Assert.Null(site.Suburb);
            Assert.Null(site.Latitude);
            Assert.Null(site.Longitude);
        }

        [Fact]
        public void CanConstructWithProperties()
        {
            // Act
            var site = new Site()
            {
                Id = 1,
                SiteName = "Home",
                Suburb = "Moorooka",
                Latitude = 0.5m,
                Longitude = 0.5m
            };

            // Assert
            var entity = Assert.IsAssignableFrom<IEntity>(site);
            Assert.Equal(1, site.Id);
            Assert.Equal("Home", site.SiteName);
            Assert.Equal("Moorooka", site.Suburb);
            Assert.Equal(0.5m, site.Latitude);
            Assert.Equal(0.5m, site.Longitude);
        }
    }
}