using Framework.Service.ServiceLayer;
using Framework.Web.Forms;
using Interfaces.Service;
using PlantDataMVC.Domain.Entities;
using PlantDataMVC.UI.Models;

namespace PlantDataMVC.UI.Forms.Handlers
{
    public class PlantStockEntryUpdateEditModelFormHandler : IFormHandler<PlantStockEntryUpdateEditModel>
    {
        private IBasicDataService<PlantStockEntry> _dataService;

        public PlantStockEntryUpdateEditModelFormHandler(IBasicDataService<PlantStockEntry> dataService)
        {
            _dataService = dataService;
        }

        public void Handle(PlantStockEntryUpdateEditModel form)
        {
            // Map local model to business object
            PlantStockEntry item = AutoMapper.Mapper.Map<PlantStockEntryUpdateEditModel, PlantStockEntry>(form);

            UpdateRequest<PlantStockEntry> request = new UpdateRequest<PlantStockEntry>(item);

            IUpdateResponse<PlantStockEntry> response = _dataService.Update(request);
        }
    }
}