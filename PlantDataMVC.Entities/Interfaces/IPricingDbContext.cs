using Framework.Domain.EF;
using Microsoft.EntityFrameworkCore;
using PlantDataMVC.Entities.EntityModels;
using System;

namespace PlantDataMVC.Entities.Interfaces
{

    public interface IPricingDbContext : IDbContext, IDisposable
    {
        DbSet<PriceListTypeEntityModel> PriceListTypes { get; set; } // PriceListType
        DbSet<ProductPriceEntityModel> ProductPrices { get; set; } // ProductPrice
        DbSet<ProductTypeEntityModel> ProductTypes { get; set; } // ProductType

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
