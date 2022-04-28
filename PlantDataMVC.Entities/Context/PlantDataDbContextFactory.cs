using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace PlantDataMVC.Entities.Context
{

    public class PlantDataDbContextFactory : IDesignTimeDbContextFactory<PlantDataDbContext>
    {
        public PlantDataDbContext CreateDbContext(string[] args)
        {
            return new PlantDataDbContext();
        }
    }
}
