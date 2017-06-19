﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PlantDataMVC.UI.Models;
using PlantDataMVC.Domain.Entities;
using Framework.Service.ServiceLayer;

namespace PlantDataMVC.UI.Helpers.Handlers
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