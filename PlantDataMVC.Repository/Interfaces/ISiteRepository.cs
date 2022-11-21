using Interfaces.Domain.Repository;
using PlantDataMVC.Entities.EntityModels;

namespace PlantDataMVC.Repository.Interfaces
{
    public interface ISiteRepository : IRepositoryAsync<SiteEntityModel>
    {
    }
}
