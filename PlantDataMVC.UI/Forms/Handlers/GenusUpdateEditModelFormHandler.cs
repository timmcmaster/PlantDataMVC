using Framework.Web.Forms;
using Interfaces.Service.Responses;
using PlantDataMVC.DTO.Entities;
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
            var item = AutoMapper.Mapper.Map<GenusUpdateEditModel, GenusDto>(form);

            var response = _dataService.Update<GenusDto,GenusDto>(item.Id, item);
        }
    }
}