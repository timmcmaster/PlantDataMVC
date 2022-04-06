using Framework.Domain.EF;
using PlantDataMVC.Entities.Configuration;
using PlantDataMVC.Entities.Interfaces;
using PlantDataMVC.Entities.Models;

using System.Data.Entity;

namespace PlantDataMVC.Entities.Context
{


    public class PlantDefinitionDbContext : DbContext, IPlantDefinitionDbContext
    {
        public IDbSet<Genus> Genus { get; set; } // Genus
        public IDbSet<Species> Species { get; set; } // Species

        static PlantDefinitionDbContext()
        {
            // Disable CodeFirst migrations 
            Database.SetInitializer<PlantDefinitionDbContext>(null);
        }

        //public PlantDefinitionDbContext() 
        //    : base("Name=PlantDataDbContext")
        //{
        //}

        public PlantDefinitionDbContext(string connectionString)
            : base(connectionString)
        {
        }

        public PlantDefinitionDbContext(System.Data.Common.DbConnection existingConnection, bool contextOwnsConnection)
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
