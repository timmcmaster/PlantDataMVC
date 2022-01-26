using PlantDataMVC.Entities.Configuration;
using PlantDataMVC.Entities.Interfaces;
using PlantDataMVC.Entities.Models;
using System.Data.Entity.Infrastructure;

namespace PlantDataMVC.Entities.Context
{

    public class PlantDataDbContextFactory : IDbContextFactory<PlantDataDbContext>
    {
        public PlantDataDbContext Create()
        {
            return new PlantDataDbContext();
        }
    }
}
