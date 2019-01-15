using Framework.Web.Forms;
using Interfaces.Service.Responses;
using PlantDataMVC.DTO.Entities;
using PlantDataMVC.UI.Models.EditModels;
using PlantDataMVC.WCFService.ServiceContracts;

namespace PlantDataMVC.UI.Forms.Handlers
{
    public class PlantDestroyEditModelFormHandler : IFormHandler<PlantDestroyEditModel>
    {
        private ISpeciesWcfService _dataService;

        public PlantDestroyEditModelFormHandler(ISpeciesWcfService dataService)
        {
            _dataService = dataService;
        }

        public void Handle(PlantDestroyEditModel form)
        {
            // Map local model to business object
            // TODO: Check map exists
            SpeciesDTO item = AutoMapper.Mapper.Map<PlantDestroyEditModel, SpeciesDTO>(form);

            //DeleteRequest<SpeciesDTO> request = new DeleteRequest<SpeciesDTO>(item.Id);

            IDeleteResponse<SpeciesDTO> response = _dataService.Delete(item.Id);
        }
    }
}