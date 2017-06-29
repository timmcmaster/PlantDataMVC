using PlantDataMVC.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlantDataMVC.Entities.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Threading;

namespace PlantDataMVC.Entities.Context
{
    public class MyFakePlantDataDbContext : FakeDbContext, IPlantDataDbContext
    {
        public MyFakePlantDataDbContext()
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

        public DbSet<Genus> Genus { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DbSet<JournalEntry> JournalEntries { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DbSet<JournalEntryType> JournalEntryTypes { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DbSet<PlantStock> PlantStocks { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DbSet<PriceListType> PriceListTypes { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DbSet<ProductPrice> ProductPrices { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DbSet<ProductType> ProductTypes { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DbSet<SeedBatch> SeedBatches { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DbSet<SeedTray> SeedTrays { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DbSet<Site> Sites { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DbSet<Species> Species { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public DbChangeTracker _changeTracker;
        public DbChangeTracker ChangeTracker { get { return _changeTracker; } }
        public DbContextConfiguration _configuration;
        public DbContextConfiguration Configuration { get { return _configuration; } }
        public Database _database;
        public Database Database { get { return _database; } }
        public DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class
        {
            throw new System.NotImplementedException();
        }
        public DbEntityEntry Entry(object entity)
        {
            throw new System.NotImplementedException();
        }
        public IEnumerable<DbEntityValidationResult> GetValidationErrors()
        {
            throw new System.NotImplementedException();
        }
        public DbSet Set(System.Type entityType)
        {
            throw new System.NotImplementedException();
        }
        public override string ToString()
        {
            throw new System.NotImplementedException();
        }
    }
}
