using Framework.Web.Forms;
using Interfaces.Service.Responses;
using PlantDataMVC.DTO.Entities;
using PlantDataMVC.UI.Models.EditModels;
using PlantDataMVC.WCFService.ServiceContracts;

namespace PlantDataMVC.UI.Forms.Handlers
{
    public class PlantStockEntryDestroyEditModelFormHandler : IFormHandler<PlantStockEntryDestroyEditModel>
    {
        private IPlantStockWcfService _dataService;

        public PlantStockEntryDestroyEditModelFormHandler(IPlantStockWcfService dataService)
        {
            _dataService = dataService;
        }

        public void Handle(PlantStockEntryDestroyEditModel form)
        {
            // Map local model to business object
            PlantStockDTO item = AutoMapper.Mapper.Map<PlantStockEntryDestroyEditModel, PlantStockDTO>(form);

            //DeleteRequest<PlantStockDTO> request = new DeleteRequest<PlantStockDTO>(item.Id);

            IDeleteResponse<PlantStockDTO> response = _dataService.Delete(item.Id);
        }
    }
}