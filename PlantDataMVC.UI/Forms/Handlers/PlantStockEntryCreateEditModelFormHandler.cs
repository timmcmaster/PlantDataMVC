using Framework.Service.Entities;
using Framework.Web.Forms;
using Interfaces.Service;
using PlantDataMVC.Domain.Entities;
using PlantDataMVC.Service.ServiceContracts;
using PlantDataMVC.UI.Models;

namespace PlantDataMVC.UI.Forms.Handlers
{
    public class PlantStockEntryCreateEditModelFormHandler : IFormHandler<PlantStockEntryCreateEditModel>
    {
        private IPlantStockEntryDataService _dataService;

        public PlantStockEntryCreateEditModelFormHandler(IPlantStockEntryDataService dataService)
        {
            _dataService = dataService;
        }

        public void Handle(PlantStockEntryCreateEditModel form)
        {
            // Map local model to business object
            PlantStockEntry item = AutoMapper.Mapper.Map<PlantStockEntryCreateEditModel, PlantStockEntry>(form);

            //CreateRequest<PlantStockEntry> request = new CreateRequest<PlantStockEntry>(item);

            ICreateResponse<PlantStockEntry> response = _dataService.Create(item);
        }
    }
}