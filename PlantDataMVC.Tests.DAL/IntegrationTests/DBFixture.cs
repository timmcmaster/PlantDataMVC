using Respawn;
using System.Configuration;
using System.Threading.Tasks;

namespace PlantDataMVC.Tests.DAL.IntegrationTests
{
    public class DBFixture
    {
        private static readonly string _connectionString;
        private static readonly Checkpoint _checkpoint;

        static DBFixture()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["PlantDataDbContext"].ConnectionString;
            _checkpoint = new Checkpoint()
            {
                SchemasToExclude = new[] { "sys" },
                SchemasToInclude = new[] { "dbo" },
                WithReseed = true
            };
        }

        public static Task ResetCheckpoint() => _checkpoint.Reset(_connectionString);
    }
}
