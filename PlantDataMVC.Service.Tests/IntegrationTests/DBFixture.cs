using Microsoft.Data.SqlClient;
using Respawn;
using System.Configuration;
using System.Threading.Tasks;
using Xunit;

namespace PlantDataMVC.Service.Tests.IntegrationTests
{
    public class DbFixture : IAsyncLifetime
    {
        private string _connectionString;
        private Respawner _respawner;
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