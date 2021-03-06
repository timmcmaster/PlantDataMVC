﻿using Framework.Service.Entities;
using Framework.Web.Forms;
using Interfaces.Service;
using PlantDataMVC.Domain.Entities;
using PlantDataMVC.Service.ServiceContracts;
using PlantDataMVC.UI.Models;

namespace PlantDataMVC.UI.Forms.Handlers
{
    public class PlantSeedDestroyEditModelFormHandler : IFormHandler<PlantSeedDestroyEditModel>
    {
        private IPlantSeedDataService _dataService;

        public PlantSeedDestroyEditModelFormHandler(IPlantSeedDataService dataService)
        {
            _dataService = dataService;
        }

        public void Handle(PlantSeedDestroyEditModel form)
        {
            // Map local model to business object
            PlantSeed item = AutoMapper.Mapper.Map<PlantSeedDestroyEditModel, PlantSeed>(form);

            //DeleteRequest<PlantSeed> request = new DeleteRequest<PlantSeed>(item.Id);

            IDeleteResponse<PlantSeed> response = _dataService.Delete(item.Id);
        }
    }
}