﻿using PlantDataMVC.Core.Domain.BusinessObjects;
using PlantDataMvc3.UI.Models;
using PlantDataMVC.Core.ServiceLayer;

namespace PlantDataMvc3.UI.Helpers.Handlers
{
    public class SiteUpdateEditModelFormHandler : IFormHandler<SiteUpdateEditModel>
    {
        private IBasicDataService<PlantSeedSite> _dataService;

        public SiteUpdateEditModelFormHandler(IBasicDataService<PlantSeedSite> dataService)
        {
            _dataService = dataService;
        }

        public void Handle(SiteUpdateEditModel form)
        {
            // Map local model to business object
            PlantSeedSite item = AutoMapper.Mapper.Map<SiteUpdateEditModel, PlantSeedSite>(form);

            UpdateRequest<PlantSeedSite> request = new UpdateRequest<PlantSeedSite>(item);

            UpdateResponse<PlantSeedSite> response = _dataService.Update(request);
        }
    }
}