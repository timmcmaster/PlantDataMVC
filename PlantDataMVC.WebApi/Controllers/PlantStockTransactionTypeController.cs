using PlantDataMVC.Domain.Entities;
using PlantDataMVC.Service.ServiceContracts;

namespace PlantDataMVC.WebApi.Controllers
{
    public class PlantStockTransactionTypeController : BaseApiController<PlantStockTransactionType>
    {
        public PlantStockTransactionTypeController(IPlantStockTransactionTypeDataService dataService) : base(dataService)
        {
        }
    }
}
