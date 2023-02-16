using FluentAssertions;
using Framework.Domain.EF;
using Interfaces.Domain.UnitOfWork;
using PlantDataMVC.Entities.Context;
using PlantDataMVC.Entities.EntityModels;
using PlantDataMVC.Repository.Interfaces;
using System;
using UnitTest.Utils.Domain;
using Xunit;

namespace PlantDataMVC.Domain.Tests.UnitTests.Repository
{
    public class RepositoryOfJournalEntryFacts
    {
        [Fact]
        public void CanGetTransactionTotalForStockId()
        {
            using (IDbContext plantDataFakeDbContext = new FakePlantDataDbContext())
            using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(plantDataFakeDbContext))
            {
                // Arrange
                // Add genus and species
                var genus = GenusBuilder.aGenus().withLatinName("Acacia").withId().Build();
                unitOfWork.Repository<GenusEntityModel>().Add(genus);

                var species = SpeciesBuilder
                              .aSpecies()
                              .withGenus(genus)
                              .withSpecificName("macradenia")
                              .withId()
                              .Build();

                unitOfWork.Repository<SpeciesEntityModel>().Add(species);
                var addedSpecies = unitOfWork.Repository<SpeciesEntityModel>().GetItemById(species.Id);
                // Add product type and stock record
                var productType = ProductTypeBuilder
                                  .aProductType()
                                  .withId()
                                  .Build();

                unitOfWork.Repository<ProductTypeEntityModel>().Add(productType);
                var addedProductType = unitOfWork.Repository<ProductTypeEntityModel>().GetItemById(productType.Id);

                var plantStock = PlantStockBuilder
                                 .aStockItem()
                                 .withId()
                                 .withProductType(addedProductType)
                                 .withSpecies(addedSpecies)
                                 .withQuantity(0)
                                 .Build();

                unitOfWork.Repository<PlantStockEntityModel>().Add(plantStock);
                var addedStock = unitOfWork.Repository<PlantStockEntityModel>().GetItemById(plantStock.Id);

                // Add transaction types
                var jeTypeAdd = JournalEntryTypeBuilder
                                .aJournalEntryType()
                                .withId()
                                .withName("Gift received")
                                .withEffect(1)
                                .Build();

                unitOfWork.Repository<JournalEntryTypeEntityModel>().Add(jeTypeAdd);
                var addedTypeAdd = unitOfWork.Repository<JournalEntryTypeEntityModel>().GetItemById(jeTypeAdd.Id);

                var jeTypeSale = JournalEntryTypeBuilder
                                 .aJournalEntryType()
                                 .withId()
                                 .withName("Plant sold")
                                 .withEffect(-1)
                                 .Build();

                unitOfWork.Repository<JournalEntryTypeEntityModel>().Add(jeTypeSale);
                var addedTypeSale = unitOfWork.Repository<JournalEntryTypeEntityModel>().GetItemById(jeTypeSale.Id);

                // Add transactions
                var add27Plants5DaysAgo = JournalEntryBuilder
                                          .aJournalEntry()
                                          .withId()
                                          .withJournalEntryType(addedTypeAdd)
                                          .withProductType(addedProductType)
                                          .withSpecies(addedSpecies)
                                          .withTransactionDate(DateTime.Today.AddDays(-5))
                                          .withQuantity(27)
                                          .Build();

                var sell12Plants2DaysAgo = JournalEntryBuilder
                                           .aJournalEntry()
                                           .withId()
                                           .withJournalEntryType(addedTypeSale)
                                           .withProductType(addedProductType)
                                           .withSpecies(addedSpecies)
                                           .withTransactionDate(DateTime.Today.AddDays(-2))
                                           .withQuantity(12)
                                           .Build();

                var sell7PlantsToday = JournalEntryBuilder
                                       .aJournalEntry()
                                       .withId()
                                       .withJournalEntryType(addedTypeSale)
                                       .withProductType(addedProductType)
                                       .withSpecies(addedSpecies)
                                       .withTransactionDate(DateTime.Today)
                                       .withQuantity(7)
                                       .Build();

                var jnlEntryRepository = unitOfWork.Repository<JournalEntryEntityModel>() as IJournalEntryRepository;
                jnlEntryRepository.Add(add27Plants5DaysAgo);
                jnlEntryRepository.Add(sell12Plants2DaysAgo);
                jnlEntryRepository.Add(sell7PlantsToday);

                // Act
                var stockCount = jnlEntryRepository.GetStockCountForSpeciesAndProduct(addedSpecies.Id, addedProductType.Id);

                // Assert
                stockCount.Should().Be(8);
            }
        }
    }
}