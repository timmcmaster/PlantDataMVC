using System.Threading.Tasks;
using Framework.Web.Forms;
using Interfaces.WcfService;
using Interfaces.WcfService.Responses;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.UI.Models.EditModels;
using PlantDataMVC.WCFService.ServiceContracts;

namespace PlantDataMVC.UI.Forms.Handlers
{
    public class SiteCreateEditModelFormHandler : IFormHandler<SiteCreateEditModel>
    {
        private readonly ISiteWcfService _dataService;

        public SiteCreateEditModelFormHandler(ISiteWcfService dataService)
        {
            _dataService = dataService;
        }

        public async Task<bool> HandleAsync(SiteCreateEditModel form)
        {
            // Map local model to DTO
            // TODO: Check map exists
            SiteDto item = AutoMapper.Mapper.Map<SiteCreateEditModel, SiteDto>(form);

            ICreateResponse<SiteDto> response = _dataService.Create(item);
            return (response.Status == ServiceActionStatus.Created);
        }
    }
}