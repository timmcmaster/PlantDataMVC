﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Framework.Domain.EF
{
    public interface IDbContext: IDisposable
    {
        //String Schema { get; }
        Database Database { get; }
        DbEntityEntry Entry(object entity);
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

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
