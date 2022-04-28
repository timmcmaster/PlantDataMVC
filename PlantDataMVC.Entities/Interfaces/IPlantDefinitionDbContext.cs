using Framework.Domain.EF;
using Microsoft.EntityFrameworkCore;
using PlantDataMVC.Entities.Models;
using System;

namespace PlantDataMVC.Entities.Interfaces
{

    public interface IPlantDefinitionDbContext : IDbContext, IDisposable
    {
        DbSet<Genus> Genus { get; set; } // Genus
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
