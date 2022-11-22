using Xunit;
using System.Configuration;
using System.Threading;
using System.Threading.Tasks;
using Respawn;

namespace PlantDataMVC.Domain.Tests.IntegrationTests
{
    public class DbFixture : IAsyncLifetime
    {
        private string _connectionString;
        private Respawner _respawner;


        public DbFixture()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["PlantDataDbContext"].ConnectionString;
        }

        public async Task InitializeAsync()
        {
            _respawner = await Respawner.CreateAsync(_connectionString, new RespawnerOptions
            {
                SchemasToExclude = new[] { "sys" },
                SchemasToInclude = new[] { "dbo" },
                WithReseed = true
            });
        }

        public async Task ResetCheckpoint()
        {
            await _respawner.ResetAsync(_connectionString);
        }

        public Task DisposeAsync()
        {
            return Task.CompletedTask;
        }
    }
}