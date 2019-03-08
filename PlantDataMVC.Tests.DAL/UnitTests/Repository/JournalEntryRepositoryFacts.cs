﻿using System;
using FluentAssertions;
using Framework.Domain.EF;
using Interfaces.Domain.DataContext;
using Interfaces.Domain.UnitOfWork;
using PlantDataMVC.Entities.Context;
using PlantDataMVC.Entities.Models;
using PlantDataMVC.Repository.Repositories;
using UnitTest.Utils.DAL;
using Xunit;

namespace PlantDataMVC.Domain.Tests.UnitTests.Repository
{
    public class JournalEntryRepositoryFacts
    {
        [Fact]
        public void CanGetTransactionTotalForStockId()
        {
            using (IDataContextAsync plantDataFakeDbContext = new FakePlantDataDbContext())
            using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(plantDataFakeDbContext))
            {
                // Arrange
                // Add genus and species
                var genus = GenusBuilder.aGenus().withLatinName("Acacia").withId().Build();
                unitOfWork.Repository<Genus>().Add(genus);

                var species = SpeciesBuilder
                              .aSpecies()
                              .withGenus(genus)
                              .withSpecificName("macradenia")
                              .withId()
                              .Build();

                var addedSpecies = unitOfWork.Repository<Species>().Add(species);

                // Add product type and stock record
                var productType = ProductTypeBuilder
                                  .aProductType()
                                  .withId()
                                  .Build();

                var addedProductType = unitOfWork.Repository<ProductType>().Add(productType);

                var plantStock = PlantStockBuilder
                                 .aStockItem()
                                 .withId()
                                 .withProductType(addedProductType)
                                 .withSpecies(addedSpecies)
                                 .withQuantity(0)
                                 .Build();

                var addedStock = unitOfWork.Repository<PlantStock>().Add(plantStock);

                // Add transaction types
                var jeTypeAdd = JournalEntryTypeBuilder
                                .aJournalEntryType()
                                .withId()
                                .withName("Gift received")
                                .withEffect(1)
                                .Build();

                var addedTypeAdd = unitOfWork.Repository<JournalEntryType>().Add(jeTypeAdd);

                var jeTypeSale = JournalEntryTypeBuilder
                                 .aJournalEntryType()
                                 .withId()
                                 .withName("Plant sold")
                                 .withEffect(-1)
                                 .Build();

                var addedTypeSale = unitOfWork.Repository<JournalEntryType>().Add(jeTypeSale);

                // Add transactions
                var add27Plants5DaysAgo = JournalEntryBuilder
                                          .aJournalEntry()
                                          .withId()
                                          .withJournalEntryType(addedTypeAdd)
                                          .withPlantStock(addedStock)
                                          .withTransactionDate(DateTime.Today.AddDays(-5))
                                          .withQuantity(27)
                                          .Build();

                var sell12Plants2DaysAgo = JournalEntryBuilder
                                           .aJournalEntry()
                                           .withId()
                                           .withJournalEntryType(addedTypeSale)
                                           .withPlantStock(addedStock)
                                           .withTransactionDate(DateTime.Today.AddDays(-2))
                                           .withQuantity(12)
                                           .Build();

                var sell7PlantsToday = JournalEntryBuilder
                                       .aJournalEntry()
                                       .withId()
                                       .withJournalEntryType(addedTypeSale)
                                       .withPlantStock(addedStock)
                                       .withTransactionDate(DateTime.Today)
                                       .withQuantity(7)
                                       .Build();

                var jnlEntryRepository = unitOfWork.Repository<JournalEntry>();
                jnlEntryRepository.Add(add27Plants5DaysAgo);
                jnlEntryRepository.Add(sell12Plants2DaysAgo);
                jnlEntryRepository.Add(sell7PlantsToday);

                // Act
                var stockCount = jnlEntryRepository.GetStockCountForProduct(addedStock.Id);

                // Assert
                stockCount.Should().Be(8);
            }
        }
    }
}