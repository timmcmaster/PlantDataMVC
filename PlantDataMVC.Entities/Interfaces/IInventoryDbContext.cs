using PlantDataMVC.Entities.EntityModels;
using Microsoft.EntityFrameworkCore;
using System;
using Framework.Domain.EF;

namespace PlantDataMVC.Entities.Interfaces
{

    public interface IInventoryDbContext : IDbContext, IDisposable
    {
        DbSet<GenusEntityModel> Genus { get; set; } // Genus
        DbSet<JournalEntryEntityModel> JournalEntries { get; set; } // JournalEntry
        DbSet<JournalEntryTypeEntityModel> JournalEntryTypes { get; set; } // JournalEntryType
        DbSet<PlantStockEntityModel> PlantStocks { get; set; } // PlantStock
        DbSet<ProductTypeEntityModel> ProductTypes { get; set; } // ProductType
        DbSet<SpeciesEntityModel> Species { get; set; } // Species
        DbSet<SaleEventEntityModel> SaleEvents { get; set; } // SaleEvent

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
