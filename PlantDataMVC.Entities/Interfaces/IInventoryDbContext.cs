using PlantDataMVC.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using Framework.Domain.EF;

namespace PlantDataMVC.Entities.Interfaces
{

    public interface IInventoryDbContext : IDbContext, IDisposable
    {
        DbSet<Genus> Genus { get; set; } // Genus
        DbSet<JournalEntry> JournalEntries { get; set; } // JournalEntry
        DbSet<JournalEntryType> JournalEntryTypes { get; set; } // JournalEntryType
        DbSet<PlantStock> PlantStocks { get; set; } // PlantStock
        DbSet<ProductType> ProductTypes { get; set; } // ProductType
        DbSet<Species> Species { get; set; } // Species

        //int SaveChanges();
        //Task<int> SaveChangesAsync();
        //Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        //DbChangeTracker ChangeTracker { get; }
        //DbContextConfiguration Configuration { get; }
        //IEnumerable<DbEntityValidationResult> GetValidationErrors();
        //DbSet Set(System.Type entityType);
        //DbSet<TEntity> Set<TEntity>() where TEntity : class;
        //string ToString();
    }

}
