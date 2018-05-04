using Xunit;
using System;
using Interfaces.DAL.UnitOfWork;
using Framework.DAL.EF;
using Interfaces.DAL.DataContext;
using PlantDataMVC.Entities.Context;

namespace PlantDataMvc3.Tests.DAL
{
    public class BaseUnitOfWorkFacts: IDisposable
    {
        public BaseUnitOfWorkFacts()
        {
        }

        [Fact]
        public void HasGenusRepository()
        {
            // Arrange
            using (IDataContextAsync plantDataFakeDBContext = new MyFakePlantDataDbContext())
            using (IUnitOfWorkAsync sut = new UnitOfWork(plantDataFakeDBContext))
            {
                // Act
                var repository = sut.GenusRepository;

                // Assert
                var iRepository = Assert.IsAssignableFrom<IGenusRepository>(repository);
                Assert.NotNull(iRepository);
            }
        }

        [Fact]
        public void HasSpeciesRepository()
        {
            // Arrange
            using (IDataContextAsync plantDataFakeDBContext = new MyFakePlantDataDbContext())
            using (IUnitOfWorkAsync sut = new UnitOfWork(plantDataFakeDBContext))
            {

                // Act
                var repository = sut.SpeciesRepository;

                // Assert
                var iRepository = Assert.IsAssignableFrom<ISpeciesRepository>(repository);
                Assert.NotNull(iRepository);
            }
        }

        [Fact]
        public void HasSeedBatchRepository()
        {
            // Arrange
            using (IDataContextAsync plantDataFakeDBContext = new MyFakePlantDataDbContext())
            using (IUnitOfWorkAsync sut = new UnitOfWork(plantDataFakeDBContext))
            {

                // Act
                var repository = sut.SeedBatchRepository;

                // Assert
                var iRepository = Assert.IsAssignableFrom<ISeedBatchRepository>(repository);
                Assert.NotNull(iRepository);
            }
        }

        [Fact]
        public void HasSeedTrayRepository()
        {
            // Arrange
            using (IDataContextAsync plantDataFakeDBContext = new MyFakePlantDataDbContext())
            using (IUnitOfWorkAsync sut = new UnitOfWork(plantDataFakeDBContext))
            {

                // Act
                var repository = sut.SeedTrayRepository;

                // Assert
                var iRepository = Assert.IsAssignableFrom<ISeedTrayRepository>(repository);
                Assert.NotNull(iRepository);
            }
        }

        [Fact]
        public void HasPlantStockRepository()
        {
            // Arrange
            using (IDataContextAsync plantDataFakeDBContext = new MyFakePlantDataDbContext())
            using (IUnitOfWorkAsync sut = new UnitOfWork(plantDataFakeDBContext))
            {

                // Act
                var repository = sut.PlantStockRepository;

                // Assert
                var iRepository = Assert.IsAssignableFrom<IPlantStockRepository>(repository);
                Assert.NotNull(iRepository);
            }
        }

        [Fact]
        public void HasProductTypeRepository()
        {
            // Arrange
            using (IDataContextAsync plantDataFakeDBContext = new MyFakePlantDataDbContext())
            using (IUnitOfWorkAsync sut = new UnitOfWork(plantDataFakeDBContext))
            {

                // Act
                var repository = sut.ProductTypeRepository;

                // Assert
                var iRepository = Assert.IsAssignableFrom<IProductTypeRepository>(repository);
                Assert.NotNull(iRepository);
            }
        }

        [Fact]
        public void HasJournalEntryRepository()
        {
            // Arrange
            using (IDataContextAsync plantDataFakeDBContext = new MyFakePlantDataDbContext())
            using (IUnitOfWorkAsync sut = new UnitOfWork(plantDataFakeDBContext))
            {

                // Act
                var repository = sut.JournalEntryRepository;

                // Assert
                var iRepository = Assert.IsAssignableFrom<IJournalEntryRepository>(repository);
                Assert.NotNull(iRepository);
            }
        }

        [Fact]
        public void HasJournalEntryTypeRepository()
        {
            // Arrange
            using (IDataContextAsync plantDataFakeDBContext = new MyFakePlantDataDbContext())
            using (IUnitOfWorkAsync sut = new UnitOfWork(plantDataFakeDBContext))
            {

                // Act
                var repository = sut.JournalEntryTypeRepository;

                // Assert
                var iRepository = Assert.IsAssignableFrom<IJournalEntryTypeRepository>(repository);
                Assert.NotNull(iRepository);
            }
        }

        public virtual void Dispose()
        {
        }
    }

}