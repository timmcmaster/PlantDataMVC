using FluentAssertions;
using Framework.Domain.EF;
using Interfaces.Domain.UnitOfWork;
using PlantDataMVC.Entities.Context;
using PlantDataMVC.Entities.EntityModels;
using System.Configuration;
using UnitTest.Utils.Domain;
using Xunit;
using Xunit.Abstractions;

namespace PlantDataMVC.Domain.Tests.IntegrationTests
{
    public class GenusRepositoryTests : IntegrationTestBase
    {
        #region Setup/Teardown
        public GenusRepositoryTests(ITestOutputHelper output, DbFixture dbFixture) : base(dbFixture) 
        {
            _output = output;
            _plantDataDbConnectionString = ConfigurationManager.ConnectionStrings["PlantDataDbContext"].ConnectionString;
        }
        #endregion

        private readonly ITestOutputHelper _output;
        private readonly string _plantDataDbConnectionString;

        [Fact]
        public void Add_UsingCreatedRepository_ReturnsIdAfterSaveChanges()
        {
            using (IDbContext plantDataDbContext = new PlantDataDbContext(_plantDataDbConnectionString))
            using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(plantDataDbContext))
            {
                // Arrange
                var requestGenus = GenusBuilder.aGenus().withNoId().Build();
                var repository = new EFRepository<GenusEntityModel>(plantDataDbContext);

                // Act
                repository.Add(requestGenus);
                unitOfWork.SaveChanges();
                var returnedGenus = repository.GetItemById(requestGenus.Id);

                // Assert
                returnedGenus.Should().NotBeNull();
                returnedGenus.Id.Should().NotBe(0);
                _output.WriteLine("returnedGenus.Id: {0}", returnedGenus.Id);
            }
        }

        [Fact]
        public void Add_UsingUnitOfWorkRepository_ReturnsIdAfterSaveChanges()
        {
            using (IDbContext plantDataDbContext = new PlantDataDbContext(_plantDataDbConnectionString))
            using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(plantDataDbContext))
            {
                // Arrange
                var requestGenus = GenusBuilder.aGenus().withNoId().Build();
                var repository = unitOfWork.Repository<GenusEntityModel>();

                // Act
                repository.Add(requestGenus);
                unitOfWork.SaveChanges();
                var returnedGenus = repository.GetItemById(requestGenus.Id);

                // Assert
                returnedGenus.Should().NotBeNull();
                returnedGenus.Id.Should().NotBe(0);
                _output.WriteLine("returnedGenus.Id: {0}", returnedGenus.Id);
            }
        }

        //[Fact]
        //public void CanUpdateSiteAndGetBackSameWithSameContext()
        //{
        //    int addedSiteId;
        //    var siteLatitude = 1.12345m;
        //    var siteLongitude = 1.12345m;

        //    // Add a site so that we can update it
        //    using (IDataContextAsync plantDataDbContext = new PlantDataDbContext())
        //    using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(plantDataDbContext))
        //    {
        //        var requestSite = SiteBuilder.aSite().withNoId().Build();
        //        var repository = unitOfWork.Repository<Site>();

        //        // Act
        //        var returnedSite = repository.Add(requestSite);
        //        unitOfWork.SaveChanges();

        //        addedSiteId = returnedSite.Id;
        //    }

        //    using (IDataContextAsync plantDataDbContext = new PlantDataDbContext())
        //    using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(plantDataDbContext))
        //    {
        //        // Arrange
        //        var repository = unitOfWork.Repository<Site>();
        //        var site = repository.GetItemById(addedSiteId);

        //        // Act
        //        site.Latitude = siteLatitude;
        //        site.Longitude = siteLongitude;

        //        try
        //        {
        //            var updatedSite = repository.Save(site);
        //            unitOfWork.SaveChanges();
        //        }
        //        catch (DbEntityValidationException ex)
        //        {

        //        }

        //        var retrievedSite = repository.GetItemById(addedSiteId);

        //        // Assert
        //        retrievedSite.Should().NotBeNull();
        //        retrievedSite.Should().BeEquivalentTo(site, options => options
        //                                                                .Including(s => s.Latitude)
        //                                                                .Including(s => s.Longitude));
        //    }
        //}

        //[Fact]
        //public void CanUpdateSiteAndGetBackSameWithDiffContext()
        //{
        //    int addedSiteId;
        //    var siteLatitude = 1.12345m;
        //    var siteLongitude = 1.12345m;

        //    // Add a site so that we can update it
        //    using (IDataContextAsync plantDataDbContext = new PlantDataDbContext())
        //    using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(plantDataDbContext))
        //    {
        //        var requestSite = SiteBuilder.aSite().withNoId().Build();
        //        var repository = unitOfWork.Repository<Site>();

        //        // Act
        //        var returnedSite = repository.Add(requestSite);
        //        unitOfWork.SaveChanges();

        //        addedSiteId = returnedSite.Id;
        //    }

        //    // Update with one context
        //    using (IDataContextAsync plantDataDbContext = new PlantDataDbContext())
        //    using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(plantDataDbContext))
        //    {
        //        // Arrange
        //        var repository = unitOfWork.Repository<Site>();
        //        var site = repository.GetItemById(addedSiteId);

        //        // Act
        //        site.Latitude = siteLatitude;
        //        site.Longitude = siteLongitude;

        //        try
        //        {
        //            var updatedSite = repository.Save(site);
        //            unitOfWork.SaveChanges();
        //        }
        //        catch (DbEntityValidationException ex)
        //        {
        //        }
        //    }

        //    // Retrieve with another
        //    using (IDataContextAsync plantDataDbContext = new PlantDataDbContext())
        //    using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(plantDataDbContext))
        //    {
        //        var repository = unitOfWork.Repository<Site>();
        //        var retrievedSite = repository.GetItemById(addedSiteId);

        //        // Assert
        //        retrievedSite.Should().NotBeNull();
        //        retrievedSite.Latitude.Should().Be(siteLatitude);
        //        retrievedSite.Longitude.Should().Be(siteLongitude);
        //    }
        //}
    }
}