using Framework.Service.Entities;
using Framework.Web.Forms;
using Interfaces.Service;
using PlantDataMVC.Domain.Entities;
using PlantDataMVC.Service.ServiceContracts;
using PlantDataMVC.UI.Models;

namespace PlantDataMVC.UI.Forms.Handlers
{
    public class SiteCreateEditModelFormHandler : IFormHandler<SiteCreateEditModel>
    {
        private IPlantSeedSiteDataService _dataService;

        public SiteCreateEditModelFormHandler(IPlantSeedSiteDataService dataService)
        {
            _dataService = dataService;
        }

        public void Handle(SiteCreateEditModel form)
        {
            // Map local model to business object
            PlantSeedSite item = AutoMapper.Mapper.Map<SiteCreateEditModel, PlantSeedSite>(form);

            //CreateRequest<PlantSeedSite> request = new CreateRequest<PlantSeedSite>(item);

            ICreateResponse<PlantSeedSite> response = _dataService.Create(item);
        }
    }
}