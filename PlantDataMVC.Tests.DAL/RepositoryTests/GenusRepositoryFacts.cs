using Framework.DAL.DataContext;
using Framework.DAL.EF;
using Framework.DAL.UnitOfWork;
using PlantDataMVC.Entities.Context;
using PlantDataMVC.Entities.Models;
using System.Data.Entity;
using Xunit;

namespace PlantDataMVC.Tests.DAL
{
    public class GenusRepositoryFacts
    {
        [Fact]
        public void CanAddItemWithId()
        {
            using (IDataContextAsync plantDataFakeDBContext = new FakePlantDataDbContext())
            using (IUnitOfWorkAsync uow = new UnitOfWork(plantDataFakeDBContext))
            {
                // Arrange
                var repository = uow.Repository<Genus>();
                var genus = new Genus() { Id = 5, LatinName = "Eremophila" };

                // Act
                var addedGenus = repository.Add(genus);

                // Assert
                Assert.NotNull(addedGenus);
                //Assert.Equal<int>(5, addedGenus.Id);    // Should ID stay the same?
                Assert.Equal<string>(addedGenus.LatinName, genus.LatinName);
            }
        }

        [Fact]
        public void CanAddItemWithoutId()
        {
            using (IDataContextAsync plantDataFakeDBContext = new FakePlantDataDbContext())
            using (IUnitOfWorkAsync uow = new UnitOfWork(plantDataFakeDBContext))
            {
                // Arrange
                var repository = uow.Repository<Genus>();
                var genus = new Genus() { LatinName = "Eremophila" };

                // Act
                var addedGenus = repository.Add(genus);

                // Assert
                Assert.NotNull(addedGenus);
                Assert.Equal<string>(addedGenus.LatinName, genus.LatinName);
            }
        }

        [Fact]
        public void CanGetItemById()
        {
            using (IDataContextAsync plantDataFakeDBContext = new FakePlantDataDbContext())
            using (IUnitOfWorkAsync uow = new UnitOfWork(plantDataFakeDBContext))
            {
                // Arrange
                var repository = uow.Repository<Genus>();
                var genus = new Genus() { LatinName = "Eremophila" };
                var addedGenus = repository.Add(genus);

                // Act
                var entity = repository.GetItemById(addedGenus.Id);

                // Assert
                Assert.NotNull(entity);
                var returnedGenus = Assert.IsAssignableFrom<Genus>(entity);
                Assert.Equal<string>(addedGenus.LatinName, returnedGenus.LatinName);
            }
        }
    }
}