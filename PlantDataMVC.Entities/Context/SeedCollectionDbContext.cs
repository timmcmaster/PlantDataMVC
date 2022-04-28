﻿using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PlantDataMVC.Entities.Configuration;
using PlantDataMVC.Entities.Interfaces;
using PlantDataMVC.Entities.Models;

namespace PlantDataMVC.Entities.Context
{
    public class SeedCollectionDbContext : DbContext, ISeedCollectionDbContext
    {
        private string _connectionString;

        public DbSet<Genus> Genus { get; set; } // Genus
        public DbSet<SeedBatch> SeedBatches { get; set; } // SeedBatch
        public DbSet<SeedTray> SeedTrays { get; set; } // SeedTray
        public DbSet<Site> Sites { get; set; } // Site
        public DbSet<Species> Species { get; set; } // Species

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
