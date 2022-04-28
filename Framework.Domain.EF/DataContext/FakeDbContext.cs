using Interfaces.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Framework.Domain.EF
{
    /// <summary>
    ///     This class contains the generic EF stuff for a fake context.
    ///     It should be usable by any given database with its own entities.
    /// </summary>
    public abstract class FakeDbContext : IFakeDbContext
    {
        private readonly Dictionary<Type, object> _fakeDbSets;

        private DbEntityStateTracker _tracker;

        protected FakeDbContext()
        {
            _fakeDbSets = new Dictionary<Type, object>();
            _tracker = new DbEntityStateTracker();
        }

        #region IDbContext Members
        public DatabaseFacade Database => throw new NotImplementedException();

        public int SaveChanges()
        {
            return default(int);
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return new Task<int>(() => default(int));
        }

        public Task<int> SaveChangesAsync()
        {
            return new Task<int>(() => default(int));
        }

        public DbSet<T> Set<T>() where T : class
        {
            return (DbSet<T>) _fakeDbSets[typeof(T)];
        }

        public EntityState GetState<TEntity>(TEntity entity) where TEntity : class
        {
            // check if entity has Id property
            var propInfo = entity.GetType().GetProperty("Id");
            var entityId = propInfo.GetValue(entity, null);

            return _tracker.GetState(entity, (int)entityId);
        }

        public void SetState<TEntity>(TEntity entity, EntityState entityState)
        {   
            // check if entity has Id property
            var propInfo = entity.GetType().GetProperty("Id");
            var entityId = propInfo.GetValue(entity, null);

            _tracker.Track(entity, (int)entityId, entityState);
        }
        #endregion

        #region IFakeDbContext members
        public void AddFakeDbSet<TEntity, TFakeDbSet>()
            where TEntity : class, IEntity, new()
            where TFakeDbSet : FakeDbSet<TEntity>, new()
        {
            var fakeDbSet = Activator.CreateInstance<TFakeDbSet>();
            _fakeDbSets.Add(typeof(TEntity), fakeDbSet);
        }
        #endregion

        #region IDisposable members
        public void Dispose()
        {
        }
        #endregion
    }

    public class DbEntityStateTracker
    {
        private List<DbEntityRecord> _trackedRecords;
        
        public DbEntityStateTracker()
        {
            _trackedRecords = new List<DbEntityRecord>();
        }

        public void Track<TEntity>(TEntity entity, int entityId, EntityState state)
        {
            var entityType = entity.GetType().FullName;
            var entityRec = _trackedRecords.SingleOrDefault(x => x.EntityType == entityType && x.Id == entityId);
            if (entityRec == null)
            {
                _trackedRecords.Add(new DbEntityRecord { Id = entityId, EntityType = entityType, EntityState = state });
            }
            else
            {
                entityRec.EntityState = state;
            }
        }

        public EntityState GetState<TEntity>(TEntity entity, int entityId)
        {
            var entityType = entity.GetType().FullName;
            var entityRec = _trackedRecords.SingleOrDefault(x => x.EntityType == entityType && x.Id == entityId);
            if (entityRec == null)
            {
                //_trackedRecords.Add(new DbEntityRecord { Id = entityId, EntityType = entityType, EntityState = Ent });
                return EntityState.Detached;
            }
            else
            {
                return entityRec.EntityState;
            }
        }


        public void ClearTracking()
        {
            _trackedRecords?.Clear();
        }


    }

    internal class DbEntityRecord
    {
        public string EntityType { get; set; }
        public int Id { get; set; }

        public EntityState EntityState { get; set; }
    }

}