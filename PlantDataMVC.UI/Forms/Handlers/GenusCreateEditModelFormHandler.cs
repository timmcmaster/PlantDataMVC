using Framework.Web.Forms;
using Interfaces.Service.Responses;
using PlantDataMVC.DTO.Entities;
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
            // Map local model to business object
            // TODO: Check map exists
            GenusDTO item = AutoMapper.Mapper.Map<GenusCreateEditModel, GenusDTO>(form);

            //CreateRequest<GenusDTO> request = new CreateRequest<GenusDTO>(item);

            ICreateResponse<GenusDTO> response = _dataService.Create(item);
        }
    }
}