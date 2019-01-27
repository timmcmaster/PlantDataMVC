using System.Threading.Tasks;
using Framework.Web.Forms;
using Interfaces.WcfService;
using Interfaces.WcfService.Responses;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.UI.Models.EditModels;
using PlantDataMVC.WCFService.ServiceContracts;

namespace PlantDataMVC.UI.Forms.Handlers
{
    public class PlantSeedCreateEditModelFormHandler : IFormHandler<PlantSeedCreateEditModel>
    {
        private readonly ISeedBatchWcfService _dataService;

        public PlantSeedCreateEditModelFormHandler(ISeedBatchWcfService dataService)
        {
            _dataService = dataService;
        }

        public async Task<bool> HandleAsync(PlantSeedCreateEditModel form)
        {
            // Map local model to DTO
            // TODO: Check map exists
            SeedBatchDto item = AutoMapper.Mapper.Map<PlantSeedCreateEditModel, SeedBatchDto>(form);

            ICreateResponse<SeedBatchDto> response = _dataService.Create(item);
            return (response.Status == ServiceActionStatus.Created);
        }
    }
}