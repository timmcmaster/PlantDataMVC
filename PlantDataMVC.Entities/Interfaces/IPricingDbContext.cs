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

    public interface IPricingDbContext : IDbContext, IDisposable
    {
        IDbSet<PriceListType> PriceListTypes { get; set; } // PriceListType
        IDbSet<ProductPrice> ProductPrices { get; set; } // ProductPrice
        IDbSet<ProductType> ProductTypes { get; set; } // ProductType

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
