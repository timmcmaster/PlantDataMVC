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
            // Map local model to business object
            GenusDTO item = AutoMapper.Mapper.Map<GenusUpdateEditModel, GenusDTO>(form);

            //UpdateRequest<GenusDTO> request = new UpdateRequest<GenusDTO>(item);

            IUpdateResponse<GenusDTO> response = _dataService.Update(item.Id, item);
        }
    }
}