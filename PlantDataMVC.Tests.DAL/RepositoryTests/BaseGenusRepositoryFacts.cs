﻿using Xunit;
using Rhino.Mocks;
using PlantDataMVC.DAL.Interfaces;
using PlantDataMVC.DAL.TestData;
using PlantDataMVC.DAL.Entities;

namespace PlantDataMvc3.Tests.DAL
{
    public abstract class BaseGenusRepositoryFacts
    {
        protected BaseGenusRepositoryFacts()
        {
        }

        protected abstract IGenusRepository CreateGenusRepository();
        

        [Fact]
        public void CanAddItemWithId()
        {
            // Arrange
            var repository = CreateGenusRepository();
            var genus = new Genus() { Id = 5, LatinName = "Eremophila" };

            // Act
            var addedGenus = repository.Add(genus);

            // Assert
            Assert.NotNull(addedGenus);
            //Assert.Equal<int>(5, addedGenus.Id);    // Should ID stay the same?
            Assert.Equal<string>(addedGenus.LatinName, genus.LatinName);
        }

        [Fact]
        public void CanAddItemWithoutId()
        {
            // Arrange
            var repository = CreateGenusRepository();
            var genus = new Genus() { LatinName = "Eremophila" };

            // Act
            var addedGenus = repository.Add(genus);

            // Assert
            Assert.NotNull(addedGenus);
            Assert.Equal<string>(addedGenus.LatinName, genus.LatinName);
        }

        [Fact]
        public void CanGetItemById()
        {
            // Arrange
            var repository = CreateGenusRepository();
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