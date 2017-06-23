using Framework.DAL.DataContext;
using System;
using System.Data.Entity;

namespace Framework.DAL.EF.DataContext
{
    public class DataContext: DbContext, IDataContext
    {
        private readonly Guid _instanceId;
        bool _disposed;

        public DataContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
            _instanceId = Guid.NewGuid();
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
    }
}
