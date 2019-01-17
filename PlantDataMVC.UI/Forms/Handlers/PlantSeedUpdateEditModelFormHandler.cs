﻿using Framework.Web.Forms;
using Interfaces.Service.Responses;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.UI.Models.EditModels;
using PlantDataMVC.WCFService.ServiceContracts;

namespace PlantDataMVC.UI.Forms.Handlers
{
    public class PlantSeedUpdateEditModelFormHandler : IFormHandler<PlantSeedUpdateEditModel>
    {
        private ISeedBatchWcfService _dataService;

        public PlantSeedUpdateEditModelFormHandler(ISeedBatchWcfService dataService)
        {
            _dataService = dataService;
        }

        public void Handle(PlantSeedUpdateEditModel form)
        {
            // Map local model to DTO
            // TODO: Check map exists
            var item = AutoMapper.Mapper.Map<PlantSeedUpdateEditModel, SeedBatchDto>(form);

            var response = _dataService.Update(item.Id,item);
        }
    }
}