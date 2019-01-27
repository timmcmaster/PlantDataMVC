﻿using System.Threading.Tasks;
using Framework.Web.Forms;
using Interfaces.WcfService;
using Interfaces.WcfService.Responses;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.UI.Models.EditModels;
using PlantDataMVC.WCFService.ServiceContracts;

namespace PlantDataMVC.UI.Forms.Handlers
{
    public class PlantSeedUpdateEditModelFormHandler : IFormHandler<PlantSeedUpdateEditModel>
    {
        private readonly ISeedBatchWcfService _dataService;

        public PlantSeedUpdateEditModelFormHandler(ISeedBatchWcfService dataService)
        {
            _dataService = dataService;
        }

        public async Task<bool> HandleAsync(PlantSeedUpdateEditModel form)
        {
            // Map local model to DTO
            // TODO: Check map exists
            SeedBatchDto item = AutoMapper.Mapper.Map<PlantSeedUpdateEditModel, SeedBatchDto>(form);

            IUpdateResponse<SeedBatchDto> response = _dataService.Update(item.Id,item);
            return (response.Status == ServiceActionStatus.Updated);
        }
    }
}