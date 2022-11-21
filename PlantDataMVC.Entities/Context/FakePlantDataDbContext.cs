using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Framework.Domain.EF;
using PlantDataMVC.Entities.Interfaces;
using PlantDataMVC.Entities.EntityModels;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace PlantDataMVC.Entities.Context
{
    public class FakePlantDataDbContext : FakeDbContext, IPlantDataDbContext
    {
        public ChangeTracker _changeTracker;
        
        //public DbContextConfiguration _configuration;
        //public DatabaseFacade _database;

        public FakePlantDataDbContext()
        {
            AddFakeDbSet<GenusEntityModel, GenusDbSet>();
            AddFakeDbSet<JournalEntryEntityModel, JournalEntryDbSet>();
            AddFakeDbSet<JournalEntryTypeEntityModel, JournalEntryTypeDbSet>();
            AddFakeDbSet<PlantStockEntityModel, PlantStockDbSet>();
            AddFakeDbSet<PriceListTypeEntityModel, PriceListTypeDbSet>();
            AddFakeDbSet<ProductPriceEntityModel, ProductPriceDbSet>();
            AddFakeDbSet<ProductTypeEntityModel, ProductTypeDbSet>();
            AddFakeDbSet<SaleEventEntityModel, SaleEventDbSet>();
            AddFakeDbSet<SeedBatchEntityModel, SeedBatchDbSet>();
            AddFakeDbSet<SeedTrayEntityModel, SeedTrayDbSet>();
            AddFakeDbSet<SiteEntityModel, SiteDbSet>();
            AddFakeDbSet<SpeciesEntityModel, SpeciesDbSet>();
        }

        #region IPlantDataDbContext Members
        public DbSet<GenusEntityModel> Genus
        {
            get => Set<GenusEntityModel>();
            set => throw new NotImplementedException();
        }

        public DbSet<JournalEntryEntityModel> JournalEntries
        {
            get => Set<JournalEntryEntityModel>();
            set => throw new NotImplementedException();
        }

        public DbSet<JournalEntryTypeEntityModel> JournalEntryTypes
        {
            get => Set<JournalEntryTypeEntityModel>();
            set => throw new NotImplementedException();
        }

        public DbSet<PlantStockEntityModel> PlantStocks
        {
            get => Set<PlantStockEntityModel>();
            set => throw new NotImplementedException();
        }

        public DbSet<PriceListTypeEntityModel> PriceListTypes
        {
            get => Set<PriceListTypeEntityModel>();
            set => throw new NotImplementedException();
        }

        public DbSet<ProductPriceEntityModel> ProductPrices
        {
            get => Set<ProductPriceEntityModel>();
            set => throw new NotImplementedException();
        }

        public DbSet<ProductTypeEntityModel> ProductTypes
        {
            get => Set<ProductTypeEntityModel>();
            set => throw new NotImplementedException();
        }

        public DbSet<SaleEventEntityModel> SaleEvents
        {
            get => Set<SaleEventEntityModel>();
            set => throw new NotImplementedException();
        }

        public DbSet<SeedBatchEntityModel> SeedBatches
        {
            get => Set<SeedBatchEntityModel>();
            set => throw new NotImplementedException();
        }

        public DbSet<SeedTrayEntityModel> SeedTrays
        {
            get => Set<SeedTrayEntityModel>();
            set => throw new NotImplementedException();
        }

        public DbSet<SiteEntityModel> Sites
        {
            get => Set<SiteEntityModel>();
            set => throw new NotImplementedException();
        }

        public DbSet<SpeciesEntityModel> Species
        {
            get => Set<SpeciesEntityModel>();
            set => throw new NotImplementedException();
        }

        //public ChangeTracker ChangeTracker
        //{
        //    get => _changeTracker;
        //}

        //public DbContextConfiguration Configuration
        //{
        //    get => _configuration;
        //}

        //public DatabaseFacade Database
        //{
        //    get => _database;
        //}

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