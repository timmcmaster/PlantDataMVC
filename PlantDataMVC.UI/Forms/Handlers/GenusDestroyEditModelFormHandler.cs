using Framework.Web.Forms;
using Interfaces.Service.Responses;
using PlantDataMVC.DTO.Entities;
using PlantDataMVC.UI.Models.EditModels;
using PlantDataMVC.WCFService.ServiceContracts;

namespace PlantDataMVC.UI.Forms.Handlers
{
    public class GenusDestroyEditModelFormHandler : IFormHandler<GenusDestroyEditModel>
    {
        private IGenusWcfService _dataService;

        public GenusDestroyEditModelFormHandler(IGenusWcfService dataService)
        {
            _dataService = dataService;
        }

        public void Handle(GenusDestroyEditModel form)
        {
            // Map local model to business object
            // TODO: Check map exists
            GenusDTO item = AutoMapper.Mapper.Map<GenusDestroyEditModel, GenusDTO>(form);

            //DeleteRequest<GenusDTO> request = new DeleteRequest<GenusDTO>(item.Id);

            IDeleteResponse<GenusDTO> response = _dataService.Delete(item.Id);
        }
    }
}