using PlantDataMVC.Domain.Entities;
using PlantDataMVC.Service.ServiceContracts;

namespace PlantDataMVC.WebApi.Controllers
{
    public class PlantStockTransactionController : BaseApiController<PlantStockTransaction>
    {
        public PlantStockTransactionController(IPlantStockTransactionDataService dataService) : base(dataService)
        {
        }
    }
}
