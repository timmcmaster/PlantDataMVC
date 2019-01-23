using Framework.Web.Forms;
using Interfaces.WcfService.Responses;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.UI.Models.EditModels;
using PlantDataMVC.WCFService.ServiceContracts;

namespace PlantDataMVC.UI.Forms.Handlers
{
    public class PlantStockEntryUpdateEditModelFormHandler : IFormHandler<PlantStockEntryUpdateEditModel>
    {
        private readonly IPlantStockWcfService _dataService;

        public PlantStockEntryUpdateEditModelFormHandler(IPlantStockWcfService dataService)
        {
            _dataService = dataService;
        }

        public void Handle(PlantStockEntryUpdateEditModel form)
        {
            // Map local model to DTO
            // TODO: Check map exists
            PlantStockDto item = AutoMapper.Mapper.Map<PlantStockEntryUpdateEditModel, PlantStockDto>(form);

            IUpdateResponse<PlantStockDto> response = _dataService.Update(item.Id, item);
        }
    }
}