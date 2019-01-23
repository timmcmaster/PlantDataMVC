using Framework.Web.Forms;
using Interfaces.WcfService.Responses;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.UI.Models.EditModels;
using PlantDataMVC.WCFService.ServiceContracts;

namespace PlantDataMVC.UI.Forms.Handlers
{
    public class TrayCreateEditModelFormHandler : IFormHandler<TrayCreateEditModel>
    {
        private readonly ISeedTrayWcfService _dataService;

        public TrayCreateEditModelFormHandler(ISeedTrayWcfService dataService)
        {
            _dataService = dataService;
        }

        public void Handle(TrayCreateEditModel form)
        {
            // Map local model to DTO
            // TODO: Check map exists
            SeedTrayDto item = AutoMapper.Mapper.Map<TrayCreateEditModel, SeedTrayDto>(form);

            ICreateResponse<SeedTrayDto> response = _dataService.Create(item);
        }
    }
}