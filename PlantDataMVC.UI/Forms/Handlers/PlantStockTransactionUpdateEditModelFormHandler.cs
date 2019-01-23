﻿using Framework.Web.Forms;
using Interfaces.WcfService.Responses;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.UI.Models.EditModels;
using PlantDataMVC.WCFService.ServiceContracts;


namespace PlantDataMVC.UI.Forms.Handlers
{
    public class PlantStockTransactionUpdateEditModelFormHandler : IFormHandler<PlantStockTransactionUpdateEditModel>
    {
        private readonly IJournalEntryWcfService _dataService;

        public PlantStockTransactionUpdateEditModelFormHandler(IJournalEntryWcfService dataService)
        {
            _dataService = dataService;
        }

        public void Handle(PlantStockTransactionUpdateEditModel form)
        {
            // Map local model to DTO
            // TODO: Check map exists
            JournalEntryDto item = AutoMapper.Mapper.Map<PlantStockTransactionUpdateEditModel, JournalEntryDto>(form);

            IUpdateResponse<JournalEntryDto> response = _dataService.Update(item.Id, item);
        }
    }
}