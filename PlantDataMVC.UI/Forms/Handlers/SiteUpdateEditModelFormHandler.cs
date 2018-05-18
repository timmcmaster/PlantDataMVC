using Framework.Service.Entities;
using Framework.Web.Forms;
using Interfaces.Service;
using PlantDataMVC.Domain.Entities;
using PlantDataMVC.UI.Models;

namespace PlantDataMVC.UI.Forms.Handlers
{
    public class SiteUpdateEditModelFormHandler : IFormHandler<SiteUpdateEditModel>
    {
        private IDataServiceBase<PlantSeedSite> _dataService;

        public SiteUpdateEditModelFormHandler(IDataServiceBase<PlantSeedSite> dataService)
        {
            _dataService = dataService;
        }

        public void Handle(SiteUpdateEditModel form)
        {
            // Map local model to business object
            PlantSeedSite item = AutoMapper.Mapper.Map<SiteUpdateEditModel, PlantSeedSite>(form);

            UpdateRequest<PlantSeedSite> request = new UpdateRequest<PlantSeedSite>(item);

            IUpdateResponse<PlantSeedSite> response = _dataService.Update(request);
        }
    }
}