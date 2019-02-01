using System.Threading.Tasks;
using Nito.AsyncEx;
using Xunit;

namespace PlantDataMVC.Tests.DAL.IntegrationTests
{
    /// <summary>
    ///     <P>Base class for integration tests in this namespace</P>
    ///     <P>This class will clear the database using the Respawn package at beginning of every test.</P>
    ///     Implements Xunit.IAsyncLifetime to manage cleaning up after async tasks.
    /// </summary>
    public abstract class IntegrationTestBase : IAsyncLifetime
    {
        private static bool _initialized;
        private static readonly AsyncLock _mutex = new AsyncLock();

        #region IAsyncLifetime Members
        /// <summary>
        ///     Called immediately after the class has been created, before it is used.
        /// </summary>
        /// <returns></returns>
        public virtual async Task InitializeAsync()
        {
            if (_initialized)
            {
                return;
            }

            using (await _mutex.LockAsync())
            {
                if (_initialized)
                {
                    return;
                }

                await DbFixture.ResetCheckpoint();

                _initialized = true;
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