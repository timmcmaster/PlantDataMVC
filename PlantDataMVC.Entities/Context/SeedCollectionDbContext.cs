using Framework.Domain.EF;
using PlantDataMVC.Entities.Configuration;
using PlantDataMVC.Entities.Interfaces;
using PlantDataMVC.Entities.Models;

using System.Data.Entity;

namespace PlantDataMVC.Entities.Context
{


    public class SeedCollectionDbContext : DbContext, ISeedCollectionDbContext
    {
        public IDbSet<Genus> Genus { get; set; } // Genus
        public IDbSet<SeedBatch> SeedBatches { get; set; } // SeedBatch
        public IDbSet<SeedTray> SeedTrays { get; set; } // SeedTray
        public IDbSet<Site> Sites { get; set; } // Site
        public IDbSet<Species> Species { get; set; } // Species

        static SeedCollectionDbContext()
        {
            // Disable CodeFirst migrations 
            Database.SetInitializer<SeedCollectionDbContext>(null);
        }

        //public SeedCollectionDbContext() 
        //    : base("Name=PlantDataDbContext")
        //{
        //}

        public SeedCollectionDbContext(string connectionString)
            : base(connectionString)
        {
        }

        public SeedCollectionDbContext(System.Data.Common.DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        {
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new GenusConfiguration());
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
    }
}
