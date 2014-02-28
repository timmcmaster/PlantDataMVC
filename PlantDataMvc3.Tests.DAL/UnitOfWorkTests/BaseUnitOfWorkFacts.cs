using Xunit;
using PlantDataMvc3.DAL.Interfaces;
using System;

namespace PlantDataMvc3.Tests.DAL
{
    public abstract class BaseUnitOfWorkFacts: IDisposable
    {
        protected BaseUnitOfWorkFacts()
        {
        }

        protected abstract IUnitOfWork CreateUnitOfWork();
        
        [Fact]
        public void CanCreate()
        {
            // Act
            var sut = CreateUnitOfWork();

            // Assert
            var iUnitOfWork = Assert.IsAssignableFrom<IUnitOfWork>(sut);
            Assert.NotNull(sut);
        }

        [Fact]
        public void HasGenusRepository()
        {
            // Arrange
            var sut = CreateUnitOfWork();

            // Act
            var repository = sut.GenusRepository;

            // Assert
            var iRepository = Assert.IsAssignableFrom<IGenusRepository>(repository);
            Assert.NotNull(iRepository);
        }

        [Fact]
        public void HasSpeciesRepository()
        {
            // Arrange
            var sut = CreateUnitOfWork();

            // Act
            var repository = sut.SpeciesRepository;

            // Assert
            var iRepository = Assert.IsAssignableFrom<ISpeciesRepository>(repository);
            Assert.NotNull(iRepository);
        }

        [Fact]
        public void HasSeedBatchRepository()
        {
            // Arrange
            var sut = CreateUnitOfWork();

            // Act
            var repository = sut.SeedBatchRepository;

            // Assert
            var iRepository = Assert.IsAssignableFrom<ISeedBatchRepository>(repository);
            Assert.NotNull(iRepository);
        }

        [Fact]
        public void HasSeedTrayRepository()
        {
            // Arrange
            var sut = CreateUnitOfWork();

            // Act
            var repository = sut.SeedTrayRepository;

            // Assert
            var iRepository = Assert.IsAssignableFrom<ISeedTrayRepository>(repository);
            Assert.NotNull(iRepository);
        }

        [Fact]
        public void HasPlantStockRepository()
        {
            // Arrange
            var sut = CreateUnitOfWork();

            // Act
            var repository = sut.PlantStockRepository;

            // Assert
            var iRepository = Assert.IsAssignableFrom<IPlantStockRepository>(repository);
            Assert.NotNull(iRepository);
        }

        [Fact]
        public void HasProductTypeRepository()
        {
            // Arrange
            var sut = CreateUnitOfWork();

            // Act
            var repository = sut.ProductTypeRepository;

            // Assert
            var iRepository = Assert.IsAssignableFrom<IProductTypeRepository>(repository);
            Assert.NotNull(iRepository);
        }

        [Fact]
        public void HasJournalEntryRepository()
        {
            // Arrange
            var sut = CreateUnitOfWork();

            // Act
            var repository = sut.JournalEntryRepository;

            // Assert
            var iRepository = Assert.IsAssignableFrom<IJournalEntryRepository>(repository);
            Assert.NotNull(iRepository);
        }

        [Fact]
        public void HasJournalEntryTypeRepository()
        {
            // Arrange
            var sut = CreateUnitOfWork();

            // Act
            var repository = sut.JournalEntryTypeRepository;

            // Assert
            var iRepository = Assert.IsAssignableFrom<IJournalEntryTypeRepository>(repository);
            Assert.NotNull(iRepository);
        }

        public virtual void Dispose()
        {
        }
    }

}