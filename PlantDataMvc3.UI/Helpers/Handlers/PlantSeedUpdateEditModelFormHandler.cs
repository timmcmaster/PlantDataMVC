﻿using PlantDataMvc3.Core.Domain.BusinessObjects;
using PlantDataMvc3.UI.Models;
using PlantDataMvc3.Core.ServiceLayer;

namespace PlantDataMvc3.UI.Helpers.Handlers
{
    public class PlantSeedUpdateEditModelFormHandler : IFormHandler<PlantSeedUpdateEditModel>
    {
        private IBasicDataService<PlantSeed> _dataService;

        public PlantSeedUpdateEditModelFormHandler(IBasicDataService<PlantSeed> dataService)
        {
            _dataService = dataService;
        }

        public void Handle(PlantSeedUpdateEditModel form)
        {
            // Map local model to business object
            PlantSeed item = AutoMapper.Mapper.Map<PlantSeedUpdateEditModel, PlantSeed>(form);

            UpdateRequest<PlantSeed> request = new UpdateRequest<PlantSeed>(item);

            UpdateResponse<PlantSeed> response = _dataService.Update(request);
        }
    }
}