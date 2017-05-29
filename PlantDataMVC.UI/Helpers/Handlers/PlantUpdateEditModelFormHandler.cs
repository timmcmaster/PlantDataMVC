﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PlantDataMVC.UI.Models;
using PlantDataMVC.Core.Domain;
using PlantDataMVC.Core.Domain.BusinessObjects;
using PlantDataMVC.Core.ServiceLayer;

namespace PlantDataMVC.UI.Helpers.Handlers
{
    public class PlantUpdateEditModelFormHandler : IFormHandler<PlantUpdateEditModel>
    {
        private IBasicDataService<Plant> _dataService;

        public PlantUpdateEditModelFormHandler(IBasicDataService<Plant> dataService)
        {
            _dataService = dataService;
        }

        public void Handle(PlantUpdateEditModel form)
        {
            // Map local model to business object
            Plant item = AutoMapper.Mapper.Map<PlantUpdateEditModel, Plant>(form);

            UpdateRequest<Plant> request = new UpdateRequest<Plant>(item);

            UpdateResponse<Plant> response = _dataService.Update(request);
        }
    }
}