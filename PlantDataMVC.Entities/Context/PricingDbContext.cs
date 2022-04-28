using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PlantDataMVC.Entities.Configuration;
using PlantDataMVC.Entities.Interfaces;
using PlantDataMVC.Entities.Models;

namespace PlantDataMVC.Entities.Context
{
    public class PricingDbContext : DbContext, IPricingDbContext
    {
        private string _connectionString;

        public DbSet<PriceListType> PriceListTypes { get; set; } // PriceListType
        public DbSet<ProductPrice> ProductPrices { get; set; } // ProductPrice
        public DbSet<ProductType> ProductTypes { get; set; } // ProductType

        public PricingDbContext(): this("Name=PlantDataDbContext")
        {
        }

        public PricingDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public PricingDbContext(DbContextOptions options) : base(options)
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
            modelBuilder.ApplyConfiguration(new PriceListTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ProductPriceConfiguration());
            modelBuilder.ApplyConfiguration(new ProductTypeConfiguration());

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
