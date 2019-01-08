using PlantDataMVC.Domain.Entities;
using PlantDataMVC.Service.ServiceContracts;

namespace PlantDataMVC.WebApi.Controllers
{
    public class PlantStockEntryController : BaseApiController<PlantStockEntry>
    {
        public PlantStockEntryController(IPlantStockEntryDataService dataService) : base(dataService)
        {
        }
    }
}
