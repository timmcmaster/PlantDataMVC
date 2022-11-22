using System.Threading.Tasks;
using Nito.AsyncEx;
using Xunit;

namespace PlantDataMVC.Domain.Tests.IntegrationTests
{
    /// <summary>
    ///     <P>Base class for integration tests in this namespace</P>
    ///     <P>This class will clear the database using the Respawn package at beginning of every test.</P>
    ///     Implements Xunit.IAsyncLifetime to manage cleaning up after async tasks.
    /// </summary>
    public abstract class IntegrationTestBase : IAsyncLifetime, IClassFixture<DbFixture>
    {
        //private static bool _initialized;
        private static readonly AsyncLock _mutex = new AsyncLock();

        private DbFixture _dbFixture;

        public IntegrationTestBase(DbFixture dbFixture)
        {
            _dbFixture = dbFixture;
        }

        #region IAsyncLifetime Members
        ///// <summary>
        ///// Version for reset only at creation of class
        ///// Called immediately after the class has been created, before it is used.
        ///// </summary>
        ///// <returns></returns>
        //public virtual async Task InitializeAsync()
        //{
        //    if (_initialized)
        //        return;

        //    using (await _mutex.LockAsync())
        //    {
        //        if (_initialized)
        //            return;

        //        await DBFixture.ResetCheckpoint();

        //        _initialized = true;
        //    }
        //}

        // Version for reset every test
        public virtual async Task InitializeAsync()
        {
            using (await _mutex.LockAsync())
            {
                await _dbFixture.ResetCheckpoint();
            }
        }

        /// <summary>
        ///     Called when an object is no longer needed. Called just before <see cref="M:System.IDisposable.Dispose" />
        ///     if the class also implements that.
        /// </summary>
        /// <returns></returns>
        public virtual Task DisposeAsync()
        {
            return Task.CompletedTask;
        }
        #endregion
    }
}