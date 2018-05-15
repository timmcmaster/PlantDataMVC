using Framework.Service.Entities;
using Framework.Web.Forms;
using Interfaces.Service;
using PlantDataMVC.Domain.Entities;
using PlantDataMVC.UI.Models;

namespace PlantDataMVC.UI.Forms.Handlers
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

            IDeleteResponse<PlantSeedSite> response = _dataService.Delete(request);
        }
    }
}