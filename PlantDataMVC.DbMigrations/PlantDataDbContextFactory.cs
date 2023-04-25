using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using PlantDataMVC.Entities.Context;

namespace PlantDataMVC.DbMigrations
{
    public class PlantDataDbContextFactory : IDesignTimeDbContextFactory<PlantDataDbContext>
    {
        public PlantDataDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<PlantDataDbContext>();

            var connectionString = configuration.GetConnectionString("SqlConnectionString");

            optionsBuilder.UseSqlServer(connectionString, x => x.MigrationsAssembly("PlantDataMVC.DbMigrations"));

            return new PlantDataDbContext(optionsBuilder.Options);
        }
    }
}
