using Interfaces.DAL.DataContext;
using Interfaces.DAL.Infrastructure;
using System;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Threading;

namespace Framework.DAL.EF
{
    public class DataContext: DbContext, IDataContextAsync
    {
        private readonly Guid _instanceId;
        bool _disposed;

        #region Implement all public constructors needed by PlantDataDbContext

        public DataContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
            _instanceId = Guid.NewGuid();
        }

        public DataContext(string nameOrConnectionString, System.Data.Entity.Infrastructure.DbCompiledModel model)
            : base(nameOrConnectionString, model)
        {
            _instanceId = Guid.NewGuid();
        }

        public DataContext(System.Data.Common.DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        {
            _instanceId = Guid.NewGuid();
        }

        public DataContext(System.Data.Common.DbConnection existingConnection, System.Data.Entity.Infrastructure.DbCompiledModel model, bool contextOwnsConnection)
            : base(existingConnection, model, contextOwnsConnection)
        {
            _instanceId = Guid.NewGuid();
        }
        #endregion

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync()
        {
            return await this.SaveChangesAsync(CancellationToken.None);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            SyncObjectsStatePreCommit();
            var changesAsync = await base.SaveChangesAsync(cancellationToken);
            SyncObjectsStatePostCommit();
            return changesAsync;
        }

        private void SyncObjectsStatePreCommit()
        {
            // Map state on generic entity to EF state
            foreach (var dbEntityEntry in ChangeTracker.Entries())
            {
                dbEntityEntry.State = StateHelper.ConvertState(((IObjectState)dbEntityEntry.Entity).ObjectState);
            }
        }

        public void SyncObjectsStatePostCommit()
        {
            // Map state on EF entity to generic state
            foreach (var dbEntityEntry in ChangeTracker.Entries())
            {
                ((IObjectState)dbEntityEntry.Entity).ObjectState = StateHelper.ConvertState(dbEntityEntry.State);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // free other managed objects that implement
                    // IDisposable only
                }

                // release any unmanaged objects
                // set object references to null

                _disposed = true;
            }

            base.Dispose(disposing);
        }

        public void SyncObjectState<TEntity>(TEntity entity) where  TEntity : class, IObjectState
        {
            Entry(entity).State = StateHelper.ConvertState(entity.ObjectState);
        }
    }
}
