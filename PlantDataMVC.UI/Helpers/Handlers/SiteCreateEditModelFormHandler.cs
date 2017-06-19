using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PlantDataMVC.UI.Models;
using PlantDataMVC.Domain.Entities;
using Framework.Service.ServiceLayer;

namespace PlantDataMVC.UI.Helpers.Handlers
{
    public class SiteCreateEditModelFormHandler : IFormHandler<SiteCreateEditModel>
    {
        private IBasicDataService<PlantSeedSite> _dataService;

        public SiteCreateEditModelFormHandler(IBasicDataService<PlantSeedSite> dataService)
        {
            _dataService = dataService;
        }

        public void Handle(SiteCreateEditModel form)
        {
            // Map local model to business object
            PlantSeedSite item = AutoMapper.Mapper.Map<SiteCreateEditModel, PlantSeedSite>(form);

            CreateRequest<PlantSeedSite> request = new CreateRequest<PlantSeedSite>(item);

            CreateResponse<PlantSeedSite> response = _dataService.Create(request);
        }
    }
}