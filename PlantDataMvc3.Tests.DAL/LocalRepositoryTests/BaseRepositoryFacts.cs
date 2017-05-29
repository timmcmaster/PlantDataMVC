using Xunit;
using Rhino.Mocks;
using PlantDataMVC.DAL.LocalInterfaces;

namespace PlantDataMvc3.Tests.DAL
{
    public abstract class BaseRepositoryFacts
    {
        protected BaseRepositoryFacts()
        {
        }

        protected abstract ILocalRepository<ILocalEntity> CreateLocalRepository();
        

        [Fact]
        public void CanAddItemWithId()
        {
            // Arrange
            var repository = CreateLocalRepository();
            var entity = new ILocalEntity() { Id = 5 };

            // Act
            var addedEntity = repository.Add(entity);

            // Assert
            Assert.NotNull(addedEntity);
            //Assert.Equal<int>(5, addedGenus.Id);    // Should ID stay the same?
        }

        [Fact]
        public void CanAddItemWithoutId()
        {
            // Arrange
            var repository = CreateLocalRepository();
            var entity = new ILocalEntity() { };

            // Act
            var addedEntity = repository.Add(entity);

            // Assert
            Assert.NotNull(addedEntity);
        }

        [Fact]
        public void CanGetItemById()
        {
            // Arrange
            var repository = CreateLocalRepository();
            var entity = new ILocalEntity() { };
            var addedEntity = repository.Add(entity);

            // Act
            var retrievedEntity = repository.GetItemById(addedEntity.Id);

            // Assert
            Assert.NotNull(retrievedEntity);
            var returnedEntity = Assert.IsAssignableFrom<ILocalEntity>(retrievedEntity);
        }
    }
}