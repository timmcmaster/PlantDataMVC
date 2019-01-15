using Framework.Web.Forms;
using Interfaces.Service.Responses;
using PlantDataMVC.DTO.Entities;
using PlantDataMVC.UI.Models;
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
            // Map local model to business object
            PlantStockDTO item = AutoMapper.Mapper.Map<PlantStockEntryUpdateEditModel, PlantStockDTO>(form);

            //UpdateRequest<PlantStockDTO> request = new UpdateRequest<PlantStockDTO>(item);

            IUpdateResponse<PlantStockDTO> response = _dataService.Update(item.Id, item);
        }
    }
}