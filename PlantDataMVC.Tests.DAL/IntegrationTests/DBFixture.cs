using Respawn;
using System.Configuration;
using System.Threading.Tasks;

namespace PlantDataMVC.Tests.DAL.IntegrationTests
{
    public class DbFixture
    {
        private static readonly string _connectionString;
        private static readonly Checkpoint _checkpoint;

        static DbFixture()
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
