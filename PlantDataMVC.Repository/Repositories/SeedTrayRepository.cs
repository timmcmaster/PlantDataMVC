using Framework.Domain.EF;
using Interfaces.Domain.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using PlantDataMVC.Entities.EntityModels;
using PlantDataMVC.Repository.Interfaces;
using System.Linq;

namespace PlantDataMVC.Repository.Repositories
{
    public class SeedTrayRepository : EFRepository<SeedTrayEntityModel>, ISeedTrayRepository
    {
        public SeedTrayRepository(IDbContext dbContext, IUnitOfWorkAsync unitOfWork) : base(dbContext)
        {
        }

        public override SeedTrayEntityModel GetItemById(int id)
        {
            var result = DbSet
                .Include(m => m.SeedBatch)
                .ThenInclude(m => m.Species)
                .ThenInclude(m => m.Genus)
                .Single(m => m.Id == id);
            return result;
        }
    }
}