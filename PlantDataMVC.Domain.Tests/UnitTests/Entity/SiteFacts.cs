﻿using FluentAssertions;
using Interfaces.Domain.Entity;
using PlantDataMVC.Entities.EntityModels;
using Xunit;

namespace PlantDataMVC.Domain.Tests.UnitTests.Entity
{
    public class SiteFacts
    {
        [Fact]
        public void CanConstructEmptyObject()
        {
            // Act
            var site = new SiteEntityModel();

            // Assert
            // can I assign object to IEntity?
            site.Should().BeAssignableTo<IEntity>();
            site.Should().BeOfType<SiteEntityModel>();
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
            var site = new SiteEntityModel
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
            site.Should().BeOfType<SiteEntityModel>();
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