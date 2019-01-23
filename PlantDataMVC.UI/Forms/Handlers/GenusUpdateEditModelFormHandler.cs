using Framework.Web.Forms;
using Interfaces.WcfService.Responses;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.UI.Models.EditModels;
using PlantDataMVC.WCFService.ServiceContracts;

namespace PlantDataMVC.UI.Forms.Handlers
{
    public class GenusUpdateEditModelFormHandler : IFormHandler<GenusUpdateEditModel>
    {
        private readonly IGenusWcfService _dataService;

        public GenusUpdateEditModelFormHandler(IGenusWcfService dataService)
        {
            _dataService = dataService;
        }

        public void Handle(GenusUpdateEditModel form)
        {
            // Map local model to DTO
            // TODO: Check map exists
            CreateUpdateGenusDto item = AutoMapper.Mapper.Map<GenusUpdateEditModel, CreateUpdateGenusDto>(form);

            IUpdateResponse<GenusDto> response = _dataService.Update(form.Id, item);
        }
    }
}