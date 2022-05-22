using Framework.Domain.EF;
using Interfaces.Domain.UnitOfWork;
using PlantDataMVC.Entities.Models;
using PlantDataMVC.Repository.Interfaces;

namespace PlantDataMVC.Repository.Repositories
{
    public class SeedTrayRepository : EFRepository<SeedTray>, ISeedTrayRepository
    {
        public SeedTrayRepository(IDbContext dbContext, IUnitOfWorkAsync unitOfWork) : base(dbContext)
        {
        }
    }
}