using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PlantDataMVC.Entities.Configuration;
using PlantDataMVC.Entities.Interfaces;
using PlantDataMVC.Entities.Models;

namespace PlantDataMVC.Entities.Context
{


    public class PlantDefinitionDbContext : DbContext, IPlantDefinitionDbContext
    {
        private string _connectionString;

        public DbSet<Genus> Genus { get; set; } // Genus
        public DbSet<Species> Species { get; set; } // Species

        public PlantDefinitionDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public PlantDefinitionDbContext(DbContextOptions<PlantDefinitionDbContext> options) : base(options)
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
