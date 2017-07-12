using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PlantDataMVC.UI.Models;
using PlantDataMVC.Domain.Entities;
using Framework.Service.ServiceLayer;

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

            DeleteResponse<PlantSeedSite> response = _dataService.Delete(request);
        }
    }
}