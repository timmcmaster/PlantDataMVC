using Framework.Web.Forms;
using Interfaces.Service.Responses;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.UI.Models.EditModels;
using PlantDataMVC.WCFService.ServiceContracts;

namespace PlantDataMVC.UI.Forms.Handlers
{
    public class GenusUpdateEditModelFormHandler : IFormHandler<GenusUpdateEditModel>
    {
        private IGenusWcfService _dataService;

        public GenusUpdateEditModelFormHandler(IGenusWcfService dataService)
        {
            _dataService = dataService;
        }

        public void Handle(GenusUpdateEditModel form)
        {
            // Map local model to DTO
            // TODO: Check map exists
            var item = AutoMapper.Mapper.Map<GenusUpdateEditModel, CreateUpdateGenusDto>(form);

            var response = _dataService.Update(form.Id, item);
        }
    }
}