using Framework.DAL.EF;
using Interfaces.DAL.DataContext;
using Interfaces.DAL.UnitOfWork;
using PlantDataMVC.Entities.Context;
using PlantDataMVC.Entities.Models;
using System.Data.Entity.Validation;
using FluentAssertions;
using UnitTest.Utils.DAL;
using Xunit;
using Xunit.Abstractions;

namespace PlantDataMVC.Tests.DAL.IntegrationTests
{
    public class SiteRepositoryTest : IntegrationTestBase
    {
        private readonly ITestOutputHelper _output;

        public SiteRepositoryTest(ITestOutputHelper output)
        {
            this._output = output;
        }

        [Fact]
        public void CanCreateSiteAndReturnIdentity_withsavechanges()
        {
            using (IDataContextAsync plantDataDBContext = new PlantDataDbContext())
            using (IUnitOfWorkAsync uow = new UnitOfWork(plantDataDBContext))
            {
                // Arrange
                var requestSite = SiteBuilder.aSite().withNoId().Build();
                var repository = uow.Repository<Site>();

                // Act
                var returnedSite = repository.Add(requestSite);
                uow.SaveChanges();

                // Assert
                returnedSite.Should().NotBeNull();
                returnedSite.Id.Should().NotBe(0);
                _output.WriteLine("returnedSite.Id: {0}", returnedSite.Id);
            }
        }

        [Fact]
        public void CanUpdateSiteAndGetBackSameWithSameContext()
        {
            int addedSiteId;
            var siteLatitude = 1.12345m;
            var siteLongitude = 1.12345m;

            // Add a site so that we can update it
            using (IDataContextAsync plantDataDBContext = new PlantDataDbContext())
            using (IUnitOfWorkAsync uow = new UnitOfWork(plantDataDBContext))
            {
                var requestSite = SiteBuilder.aSite().withNoId().Build();
                var repository = uow.Repository<Site>();

                // Act
                var returnedSite = repository.Add(requestSite);
                uow.SaveChanges();

                addedSiteId = returnedSite.Id;
            }

            using (IDataContextAsync plantDataDBContext = new PlantDataDbContext())
            using (IUnitOfWorkAsync uow = new UnitOfWork(plantDataDBContext))
            {
                // Arrange
                var repository = uow.Repository<Site>();
                var site = repository.GetItemById(addedSiteId);

                // Act
                site.Latitude = siteLatitude;
                site.Longitude = siteLongitude;

                try
                {
                    var updatedSite = repository.Save(site);
                    uow.SaveChanges();
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

        [Fact]
        public void CanUpdateSiteAndGetBackSameWithDiffContext()
        {
            int addedSiteId;
            var siteLatitude = 1.12345m;
            var siteLongitude = 1.12345m;

            // Add a site so that we can update it
            using (IDataContextAsync plantDataDBContext = new PlantDataDbContext())
            using (IUnitOfWorkAsync uow = new UnitOfWork(plantDataDBContext))
            {
                var requestSite = SiteBuilder.aSite().withNoId().Build();
                var repository = uow.Repository<Site>();

                // Act
                var returnedSite = repository.Add(requestSite);
                uow.SaveChanges();

                addedSiteId = returnedSite.Id;
            }

            // Update with one context
            using (IDataContextAsync plantDataDBContext = new PlantDataDbContext())
            using (IUnitOfWorkAsync uow = new UnitOfWork(plantDataDBContext))
            {
                // Arrange
                var repository = uow.Repository<Site>();
                var site = repository.GetItemById(addedSiteId);

                // Act
                site.Latitude = siteLatitude;
                site.Longitude = siteLongitude;

                try
                {
                    var updatedSite = repository.Save(site);
                    uow.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                }
            }

            // Retrieve with another
            using (IDataContextAsync plantDataDBContext = new PlantDataDbContext())
            using (IUnitOfWorkAsync uow = new UnitOfWork(plantDataDBContext))
            {
                var repository = uow.Repository<Site>();
                var retrievedSite = repository.GetItemById(addedSiteId);

                // Assert
                retrievedSite.Should().NotBeNull();
                retrievedSite.Latitude.Should().Be(siteLatitude);
                retrievedSite.Longitude.Should().Be(siteLongitude);
            }
        }
    }
}
