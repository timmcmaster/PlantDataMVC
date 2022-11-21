using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PlantDataMVC.Entities.Configuration;
using PlantDataMVC.Entities.Interfaces;
using PlantDataMVC.Entities.EntityModels;

namespace PlantDataMVC.Entities.Context
{
    public class SeedCollectionDbContext : DbContext, ISeedCollectionDbContext
    {
        private string _connectionString;

        public DbSet<GenusEntityModel> Genus { get; set; } // Genus
        public DbSet<SeedBatchEntityModel> SeedBatches { get; set; } // SeedBatch
        public DbSet<SeedTrayEntityModel> SeedTrays { get; set; } // SeedTray
        public DbSet<SiteEntityModel> Sites { get; set; } // Site
        public DbSet<SpeciesEntityModel> Species { get; set; } // Species

        public SeedCollectionDbContext() : this("Name=PlantDataDbContext")
        {
        }

        public SeedCollectionDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public SeedCollectionDbContext(DbContextOptions options) : base(options)
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
            modelBuilder.ApplyConfiguration(new SeedBatchConfiguration());
            modelBuilder.ApplyConfiguration(new SeedTrayConfiguration());
            modelBuilder.ApplyConfiguration(new SiteConfiguration());
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
