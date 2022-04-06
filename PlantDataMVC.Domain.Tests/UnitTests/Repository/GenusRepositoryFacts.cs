using FluentAssertions;
using Framework.Domain.EF;
using Interfaces.Domain.Repository;
using Interfaces.Domain.UnitOfWork;
using PlantDataMVC.Entities.Context;
using PlantDataMVC.Entities.Models;
using PlantDataMVC.Repository.Repositories;
using UnitTest.Utils.Domain;
using Xunit;

namespace PlantDataMVC.Domain.Tests.UnitTests.Repository
{
    public class GenusRepositoryFacts
    {
        [Fact]
        public void CanAddItemWithId()
        {
            using (IDbContext plantDataFakeDbContext = new FakePlantDataDbContext())
            using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(plantDataFakeDbContext))
            {
                // Arrange
                IRepositoryAsync<Genus> genusRepository = new EFRepository<Genus>(plantDataFakeDbContext);

                var genus = GenusBuilder.aGenus().withId().withLatinName("Eremophila").Build();

                // Act
                genusRepository.Add(genus);
                unitOfWork.SaveChanges();
                var addedGenus = genusRepository.GetItemById(genus.Id);

                // Assert
                addedGenus.Should().NotBeNull();

                addedGenus.Should().BeEquivalentTo(genus, options => options
                                                       .Including(g => g.LatinName));
            }
        }

        [Fact]
        public void CanAddItemWithoutId()
        {
            using (IDbContext plantDataFakeDbContext = new FakePlantDataDbContext())
            using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(plantDataFakeDbContext))
            {
                // Arrange
                var repository = unitOfWork.Repository<Genus>();
                var genus = GenusBuilder.aGenus().withNoId().withLatinName("Eremophila").Build();

                // Act
                repository.Add(genus);
                var addedGenus = repository.GetItemById(genus.Id);

                // Assert
                addedGenus.Should().NotBeNull();

                addedGenus.Should().BeEquivalentTo(genus, options => options
                                                       .Including(g => g.LatinName));
            }
        }

        [Fact]
        public void CanGetItemById()
        {
            using (IDbContext plantDataFakeDbContext = new FakePlantDataDbContext())
            using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(plantDataFakeDbContext))
            {
                // Arrange
                var repository = unitOfWork.Repository<Genus>();
                var genus = GenusBuilder.aGenus().withNoId().withLatinName("Eremophila").Build();

                repository.Add(genus);

                // TODO: Does Id only get set if SaveChanges is called on UnitOfWork? 
                //       Or are we calling with value of 0?

                // Act
                var entity = repository.GetItemById(genus.Id);

                // Assert
                entity.Should().NotBeNull();
                entity.Should().BeOfType<Genus>();
                entity.Should().BeEquivalentTo(genus);
            }
        }

        [Fact]
        public void CanGetItemByLatinName()
        {
            using (IDbContext plantDataFakeDbContext = new FakePlantDataDbContext())
            using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(plantDataFakeDbContext))
            {
                var latinName = "Eremophila";

                // Arrange
                var repository = unitOfWork.Repository<Genus>();
                var genus = GenusBuilder.aGenus().withNoId().withLatinName(latinName).Build();

                repository.Add(genus);

                // TODO: Does Id only get set if SaveChanges is called on UnitOfWork? 
                //       Or are we calling with value of 0?

                // Act
                var entity = repository.GetItemByLatinName(latinName);

                // Assert
                entity.Should().NotBeNull();
                entity.Should().BeOfType<Genus>();
                entity.Should().BeEquivalentTo(genus);
            }
        }
    }
}