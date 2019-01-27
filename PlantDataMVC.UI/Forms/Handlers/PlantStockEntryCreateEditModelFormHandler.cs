using System.Threading.Tasks;
using Framework.Web.Forms;
using Interfaces.WcfService;
using Interfaces.WcfService.Responses;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.UI.Models.EditModels;
using PlantDataMVC.WCFService.ServiceContracts;

namespace PlantDataMVC.UI.Forms.Handlers
{
    public class PlantStockEntryCreateEditModelFormHandler : IFormHandler<PlantStockEntryCreateEditModel>
    {
        private readonly IPlantStockWcfService _dataService;

        public PlantStockEntryCreateEditModelFormHandler(IPlantStockWcfService dataService)
        {
            _dataService = dataService;
        }

        public async Task<bool> HandleAsync(PlantStockEntryCreateEditModel form)
        {
            // Map local model to DTO
            // TODO: Check map exists
            PlantStockDto item = AutoMapper.Mapper.Map<PlantStockEntryCreateEditModel, PlantStockDto>(form);

            ICreateResponse<PlantStockDto> response = _dataService.Create(item);
            return (response.Status == ServiceActionStatus.Created);
        }
    }
}