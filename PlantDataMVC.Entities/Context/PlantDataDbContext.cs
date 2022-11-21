using Framework.Domain.EF;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PlantDataMVC.Entities.Configuration;
using PlantDataMVC.Entities.Interfaces;
using PlantDataMVC.Entities.EntityModels;

namespace PlantDataMVC.Entities.Context
{
    public class PlantDataDbContext : DbContext, IPlantDataDbContext
    {
        private string _connectionString;

        public DbSet<GenusEntityModel> Genus { get; set; } // Genus
        public DbSet<JournalEntryEntityModel> JournalEntries { get; set; } // JournalEntry
        public DbSet<JournalEntryTypeEntityModel> JournalEntryTypes { get; set; } // JournalEntryType
        public DbSet<PlantStockEntityModel> PlantStocks { get; set; } // PlantStock
        public DbSet<PriceListTypeEntityModel> PriceListTypes { get; set; } // PriceListType
        public DbSet<ProductPriceEntityModel> ProductPrices { get; set; } // ProductPrice
        public DbSet<ProductTypeEntityModel> ProductTypes { get; set; } // ProductType
        public DbSet<SaleEventEntityModel> SaleEvents { get; set; } // SaleEvent
        public DbSet<SeedBatchEntityModel> SeedBatches { get; set; } // SeedBatch
        public DbSet<SeedTrayEntityModel> SeedTrays { get; set; } // SeedTray
        public DbSet<SiteEntityModel> Sites { get; set; } // Site
        public DbSet<SpeciesEntityModel> Species { get; set; } // Species

        //static PlantDataDbContext()
        //{
        //    // Disable CodeFirst migrations 
        //    //Database.SetInitializer<PlantDataDbContext>(null);
        //}

        // Constructor for ASP.Net Core
        public PlantDataDbContext(DbContextOptions<PlantDataDbContext> options) : base(options)
        {
        }

        // Constructor for testing
        public PlantDataDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        //public bool IsSqlParameterNull(System.Data.SqlClient.SqlParameter param)
        //{
        //    var sqlValue = param.SqlValue;
        //    var nullableValue = sqlValue as System.Data.SqlTypes.INullable;
        //    if (nullableValue != null)
        //        return nullableValue.IsNull;
        //    return (sqlValue == null || sqlValue == System.DBNull.Value);
        //}

        //
        // Summary:
        //     Override this method to configure the database (and other options) to be used
        //     for this context. This method is called for each instance of the context that
        //     is created. The base implementation does nothing.
        //     In situations where an instance of Microsoft.EntityFrameworkCore.DbContextOptions
        //     may or may not have been passed to the constructor, you can use Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.IsConfigured
        //     to determine if the options have already been set, and skip some or all of the
        //     logic in Microsoft.EntityFrameworkCore.DbContext.OnConfiguring(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder).
        //
        // Parameters:
        //   optionsBuilder:
        //     A builder used to create or modify options for this context. Databases (and other
        //     extensions) typically define extension methods on this object that allow you
        //     to configure the context.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var conn = new SqlConnection(_connectionString);
                optionsBuilder.UseSqlServer(conn);
                optionsBuilder.AddInterceptors(new EfLoggingInterceptor());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GenusConfiguration());
            modelBuilder.ApplyConfiguration(new JournalEntryConfiguration());
            modelBuilder.ApplyConfiguration(new JournalEntryTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PlantStockConfiguration());
            modelBuilder.ApplyConfiguration(new PriceListTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ProductPriceConfiguration());
            modelBuilder.ApplyConfiguration(new ProductTypeConfiguration());
            modelBuilder.ApplyConfiguration(new SeedBatchConfiguration());
            modelBuilder.ApplyConfiguration(new SeedTrayConfiguration());
            modelBuilder.ApplyConfiguration(new SiteConfiguration());
            modelBuilder.ApplyConfiguration(new SpeciesConfiguration());
            modelBuilder.ApplyConfiguration(new SaleEventConfiguration());

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
    }
}
