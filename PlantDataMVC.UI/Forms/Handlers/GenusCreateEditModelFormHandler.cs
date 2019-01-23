using Framework.Web.Forms;
using Interfaces.WcfService.Responses;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.UI.Models.EditModels;
using PlantDataMVC.WCFService.ServiceContracts;

namespace PlantDataMVC.UI.Forms.Handlers
{
    public class GenusCreateEditModelFormHandler : IFormHandler<GenusCreateEditModel>
    {
        private readonly IGenusWcfService _dataService;

        public GenusCreateEditModelFormHandler(IGenusWcfService dataService)
        {
            _dataService = dataService;
        }

        public void Handle(GenusCreateEditModel form)
        {
            // Map local model to DTO
            // TODO: Check map exists
            CreateUpdateGenusDto item = AutoMapper.Mapper.Map<GenusCreateEditModel, CreateUpdateGenusDto>(form);

            ICreateResponse<GenusDto> response = _dataService.Create(item);
        }
    }
}