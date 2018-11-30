using Framework.DAL.EF;
using Interfaces.DAL.DataContext;
using Interfaces.DAL.UnitOfWork;
using PlantDataMVC.Entities.Context;
using PlantDataMVC.Entities.Models;
using System.Data.Entity.Validation;
using Xunit;
using Xunit.Abstractions;

namespace PlantDataMVC.Tests.DAL.IntegrationTests
{
    public class SiteRepositoryTest
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
                var requestSite = new Site()
                {
                    SiteName = "Test Site 2",
                    Suburb = "Kangaroo Valley",
                    Latitude = 121.00m,
                    Longitude = 44.00m
                };
                var repository = uow.Repository<Site>();

                // Act
                var returnedSite = repository.Add(requestSite);
                uow.SaveChanges();

                // Assert
                Assert.NotNull(returnedSite);
                Assert.NotEqual(0, returnedSite.Id);
                _output.WriteLine("returnedSite.Id: {0}", returnedSite.Id);

            }
        }

        //[Fact]
        //public void CanCreateSiteAndReturnIdentity_retrieveonly()
        //{
        //    using (IDataContextAsync plantDataDBContext = new PlantDataDbContext())
        //    using (IUnitOfWorkAsync uow = new UnitOfWork(plantDataDBContext))
        //    {
        //        // Arrange
        //        var requestSite = new Site()
        //        {
        //            SiteName = "Test Site 1",
        //            Suburb = "Fortitude Valley",
        //            Latitude = 123.00m,
        //            Longitude = 45.00m
        //        };
        //        var repository = uow.Repository<Site>();

        //        // Act
        //        var returnedSite = repository.Add(requestSite);
        //        uow.SaveChanges();


        //        // Assert
        //        Assert.NotNull(returnedSite);
        //        Assert.NotEqual(0, returnedSite.Id);
        //    }
        //}

        [Fact]
        public void CanUpdateSiteAndGetBackSameWithSameContext()
        {
            // TODO: Fix test, as it fails due to being data dependent
            using (IDataContextAsync plantDataDBContext = new PlantDataDbContext())
            using (IUnitOfWorkAsync uow = new UnitOfWork(plantDataDBContext))
            {
                // Arrange
                var id = 6;
                var repository = uow.Repository<Site>();
                var site = repository.GetItemById(id);

                // Act
                site.Latitude = 1.12345m;
                site.Longitude = 1.12345m;

                try { 
                    var updatedSite = repository.Save(site);
                    uow.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {

                }

                var retrievedSite = repository.GetItemById(id);

                // Assert
                Assert.NotNull(retrievedSite);
                Assert.Equal(site.Latitude, retrievedSite.Latitude);
                Assert.Equal(site.Longitude, retrievedSite.Longitude);
            }
        }

        [Fact]
        public void CanUpdateSiteAndGetBackSameWithDiffContext()
        {
            // TODO: Fix test, as it fails due to being data dependent
            var id = 6;
            var siteLatitude = 1.12345m;
            var siteLongitude = 1.12345m;

            // Write with one context
            using (IDataContextAsync plantDataDBContext = new PlantDataDbContext())
            using (IUnitOfWorkAsync uow = new UnitOfWork(plantDataDBContext))
            {
                // Arrange
                var repository = uow.Repository<Site>();
                var site = repository.GetItemById(id);

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

            using (IDataContextAsync plantDataDBContext = new PlantDataDbContext())
            using (IUnitOfWorkAsync uow = new UnitOfWork(plantDataDBContext))
            {
                var repository = uow.Repository<Site>();
                var retrievedSite = repository.GetItemById(id);

                // Assert
                Assert.NotNull(retrievedSite);
                Assert.Equal(siteLatitude, retrievedSite.Latitude);
                Assert.Equal(siteLongitude, retrievedSite.Longitude);
            }
        }
    }
}
