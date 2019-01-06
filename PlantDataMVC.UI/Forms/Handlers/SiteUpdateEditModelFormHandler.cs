using Framework.Service.Entities;
using Framework.Web.Forms;
using Interfaces.Service;
using PlantDataMVC.Domain.Entities;
using PlantDataMVC.Service.ServiceContracts;
using PlantDataMVC.UI.Models;

namespace PlantDataMVC.UI.Forms.Handlers
{
    public class SiteUpdateEditModelFormHandler : IFormHandler<SiteUpdateEditModel>
    {
        private IPlantSeedSiteDataService _dataService;

        public SiteUpdateEditModelFormHandler(IPlantSeedSiteDataService dataService)
        {
            _dataService = dataService;
        }

        public void Handle(SiteUpdateEditModel form)
        {
            // Map local model to business object
            PlantSeedSite item = AutoMapper.Mapper.Map<SiteUpdateEditModel, PlantSeedSite>(form);

            //UpdateRequest<PlantSeedSite> request = new UpdateRequest<PlantSeedSite>(item);

            IUpdateResponse<PlantSeedSite> response = _dataService.Update(item.Id, item);
        }
    }
}