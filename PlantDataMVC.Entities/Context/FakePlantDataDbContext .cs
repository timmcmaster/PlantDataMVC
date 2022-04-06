using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using Framework.Domain.EF;
using PlantDataMVC.Entities.Interfaces;
using PlantDataMVC.Entities.Models;

namespace PlantDataMVC.Entities.Context
{
    public class FakePlantDataDbContext : FakeDbContext, IPlantDataDbContext
    {
        public DbChangeTracker _changeTracker;
        public DbContextConfiguration _configuration;
        public Database _database;

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

        #region IPlantDataDbContext Members
        public IDbSet<Genus> Genus
        {
            get => Set<Genus>();
            set => throw new NotImplementedException();
        }

        public IDbSet<JournalEntry> JournalEntries
        {
            get => Set<JournalEntry>();
            set => throw new NotImplementedException();
        }

        public IDbSet<JournalEntryType> JournalEntryTypes
        {
            get => Set<JournalEntryType>();
            set => throw new NotImplementedException();
        }

        public IDbSet<PlantStock> PlantStocks
        {
            get => Set<PlantStock>();
            set => throw new NotImplementedException();
        }

        public IDbSet<PriceListType> PriceListTypes
        {
            get => Set<PriceListType>();
            set => throw new NotImplementedException();
        }

        public IDbSet<ProductPrice> ProductPrices
        {
            get => Set<ProductPrice>();
            set => throw new NotImplementedException();
        }

        public IDbSet<ProductType> ProductTypes
        {
            get => Set<ProductType>();
            set => throw new NotImplementedException();
        }

        public IDbSet<SeedBatch> SeedBatches
        {
            get => Set<SeedBatch>();
            set => throw new NotImplementedException();
        }

        public IDbSet<SeedTray> SeedTrays
        {
            get => Set<SeedTray>();
            set => throw new NotImplementedException();
        }

        public IDbSet<Site> Sites
        {
            get => Set<Site>();
            set => throw new NotImplementedException();
        }

        public IDbSet<Species> Species
        {
            get => Set<Species>();
            set => throw new NotImplementedException();
        }

        //public DbChangeTracker ChangeTracker
        //{
        //    get => _changeTracker;
        //}

        //public DbContextConfiguration Configuration
        //{
        //    get => _configuration;
        //}

        public Database Database
        {
            get => _database;
        }

        //public IEnumerable<DbEntityValidationResult> GetValidationErrors()
        //{
        //    throw new NotImplementedException();
        //}

        //public DbSet Set(Type entityType)
        //{
        //    throw new NotImplementedException();
        //}

        //public override string ToString()
        //{
        //    throw new NotImplementedException();
        //}
        #endregion
    }
}