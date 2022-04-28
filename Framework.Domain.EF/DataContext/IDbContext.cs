using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Framework.Domain.EF
{
    public interface IDbContext: IDisposable
    {
        //String Schema { get; }
        DatabaseFacade Database { get; }
        EntityState GetState<TEntity>(TEntity entity) where TEntity: class;
        void SetState<TEntity>(TEntity entity, EntityState entityState);


        int SaveChanges();
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        //DbChangeTracker ChangeTracker { get; }
        //DbContextConfiguration Configuration { get; }
        //IEnumerable<DbEntityValidationResult> GetValidationErrors();
        //DbSet Set(System.Type entityType);
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        //string ToString();
        }
    }
