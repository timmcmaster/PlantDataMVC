using Framework.DAL.EF;
using Interfaces.DAL.DataContext;
using Interfaces.DAL.UnitOfWork;
using PlantDataMVC.Entities.Context;
using PlantDataMVC.Entities.Models;
using UnitTest.Utils.DAL;
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
                var genus = GenusBuilder.aGenus().withId().withLatinName("Eremophila").Build();

                // Act
                var addedGenus = repository.Add(genus);

                // Assert
                Assert.NotNull(addedGenus);
                //Assert.Equal<int>(genus.Id, addedGenus.Id);    // Should ID stay the same?
                Assert.Equal(genus.LatinName, addedGenus.LatinName);
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
                var genus = GenusBuilder.aGenus().withNoId().withLatinName("Eremophila").Build();

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
                var genus = GenusBuilder.aGenus().withNoId().withLatinName("Eremophila").Build();

                var addedGenus = repository.Add(genus);

                // TODO: Does Id only get set if SaveChanges is called on UnitOfWork? 
                //       Or are we calling with value of 0?

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