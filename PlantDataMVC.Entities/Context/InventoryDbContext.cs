using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PlantDataMVC.Entities.Configuration;
using PlantDataMVC.Entities.Interfaces;
using PlantDataMVC.Entities.EntityModels;

namespace PlantDataMVC.Entities.Context
{
    public class InventoryDbContext : DbContext, IInventoryDbContext
    {
        private string _connectionString;

        public DbSet<GenusEntityModel> Genus { get; set; } // Genus
        public DbSet<JournalEntryEntityModel> JournalEntries { get; set; } // JournalEntry
        public DbSet<JournalEntryTypeEntityModel> JournalEntryTypes { get; set; } // JournalEntryType
        public DbSet<PlantStockEntityModel> PlantStocks { get; set; } // PlantStock
        public DbSet<ProductTypeEntityModel> ProductTypes { get; set; } // ProductType
        public DbSet<SaleEventEntityModel> SaleEvents { get; set; } // SaleEvent
        public DbSet<SpeciesEntityModel> Species { get; set; } // Species

        //static InventoryDbContext()
        //{
        //    // Disable CodeFirst migrations 
        //    Database.SetInitializer<InventoryDbContext>(null);
        //}

        public InventoryDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var conn = new SqlConnection(_connectionString);
                optionsBuilder.UseSqlServer(conn);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GenusConfiguration());
            modelBuilder.ApplyConfiguration(new JournalEntryConfiguration());
            modelBuilder.ApplyConfiguration(new JournalEntryTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PlantStockConfiguration());
            modelBuilder.ApplyConfiguration(new ProductTypeConfiguration());
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
