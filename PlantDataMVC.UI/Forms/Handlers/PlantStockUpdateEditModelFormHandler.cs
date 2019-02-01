using System.Threading.Tasks;
using Framework.Web.Forms;
using Interfaces.WcfService;
using Interfaces.WcfService.Responses;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.UI.Models.EditModels;
using PlantDataMVC.WCFService.ServiceContracts;

namespace PlantDataMVC.UI.Forms.Handlers
{
    public class PlantStockUpdateEditModelFormHandler : IFormHandler<PlantStockUpdateEditModel>
    {
        private readonly IPlantStockWcfService _dataService;

        public PlantStockUpdateEditModelFormHandler(IPlantStockWcfService dataService)
        {
            _dataService = dataService;
        }

        public async Task<bool> HandleAsync(PlantStockUpdateEditModel form)
        {
            // Map local model to DTO
            // TODO: Check map exists
            PlantStockDto item = AutoMapper.Mapper.Map<PlantStockUpdateEditModel, PlantStockDto>(form);

            IUpdateResponse<PlantStockDto> response = _dataService.Update(item.Id, item);
            return (response.Status == ServiceActionStatus.Updated);
        }
    }
}