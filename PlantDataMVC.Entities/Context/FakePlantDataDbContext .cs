using Framework.DAL.EF;
using PlantDataMVC.Entities.Interfaces;
using PlantDataMVC.Entities.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;

namespace PlantDataMVC.Entities.Context
{
    public class FakePlantDataDbContext : FakeDbContext, IPlantDataDbContext
    {
        public FakePlantDataDbContext()
        {
            AddFakeDbSet<Genus, GenusDbSet>();
            AddFakeDbSet<JournalEntry, JournalEntryDbSet>();
            AddFakeDbSet<JournalEntryType, JournalEntryTypeDbSet>();
            AddFakeDbSet<PlantStock, PlantStockDbSet>();
            AddFakeDbSet<PriceListType, PriceListTypeDbSet>();
            AddFakeDbSet<ProductPrice, ProductPriceDbSet>();
            AddFakeDbSet<ProductType, ProductTypeDbSet>();
            AddFakeDbSet<SeedBatch, SeedBatchDbSet>();
            AddFakeDbSet<SeedTray, SeedTrayDbSet>();
            AddFakeDbSet<Site, SiteDbSet>();
            AddFakeDbSet<Species, SpeciesDbSet>();
        }

        public DbSet<Genus> Genus { get => Set<Genus>(); set => throw new NotImplementedException(); }
        public DbSet<JournalEntry> JournalEntries { get => Set<JournalEntry>(); set => throw new NotImplementedException(); }
        public DbSet<JournalEntryType> JournalEntryTypes { get => Set<JournalEntryType>(); set => throw new NotImplementedException(); }
        public DbSet<PlantStock> PlantStocks { get => Set<PlantStock>(); set => throw new NotImplementedException(); }
        public DbSet<PriceListType> PriceListTypes { get => Set<PriceListType>(); set => throw new NotImplementedException(); }
        public DbSet<ProductPrice> ProductPrices { get => Set<ProductPrice>(); set => throw new NotImplementedException(); }
        public DbSet<ProductType> ProductTypes { get => Set<ProductType>(); set => throw new NotImplementedException(); }
        public DbSet<SeedBatch> SeedBatches { get => Set<SeedBatch>(); set => throw new NotImplementedException(); }
        public DbSet<SeedTray> SeedTrays { get => Set<SeedTray>(); set => throw new NotImplementedException(); }
        public DbSet<Site> Sites { get => Set<Site>(); set => throw new NotImplementedException(); }
        public DbSet<Species> Species { get => Set<Species>(); set => throw new NotImplementedException(); }

        public DbChangeTracker _changeTracker;
        public DbChangeTracker ChangeTracker { get => _changeTracker; }
        public DbContextConfiguration _configuration;
        public DbContextConfiguration Configuration { get => _configuration; }
        public Database _database;
        public Database Database { get => _database; }
        public DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class
        {
            throw new NotImplementedException();
        }
        public DbEntityEntry Entry(object entity)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<DbEntityValidationResult> GetValidationErrors()
        {
            throw new NotImplementedException();
        }
        public DbSet Set(Type entityType)
        {
            throw new NotImplementedException();
        }
        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
