using Framework.Web.Forms;
using Interfaces.Service.Responses;
using PlantDataMVC.DTO.Entities;
using PlantDataMVC.UI.Models.EditModels;
using PlantDataMVC.WCFService.ServiceContracts;

namespace PlantDataMVC.UI.Forms.Handlers
{
    public class PlantStockEntryUpdateEditModelFormHandler : IFormHandler<PlantStockEntryUpdateEditModel>
    {
        private IPlantStockWcfService _dataService;

        public PlantStockEntryUpdateEditModelFormHandler(IPlantStockWcfService dataService)
        {
            _dataService = dataService;
        }

        public void Handle(PlantStockEntryUpdateEditModel form)
        {
            // Map local model to DTO
            // TODO: Check map exists
            var item = AutoMapper.Mapper.Map<PlantStockEntryUpdateEditModel, PlantStockDto>(form);

            var response = _dataService.Update<PlantStockDto,PlantStockDto> (item.Id, item);
        }
    }
}