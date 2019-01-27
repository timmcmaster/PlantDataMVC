using System.Threading.Tasks;
using Framework.Web.Forms;
using Interfaces.WcfService;
using Interfaces.WcfService.Responses;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.UI.Models.EditModels;
using PlantDataMVC.WCFService.ServiceContracts;

namespace PlantDataMVC.UI.Forms.Handlers
{
    public class TrayUpdateEditModelFormHandler : IFormHandler<TrayUpdateEditModel>
    {
        private readonly ISeedTrayWcfService _dataService;

        public TrayUpdateEditModelFormHandler(ISeedTrayWcfService dataService)
        {
            _dataService = dataService;
        }

        public async Task<bool> HandleAsync(TrayUpdateEditModel form)
        {
            // Map local model to DTO
            SeedTrayDto item = AutoMapper.Mapper.Map<TrayUpdateEditModel, SeedTrayDto>(form);

            IUpdateResponse<SeedTrayDto> response = _dataService.Update(item.Id, item);
            return (response.Status == ServiceActionStatus.Updated);
        }
    }
}