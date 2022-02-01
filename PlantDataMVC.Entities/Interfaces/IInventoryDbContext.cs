using PlantDataMVC.Entities.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Data.Entity.Validation;
using System;
using Framework.Domain.EF;

namespace PlantDataMVC.Entities.Interfaces
{

    public interface IInventoryDbContext : IDbContext, IDisposable
    {
        IDbSet<Genus> Genus { get; set; } // Genus
        IDbSet<JournalEntry> JournalEntries { get; set; } // JournalEntry
        IDbSet<JournalEntryType> JournalEntryTypes { get; set; } // JournalEntryType
        IDbSet<PlantStock> PlantStocks { get; set; } // PlantStock
        IDbSet<ProductType> ProductTypes { get; set; } // ProductType
        IDbSet<Species> Species { get; set; } // Species

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
