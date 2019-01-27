using System.Threading.Tasks;
using Framework.Web.Forms;
using Interfaces.WcfService;
using Interfaces.WcfService.Responses;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.UI.Models.EditModels;
using PlantDataMVC.WCFService.ServiceContracts;

namespace PlantDataMVC.UI.Forms.Handlers
{
    public class PlantSeedDestroyEditModelFormHandler : IFormHandler<PlantSeedDestroyEditModel>
    {
        private readonly ISeedBatchWcfService _dataService;

        public PlantSeedDestroyEditModelFormHandler(ISeedBatchWcfService dataService)
        {
            _dataService = dataService;
        }

        public async Task<bool> HandleAsync(PlantSeedDestroyEditModel form)
        {
            IDeleteResponse<SeedBatchDto> response = _dataService.Delete(form.Id);
            return (response.Status == ServiceActionStatus.Deleted);
        }
    }
}