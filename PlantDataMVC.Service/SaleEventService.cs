using Framework.Service;
using Interfaces.Service;
using PlantDataMVC.Entities.Models;
using PlantDataMVC.Repository.Interfaces;

namespace PlantDataMVC.Service
{
    public interface ISaleEventService : IService<SaleEvent>
    {
    }

    /// <summary>
    ///     All methods that are exposed from Repository in Service are overridable to add business logic,
    ///     business logic should be in the Service layer and not in repository for separation of concerns.
    /// </summary>
    public class SaleEventService : Service<SaleEvent>, ISaleEventService
    {
        public SaleEventService(ISaleEventRepository repository) : base(repository)
        {
        }
    }
}