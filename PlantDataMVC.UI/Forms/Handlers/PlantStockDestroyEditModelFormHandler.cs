using System.Threading.Tasks;
using Framework.Web.Forms;
using Interfaces.WcfService;
using Interfaces.WcfService.Responses;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.UI.Models.EditModels;
using PlantDataMVC.WCFService.ServiceContracts;

namespace PlantDataMVC.UI.Forms.Handlers
{
    public class PlantStockDestroyEditModelFormHandler : IFormHandler<PlantStockDestroyEditModel>
    {
        private readonly IPlantStockWcfService _dataService;

        public PlantStockDestroyEditModelFormHandler(IPlantStockWcfService dataService)
        {
            _dataService = dataService;
        }

        public async Task<bool> HandleAsync(PlantStockDestroyEditModel form)
        {
            IDeleteResponse<PlantStockDto> response = _dataService.Delete(form.Id);
            return (response.Status == ServiceActionStatus.Deleted);
        }
    }
}