using Framework.Domain.EF;
using PlantDataMVC.Entities.Models;
using PlantDataMVC.Repository.Interfaces;

namespace PlantDataMVC.Repository.Repositories
{
    public class SpeciesRepository : EFRepository<Species>, ISpeciesRepository
    {
        private readonly IDbContext _dbContext;

        public SpeciesRepository(IDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}