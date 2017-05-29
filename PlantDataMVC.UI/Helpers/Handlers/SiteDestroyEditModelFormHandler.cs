using PlantDataMVC.Core.Domain.BusinessObjects;
using PlantDataMVC.Core.ServiceLayer;
using PlantDataMVC.UI.Models;

namespace PlantDataMVC.UI.Helpers.Handlers
{
    public class SiteDestroyEditModelFormHandler : IFormHandler<SiteDestroyEditModel>
    {
        private IBasicDataService<PlantSeedSite> _dataService;

        public SiteDestroyEditModelFormHandler(IBasicDataService<PlantSeedSite> dataService)
        {
            _dataService = dataService;
        }

        public void Handle(SiteDestroyEditModel form)
        {
            // Map local model to business object
            PlantSeedSite item = AutoMapper.Mapper.Map<SiteDestroyEditModel, PlantSeedSite>(form);

            DeleteRequest<PlantSeedSite> request = new DeleteRequest<PlantSeedSite>(item.Id);

            DeleteResponse<PlantSeedSite> response = _dataService.Delete(request);
        }
    }
}