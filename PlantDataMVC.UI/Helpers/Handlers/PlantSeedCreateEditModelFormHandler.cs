using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PlantDataMVC.UI.Models;
using PlantDataMVC.Core.Domain;
using PlantDataMVC.Core.Domain.BusinessObjects;
using PlantDataMVC.Core.ServiceLayer;

namespace PlantDataMVC.UI.Helpers.Handlers
{
    public class PlantSeedCreateEditModelFormHandler : IFormHandler<PlantSeedCreateEditModel>
    {
        private IBasicDataService<PlantSeed> _dataService;

        public PlantSeedCreateEditModelFormHandler(IBasicDataService<PlantSeed> dataService)
        {
            _dataService = dataService;
        }

        public void Handle(PlantSeedCreateEditModel form)
        {
            // Map local model to business object
            PlantSeed item = AutoMapper.Mapper.Map<PlantSeedCreateEditModel, PlantSeed>(form);

            CreateRequest<PlantSeed> request = new CreateRequest<PlantSeed>(item);

            CreateResponse<PlantSeed> response = _dataService.Create(request);
        }
    }
}