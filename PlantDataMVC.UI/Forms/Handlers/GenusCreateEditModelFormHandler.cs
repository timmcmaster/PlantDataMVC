using Framework.Web.Forms;
using Interfaces.Service.Responses;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.UI.Models.EditModels;
using PlantDataMVC.WCFService.ServiceContracts;

namespace PlantDataMVC.UI.Forms.Handlers
{
    public class GenusCreateEditModelFormHandler : IFormHandler<GenusCreateEditModel>
    {
        private IGenusWcfService _dataService;

        public GenusCreateEditModelFormHandler(IGenusWcfService dataService)
        {
            _dataService = dataService;
        }

        public void Handle(GenusCreateEditModel form)
        {
            // Map local model to DTO
            // TODO: Check map exists
            var item = AutoMapper.Mapper.Map<GenusCreateEditModel, GenusDto>(form);

            var response = _dataService.Create(item);
        }
    }
}