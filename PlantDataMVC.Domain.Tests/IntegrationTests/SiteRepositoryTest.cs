﻿using FluentAssertions;
using Framework.Domain.EF;
using Interfaces.Domain.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using PlantDataMVC.Entities.Context;
using PlantDataMVC.Entities.Interfaces;
using PlantDataMVC.Entities.EntityModels;
using System.Configuration;
using UnitTest.Utils.Domain;
using Xunit;
using Xunit.Abstractions;

namespace PlantDataMVC.Domain.Tests.IntegrationTests
{
    public class SiteRepositoryTest : IntegrationTestBase
    {
        #region Setup/Teardown
        public SiteRepositoryTest(ITestOutputHelper output, DbFixture dbFixture) : base(dbFixture)
        {
            _output = output;
            _plantDataDbConnectionString = ConfigurationManager.ConnectionStrings["PlantDataDbContext"].ConnectionString;
        }
        #endregion

        private readonly ITestOutputHelper _output;
        private readonly string _plantDataDbConnectionString;

        [Fact]
        public void CanCreateSiteAndReturnIdentityWithSaveChanges()
        {
            using (IPlantDataDbContext plantDataDbContext = new PlantDataDbContext(_plantDataDbConnectionString))
            using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(plantDataDbContext))
            {
                // Arrange
                var requestSite = SiteBuilder.aSite().withNoId().Build();
                var repository = unitOfWork.Repository<SiteEntityModel>();

                // Act
                repository.Add(requestSite);
                unitOfWork.SaveChanges();
                var returnedSite = repository.GetItemById(requestSite.Id);

                // Assert
                returnedSite.Should().NotBeNull();
                returnedSite.Id.Should().NotBe(0);
                _output.WriteLine("returnedSite.Id: {0}", returnedSite.Id);
            }
        }

        [Fact]
        public void CanUpdateSiteAndGetBackSameWithDiffContext()
        {
            int addedSiteId;
            var siteLatitude = 1.12345m;
            var siteLongitude = 1.12345m;

            // Add a site so that we can update it
            using (IDbContext plantDataDbContext = new PlantDataDbContext(_plantDataDbConnectionString))
            using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(plantDataDbContext))
            {
                var requestSite = SiteBuilder.aSite().withNoId().Build();
                var repository = unitOfWork.Repository<SiteEntityModel>();

                // Act
                repository.Add(requestSite);
                unitOfWork.SaveChanges();
                var returnedSite = repository.GetItemById(requestSite.Id);

                addedSiteId = returnedSite.Id;
            }

            // Update with one context
            using (IDbContext plantDataDbContext = new PlantDataDbContext(_plantDataDbConnectionString))
            using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(plantDataDbContext))
            {
                // Arrange
                var repository = unitOfWork.Repository<SiteEntityModel>();
                var site = repository.GetItemById(addedSiteId);

                // Act
                site.Latitude = siteLatitude;
                site.Longitude = siteLongitude;

                try
                {
                    repository.Update(site);
                    unitOfWork.SaveChanges();
                }
                catch (DbUpdateException)
                {
                }
            }

            // Retrieve with another
            using (IDbContext plantDataDbContext = new PlantDataDbContext(_plantDataDbConnectionString))
            using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(plantDataDbContext))
            {
                var repository = unitOfWork.Repository<SiteEntityModel>();
                var retrievedSite = repository.GetItemById(addedSiteId);

                // Assert
                retrievedSite.Should().NotBeNull();
                retrievedSite.Latitude.Should().Be(siteLatitude);
                retrievedSite.Longitude.Should().Be(siteLongitude);
            }
        }

        [Fact]
        public void CanUpdateSiteAndGetBackSameWithSameContext()
        {
            int addedSiteId;
            var siteLatitude = 1.12345m;
            var siteLongitude = 1.12345m;

            // Add a site so that we can update it
            using (IDbContext plantDataDbContext = new PlantDataDbContext(_plantDataDbConnectionString))
            using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(plantDataDbContext))
            {
                var requestSite = SiteBuilder.aSite().withNoId().Build();
                var repository = unitOfWork.Repository<SiteEntityModel>();

                // Act
                repository.Add(requestSite);
                unitOfWork.SaveChanges();
                var returnedSite = repository.GetItemById(requestSite.Id);

                addedSiteId = returnedSite.Id;
            }

            using (IDbContext plantDataDbContext = new PlantDataDbContext(_plantDataDbConnectionString))
            using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(plantDataDbContext))
            {
                // Arrange
                var repository = unitOfWork.Repository<SiteEntityModel>();
                var site = repository.GetItemById(addedSiteId);

                // Act
                site.Latitude = siteLatitude;
                site.Longitude = siteLongitude;

                try
                {
                    repository.Update(site);
                    unitOfWork.SaveChanges();
                    var updatedSite = repository.GetItemById(site.Id);
                }
                catch (DbUpdateException ex)
                {
                }

                var retrievedSite = repository.GetItemById(addedSiteId);

                // Assert
                retrievedSite.Should().NotBeNull();

                retrievedSite.Should().BeEquivalentTo(site, options => options
                                                                       .Including(s => s.Latitude)
                                                                       .Including(s => s.Longitude));
            }
        }
    }
}