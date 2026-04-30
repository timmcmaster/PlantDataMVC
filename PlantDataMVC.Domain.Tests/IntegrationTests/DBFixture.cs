using Microsoft.Data.SqlClient;
using Respawn;
using System.Configuration;
using System.Threading.Tasks;
using Xunit;

namespace PlantDataMVC.Domain.Tests.IntegrationTests
{
    public class DbFixture : IAsyncLifetime
    {
        private Respawner _respawner;
        private string _connectionString;
        private SqlConnection _connection;

        public DbFixture()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["PlantDataDbContext"].ConnectionString;
            _connection = new SqlConnection(_connectionString);
        }

        public async Task InitializeAsync()
        {
            _respawner = await Respawner.CreateAsync(_connection, new RespawnerOptions
            {
                SchemasToExclude = new[] { "sys" },
                SchemasToInclude = new[] { "dbo" },
                WithReseed = true
            });
        }

        public async Task ResetCheckpoint()
        {
            await _respawner.ResetAsync(_connection);
        }

        public Task DisposeAsync()
        {
            return Task.CompletedTask;
        }
    }
}