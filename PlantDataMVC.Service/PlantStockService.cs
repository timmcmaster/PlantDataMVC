using Framework.Service;
using Interfaces.Service;
using PlantDataMVC.Entities.EntityModels;
using PlantDataMVC.Repository.Interfaces;

namespace PlantDataMVC.Service
{
    public interface IPlantStockService : IService<PlantStockEntityModel>
    {
    }

    /// <summary>
    ///     All methods that are exposed from Repository in Service are overridable to add business logic,
    ///     business logic should be in the Service layer and not in repository for separation of concerns.
    /// </summary>
    public class PlantStockService : Service<PlantStockEntityModel>, IPlantStockService
    {
        public PlantStockService(IPlantStockRepository repository) : base(repository)
        {
        }
    }
}