using Framework.Web.Forms;
using Interfaces.Service.Responses;
using PlantDataMVC.DTO.Dtos;
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
            // Map local model to DTO
            // TODO: Check map exists
            var item = AutoMapper.Mapper.Map<PlantUpdateEditModel, SpeciesDto>(form);

            var response = _dataService.Update(item.Id, item);
        }
    }
}