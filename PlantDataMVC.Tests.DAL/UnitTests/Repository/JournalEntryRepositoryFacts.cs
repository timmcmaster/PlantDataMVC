using FluentAssertions;
using Framework.DAL.EF;
using Interfaces.DAL.DataContext;
using Interfaces.DAL.UnitOfWork;
using PlantDataMVC.Entities.Context;
using PlantDataMVC.Entities.Models;
using PlantDataMVC.Repository.Repositories;
using System;
using UnitTest.Utils.DAL;
using Xunit;

namespace PlantDataMVC.Tests.DAL
{
    public class JournalEntryRepositoryFacts
    {
        [Fact]
        public void CanGetTransactionTotalForStockId()
        {
            using (IDataContextAsync plantDataFakeDBContext = new FakePlantDataDbContext())
            using (IUnitOfWorkAsync uow = new UnitOfWork(plantDataFakeDBContext))
            {
                // Arrange
                // Add genus and species
                var genus = GenusBuilder.aGenus().withLatinName("Acacia").withId().Build();
                var addedGenus = uow.Repository<Genus>().Add(genus);
                var species = SpeciesBuilder
                                .aSpecies()
                                .withGenus(genus)
                                .withSpecificName("macradenia")
                                .withId()
                                .Build();
                var addedSpecies = uow.Repository<Species>().Add(species);

                // Add product type and stock record
                var productType = ProductTypeBuilder
                                    .aProductType()
                                    .withId()
                                    .Build();
                var addedProductType = uow.Repository<ProductType>().Add(productType);
                var plantStock = PlantStockBuilder
                                    .aStockItem()
                                    .withId()
                                    .withProductType(addedProductType)
                                    .withSpecies(addedSpecies)
                                    .withQuantity(0)
                                    .Build();
                var addedStock = uow.Repository<PlantStock>().Add(plantStock);

                // Add transaction types
                var jeTypeAdd = JournalEntryTypeBuilder
                                .aJournalEntryType()
                                .withId()
                                .withName("Gift received")
                                .withEffect(1)
                                .Build();
                var addedTypeAdd = uow.Repository<JournalEntryType>().Add(jeTypeAdd);
                var jeTypeSale = JournalEntryTypeBuilder
                                .aJournalEntryType()
                                .withId()
                                .withName("Plant sold")
                                .withEffect(-1)
                                .Build();
                var addedTypeSale = uow.Repository<JournalEntryType>().Add(jeTypeSale);

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

                var jnlEntryRepository = uow.Repository<JournalEntry>();
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