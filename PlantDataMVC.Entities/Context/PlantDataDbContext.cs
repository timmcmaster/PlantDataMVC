using Framework.Domain.EF;
using PlantDataMVC.Entities.Configuration;
using PlantDataMVC.Entities.Interfaces;
using PlantDataMVC.Entities.Models;

using System.Data.Entity;

namespace PlantDataMVC.Entities.Context
{


    public class PlantDataDbContext : DbContext, IPlantDataDbContext
    {
        public IDbSet<Genus> Genus { get; set; } // Genus
        public IDbSet<JournalEntry> JournalEntries { get; set; } // JournalEntry
        public IDbSet<JournalEntryType> JournalEntryTypes { get; set; } // JournalEntryType
        public IDbSet<PlantStock> PlantStocks { get; set; } // PlantStock
        public IDbSet<PriceListType> PriceListTypes { get; set; } // PriceListType
        public IDbSet<ProductPrice> ProductPrices { get; set; } // ProductPrice
        public IDbSet<ProductType> ProductTypes { get; set; } // ProductType
        public IDbSet<SeedBatch> SeedBatches { get; set; } // SeedBatch
        public IDbSet<SeedTray> SeedTrays { get; set; } // SeedTray
        public IDbSet<Site> Sites { get; set; } // Site
        public IDbSet<Species> Species { get; set; } // Species

        static PlantDataDbContext()
        {
            // Disable CodeFirst migrations 
            Database.SetInitializer<PlantDataDbContext>(null);
        }

        public PlantDataDbContext() 
            : base("Name=PlantDataDbContext")
        {
        }

        public PlantDataDbContext(string connectionString)
            : base(connectionString)
        {
        }

        //public PlantDataDbContext(string connectionString, System.Data.Entity.Infrastructure.DbCompiledModel model)
        //    : base(connectionString, model)
        //{
        //}

        public PlantDataDbContext(System.Data.Common.DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        {
        }

        //public PlantDataDbContext(System.Data.Common.DbConnection existingConnection, System.Data.Entity.Infrastructure.DbCompiledModel model, bool contextOwnsConnection)
        //    : base(existingConnection, model, contextOwnsConnection)
        //{
        //}

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        //public bool IsSqlParameterNull(System.Data.SqlClient.SqlParameter param)
        //{
        //    var sqlValue = param.SqlValue;
        //    var nullableValue = sqlValue as System.Data.SqlTypes.INullable;
        //    if (nullableValue != null)
        //        return nullableValue.IsNull;
        //    return (sqlValue == null || sqlValue == System.DBNull.Value);
        //}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new GenusConfiguration());
            modelBuilder.Configurations.Add(new JournalEntryConfiguration());
            modelBuilder.Configurations.Add(new JournalEntryTypeConfiguration());
            modelBuilder.Configurations.Add(new PlantStockConfiguration());
            modelBuilder.Configurations.Add(new PriceListTypeConfiguration());
            modelBuilder.Configurations.Add(new ProductPriceConfiguration());
            modelBuilder.Configurations.Add(new ProductTypeConfiguration());
            modelBuilder.Configurations.Add(new SeedBatchConfiguration());
            modelBuilder.Configurations.Add(new SeedTrayConfiguration());
            modelBuilder.Configurations.Add(new SiteConfiguration());
            modelBuilder.Configurations.Add(new SpeciesConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public EntityState GetState<TEntity>(TEntity entity) where TEntity : class
        {
            return Entry(entity).State;
        }

        public void SetState<TEntity>(TEntity entity, EntityState entityState)
        {
            Entry(entity).State = entityState;
        }

        //public static DbModelBuilder CreateModel(DbModelBuilder modelBuilder, string schema)
        //{
        //    modelBuilder.Configurations.Add(new GenusConfiguration(schema));
        //    modelBuilder.Configurations.Add(new JournalEntryConfiguration(schema));
        //    modelBuilder.Configurations.Add(new JournalEntryTypeConfiguration(schema));
        //    modelBuilder.Configurations.Add(new PlantStockConfiguration(schema));
        //    modelBuilder.Configurations.Add(new PriceListTypeConfiguration(schema));
        //    modelBuilder.Configurations.Add(new ProductPriceConfiguration(schema));
        //    modelBuilder.Configurations.Add(new ProductTypeConfiguration(schema));
        //    modelBuilder.Configurations.Add(new SeedBatchConfiguration(schema));
        //    modelBuilder.Configurations.Add(new SeedTrayConfiguration(schema));
        //    modelBuilder.Configurations.Add(new SiteConfiguration(schema));
        //    modelBuilder.Configurations.Add(new SpeciesConfiguration(schema));

        //    return modelBuilder;
        //}
    }
}
