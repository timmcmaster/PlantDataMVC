using Framework.DAL.EF;
using Interfaces.DAL.DataContext;
using Interfaces.DAL.UnitOfWork;
using PlantDataMVC.Entities.Context;
using PlantDataMVC.Entities.Models;
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
                Assert.Equal(addedGenus.LatinName, genus.LatinName);
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
                Assert.Equal(addedGenus.LatinName, genus.LatinName);
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
                Assert.Equal(addedGenus.LatinName, returnedGenus.LatinName);
            }
        }
    }
}