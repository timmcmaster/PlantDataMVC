using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PlantDataMvc3.UI.Models;
using PlantDataMvc3.Core.Domain;
using PlantDataMvc3.Core.Domain.BusinessObjects;
using PlantDataMvc3.Core.ServiceLayer;

namespace PlantDataMvc3.UI.Helpers.Handlers
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