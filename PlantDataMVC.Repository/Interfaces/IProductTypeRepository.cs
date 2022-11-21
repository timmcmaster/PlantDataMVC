using Interfaces.Domain.Repository;
using PlantDataMVC.Entities.EntityModels;

namespace PlantDataMVC.Repository.Interfaces
{
    public interface IProductTypeRepository : IRepositoryAsync<ProductTypeEntityModel>
    {
    }
}
