using Framework.Service.Entities;
using Framework.Web.Forms;
using Interfaces.Service;
using PlantDataMVC.Domain.Entities;
using PlantDataMVC.UI.Models;

namespace PlantDataMVC.UI.Forms.Handlers
{
    public class PlantStockEntryCreateEditModelFormHandler : IFormHandler<PlantStockEntryCreateEditModel>
    {
        private IBasicDataService<PlantStockEntry> _dataService;

        public PlantStockEntryCreateEditModelFormHandler(IBasicDataService<PlantStockEntry> dataService)
        {
            _dataService = dataService;
        }

        public void Handle(PlantStockEntryCreateEditModel form)
        {
            // Map local model to business object
            PlantStockEntry item = AutoMapper.Mapper.Map<PlantStockEntryCreateEditModel, PlantStockEntry>(form);

            CreateRequest<PlantStockEntry> request = new CreateRequest<PlantStockEntry>(item);

            ICreateResponse<PlantStockEntry> response = _dataService.Create(request);
        }
    }
}