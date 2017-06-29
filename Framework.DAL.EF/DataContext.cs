using Framework.DAL.DataContext;
using System;
using System.Data.Entity;

namespace Framework.DAL.EF
{
    public class DataContext: DbContext, IDataContextAsync
    {
        private readonly Guid _instanceId;
        bool _disposed;

        public DataContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
            _instanceId = Guid.NewGuid();
        }

        #region Implement other constructors to fit with ReversePOCO generated PlantDataDbContext class
        // HACK: Shouldn't need to do this if custom base class option worked properly

        public DataContext(string connectionString, System.Data.Entity.Infrastructure.DbCompiledModel model)
            : base(connectionString, model)
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
    }
}
