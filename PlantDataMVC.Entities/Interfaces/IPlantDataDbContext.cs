using PlantDataMVC.Entities.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Data.Entity.Validation;
using System;

namespace PlantDataMVC.Entities.Interfaces
{

    public interface IPlantDataDbContext : IDisposable
    {
        DbSet<Genus> Genus { get; set; } // Genus
        DbSet<JournalEntry> JournalEntries { get; set; } // JournalEntry
        DbSet<JournalEntryType> JournalEntryTypes { get; set; } // JournalEntryType
        DbSet<PlantStock> PlantStocks { get; set; } // PlantStock
        DbSet<PriceListType> PriceListTypes { get; set; } // PriceListType
        DbSet<ProductPrice> ProductPrices { get; set; } // ProductPrice
        DbSet<ProductType> ProductTypes { get; set; } // ProductType
        DbSet<SeedBatch> SeedBatches { get; set; } // SeedBatch
        DbSet<SeedTray> SeedTrays { get; set; } // SeedTray
        DbSet<Site> Sites { get; set; } // Site
        DbSet<Species> Species { get; set; } // Species

        int SaveChanges();
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        DbChangeTracker ChangeTracker { get; }
        DbContextConfiguration Configuration { get; }
        Database Database { get; }
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        DbEntityEntry Entry(object entity);
        IEnumerable<DbEntityValidationResult> GetValidationErrors();
        DbSet Set(System.Type entityType);
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        string ToString();
    }

}
