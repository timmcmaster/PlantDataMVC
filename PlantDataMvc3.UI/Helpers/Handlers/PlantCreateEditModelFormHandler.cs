using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PlantDataMvc3.UI.Models;
using PlantDataMVC.Core.Domain;
using PlantDataMVC.Core.Domain.BusinessObjects;
using PlantDataMVC.Core.ServiceLayer;

namespace PlantDataMvc3.UI.Helpers.Handlers
{
    public class PlantCreateEditModelFormHandler : IFormHandler<PlantCreateEditModel>
    {
        private IBasicDataService<Plant> _dataService;

        public PlantCreateEditModelFormHandler(IBasicDataService<Plant> dataService)
        {
            _dataService = dataService;
        }

        public void Handle(PlantCreateEditModel form)
        {
            // Map local model to business object
            Plant item = AutoMapper.Mapper.Map<PlantCreateEditModel, Plant>(form);

            CreateRequest<Plant> request = new CreateRequest<Plant>(item);

            CreateResponse<Plant> response = _dataService.Create(request);
        }
    }
}