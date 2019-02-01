using System.Data.Entity.Validation;
using FluentAssertions;
using Framework.DAL.EF;
using Interfaces.DAL.DataContext;
using Interfaces.DAL.UnitOfWork;
using PlantDataMVC.Entities.Context;
using PlantDataMVC.Entities.Models;
using UnitTest.Utils.DAL;
using Xunit;
using Xunit.Abstractions;

namespace PlantDataMVC.Tests.DAL.IntegrationTests
{
    public class SiteRepositoryTest : IntegrationTestBase
    {
        #region Setup/Teardown
        public SiteRepositoryTest(ITestOutputHelper output)
        {
            _output = output;
        }
        #endregion

        private readonly ITestOutputHelper _output;

        [Fact]
        public void CanCreateSiteAndReturnIdentityWithSaveChanges()
        {
            using (IDataContextAsync plantDataDbContext = new PlantDataDbContext())
            using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(plantDataDbContext))
            {
                // Arrange
                var requestSite = SiteBuilder.aSite().withNoId().Build();
                var repository = unitOfWork.Repository<Site>();

                // Act
                var returnedSite = repository.Add(requestSite);
                unitOfWork.SaveChanges();

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
            using (IDataContextAsync plantDataDbContext = new PlantDataDbContext())
            using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(plantDataDbContext))
            {
                var requestSite = SiteBuilder.aSite().withNoId().Build();
                var repository = unitOfWork.Repository<Site>();

                // Act
                var returnedSite = repository.Add(requestSite);
                unitOfWork.SaveChanges();

                addedSiteId = returnedSite.Id;
            }

            // Update with one context
            using (IDataContextAsync plantDataDbContext = new PlantDataDbContext())
            using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(plantDataDbContext))
            {
                // Arrange
                var repository = unitOfWork.Repository<Site>();
                var site = repository.GetItemById(addedSiteId);

                // Act
                site.Latitude = siteLatitude;
                site.Longitude = siteLongitude;

                try
                {
                    repository.Save(site);
                    unitOfWork.SaveChanges();
                }
                catch (DbEntityValidationException)
                {
                }
            }

            // Retrieve with another
            using (IDataContextAsync plantDataDbContext = new PlantDataDbContext())
            using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(plantDataDbContext))
            {
                var repository = unitOfWork.Repository<Site>();
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
            using (IDataContextAsync plantDataDbContext = new PlantDataDbContext())
            using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(plantDataDbContext))
            {
                var requestSite = SiteBuilder.aSite().withNoId().Build();
                var repository = unitOfWork.Repository<Site>();

                // Act
                var returnedSite = repository.Add(requestSite);
                unitOfWork.SaveChanges();

                addedSiteId = returnedSite.Id;
            }

            using (IDataContextAsync plantDataDbContext = new PlantDataDbContext())
            using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(plantDataDbContext))
            {
                // Arrange
                var repository = unitOfWork.Repository<Site>();
                var site = repository.GetItemById(addedSiteId);

                // Act
                site.Latitude = siteLatitude;
                site.Longitude = siteLongitude;

                try
                {
                    var updatedSite = repository.Save(site);
                    unitOfWork.SaveChanges();
                }
                catch (DbEntityValidationException ex)
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