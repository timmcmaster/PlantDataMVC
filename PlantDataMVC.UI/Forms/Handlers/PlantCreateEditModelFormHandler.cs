using Framework.Web.Forms;
using Interfaces.Service.Responses;
using PlantDataMVC.DTO.Entities;
using PlantDataMVC.UI.Models.EditModels;
using PlantDataMVC.WCFService.ServiceContracts;

namespace PlantDataMVC.UI.Forms.Handlers
{
    public class PlantCreateEditModelFormHandler : IFormHandler<PlantCreateEditModel>
    {
        private ISpeciesWcfService _dataService;

        public PlantCreateEditModelFormHandler(ISpeciesWcfService dataService)
        {
            _dataService = dataService;
        }

        public void Handle(PlantCreateEditModel form)
        {
            // Map local model to business object
            // TODO: Check map exists
            SpeciesDTO item = AutoMapper.Mapper.Map<PlantCreateEditModel, SpeciesDTO>(form);

            //CreateRequest<Plant> request = new CreateRequest<Plant>(item);

            ICreateResponse<SpeciesDTO> response = _dataService.Create(item);
        }
    }
}