using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PlantDataMVC.Entities.Configuration;
using PlantDataMVC.Entities.Interfaces;
using PlantDataMVC.Entities.Models;

namespace PlantDataMVC.Entities.Context
{
    public class InventoryDbContext : DbContext, IInventoryDbContext
    {
        private string _connectionString;

        public DbSet<Genus> Genus { get; set; } // Genus
        public DbSet<JournalEntry> JournalEntries { get; set; } // JournalEntry
        public DbSet<JournalEntryType> JournalEntryTypes { get; set; } // JournalEntryType
        public DbSet<PlantStock> PlantStocks { get; set; } // PlantStock
        public DbSet<ProductType> ProductTypes { get; set; } // ProductType
        public DbSet<Species> Species { get; set; } // Species

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
