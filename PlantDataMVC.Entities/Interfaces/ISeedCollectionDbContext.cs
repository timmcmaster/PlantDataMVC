using Framework.Domain.EF;
using Microsoft.EntityFrameworkCore;
using PlantDataMVC.Entities.EntityModels;
using System;

namespace PlantDataMVC.Entities.Interfaces
{

    public interface ISeedCollectionDbContext : IDbContext, IDisposable
    {
        DbSet<GenusEntityModel> Genus { get; set; } // Genus
        DbSet<SeedBatchEntityModel> SeedBatches { get; set; } // SeedBatch
        DbSet<SeedTrayEntityModel> SeedTrays { get; set; } // SeedTray
        DbSet<SiteEntityModel> Sites { get; set; } // Site
        DbSet<SpeciesEntityModel> Species { get; set; } // Species

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
