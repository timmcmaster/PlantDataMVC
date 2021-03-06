﻿using FluentAssertions;
using Framework.DAL.EF;
using Interfaces.DAL.DataContext;
using Interfaces.DAL.UnitOfWork;
using PlantDataMVC.Entities.Context;
using PlantDataMVC.Entities.Models;
using PlantDataMVC.Repository.Repositories;
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
                addedGenus.Should().NotBeNull();
                addedGenus.Should().BeEquivalentTo(genus, options => options
                                                                        .Including(g => g.LatinName));
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
                addedGenus.Should().NotBeNull();
                addedGenus.Should().BeEquivalentTo(genus, options => options
                                                                        .Including(g => g.LatinName));
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
                entity.Should().NotBeNull();
                entity.Should().BeOfType<Genus>();
                entity.Should().BeEquivalentTo(addedGenus);
            }
        }

        [Fact]
        public void CanGetItemByLatinName()
        {
            using (IDataContextAsync plantDataFakeDBContext = new FakePlantDataDbContext())
            using (IUnitOfWorkAsync uow = new UnitOfWork(plantDataFakeDBContext))
            {
                var latinName = "Eremophila";

                // Arrange
                var repository = uow.Repository<Genus>();
                var genus = GenusBuilder.aGenus().withNoId().withLatinName(latinName).Build();

                var addedGenus = repository.Add(genus);

                // TODO: Does Id only get set if SaveChanges is called on UnitOfWork? 
                //       Or are we calling with value of 0?

                // Act
                var entity = repository.GenusExtensions().GetItemByLatinName(latinName);

                // Assert
                entity.Should().NotBeNull();
                entity.Should().BeOfType<Genus>();
                entity.Should().BeEquivalentTo(addedGenus);
            }
        }
    }
}