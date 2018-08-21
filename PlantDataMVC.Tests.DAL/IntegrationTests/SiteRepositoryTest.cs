using Framework.DAL.EF;
using Interfaces.DAL.DataContext;
using Interfaces.DAL.UnitOfWork;
using PlantDataMVC.Entities.Context;
using PlantDataMVC.Entities.Models;
using System.Data.Entity.Validation;
using Xunit;

namespace PlantDataMVC.Tests.DAL.IntegrationTests
{
    public class SiteRepositoryTest
    {
        [Fact]
        public void CanUpdateSiteAndGetBackSame()
        {

            using (IDataContextAsync plantDataDBContext = new PlantDataDbContext())
            using (IUnitOfWorkAsync uow = new UnitOfWork(plantDataDBContext))
            {
                // Arrange
                var id = 6;
                var repository = uow.Repository<Site>();
                var site = repository.GetItemById(id);

                // Act
                site.Latitude = 1.5m;
                site.Longitude = 1.5m;

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
    }
}
