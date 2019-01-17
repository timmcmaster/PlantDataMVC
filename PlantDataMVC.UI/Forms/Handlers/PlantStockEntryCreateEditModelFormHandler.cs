using Framework.Web.Forms;
using Interfaces.Service.Responses;
using PlantDataMVC.DTO.Entities;
using PlantDataMVC.UI.Models.EditModels;
using PlantDataMVC.WCFService.ServiceContracts;

namespace PlantDataMVC.UI.Forms.Handlers
{
    public class PlantStockEntryCreateEditModelFormHandler : IFormHandler<PlantStockEntryCreateEditModel>
    {
        private IPlantStockWcfService _dataService;

        public PlantStockEntryCreateEditModelFormHandler(IPlantStockWcfService dataService)
        {
            _dataService = dataService;
        }

        public void Handle(PlantStockEntryCreateEditModel form)
        {
            // Map local model to DTO
            // TODO: Check map exists
            var item = AutoMapper.Mapper.Map<PlantStockEntryCreateEditModel, PlantStockDto>(form);

            var response = _dataService.Create(item);
        }
    }
}