using Framework.Web.Forms;
using Interfaces.Service.Responses;
using PlantDataMVC.DTO.Entities;
using PlantDataMVC.UI.Models.EditModels;
using PlantDataMVC.WCFService.ServiceContracts;

namespace PlantDataMVC.UI.Forms.Handlers
{
    public class PlantUpdateEditModelFormHandler : IFormHandler<PlantUpdateEditModel>
    {
        private ISpeciesWcfService _dataService;

        public PlantUpdateEditModelFormHandler(ISpeciesWcfService dataService)
        {
            _dataService = dataService;
        }

        public void Handle(PlantUpdateEditModel form)
        {
            // Map local model to business object
            // TODO: Check map exists
            SpeciesDTO item = AutoMapper.Mapper.Map<PlantUpdateEditModel, SpeciesDTO>(form);

            //UpdateRequest<SpeciesDTO> request = new UpdateRequest<SpeciesDTO>(item);

            IUpdateResponse<SpeciesDTO> response = _dataService.Update(item.Id, item);
        }
    }
}