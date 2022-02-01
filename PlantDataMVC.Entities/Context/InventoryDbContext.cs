using Framework.Domain.EF;
using PlantDataMVC.Entities.Configuration;
using PlantDataMVC.Entities.Interfaces;
using PlantDataMVC.Entities.Models;

using System.Data.Entity;

namespace PlantDataMVC.Entities.Context
{
    public class InventoryDbContext : DbContext, IInventoryDbContext
    {
        public IDbSet<Genus> Genus { get; set; } // Genus
        public IDbSet<JournalEntry> JournalEntries { get; set; } // JournalEntry
        public IDbSet<JournalEntryType> JournalEntryTypes { get; set; } // JournalEntryType
        public IDbSet<PlantStock> PlantStocks { get; set; } // PlantStock
        public IDbSet<ProductType> ProductTypes { get; set; } // ProductType
        public IDbSet<Species> Species { get; set; } // Species

        static InventoryDbContext()
        {
            // Disable CodeFirst migrations 
            Database.SetInitializer<InventoryDbContext>(null);
        }

        public InventoryDbContext(string connectionString)
            : base(connectionString)
        {
        }

        public InventoryDbContext(System.Data.Common.DbConnection existingConnection, bool contextOwnsConnection)
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
            modelBuilder.Configurations.Add(new JournalEntryConfiguration());
            modelBuilder.Configurations.Add(new JournalEntryTypeConfiguration());
            modelBuilder.Configurations.Add(new PlantStockConfiguration());
            modelBuilder.Configurations.Add(new ProductTypeConfiguration());
            modelBuilder.Configurations.Add(new SpeciesConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
