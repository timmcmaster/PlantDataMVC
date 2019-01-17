﻿using Framework.Web.Forms;
using Interfaces.Service.Responses;
using PlantDataMVC.DTO.Entities;
using PlantDataMVC.UI.Models.EditModels;
using PlantDataMVC.WCFService.ServiceContracts;

namespace PlantDataMVC.UI.Forms.Handlers
{
    public class PlantStockTransactionDestroyEditModelFormHandler : IFormHandler<PlantStockTransactionDestroyEditModel>
    {
        private IJournalEntryWcfService _dataService;

        public PlantStockTransactionDestroyEditModelFormHandler(IJournalEntryWcfService dataService)
        {
            _dataService = dataService;
        }

        public void Handle(PlantStockTransactionDestroyEditModel form)
        {
            var response = _dataService.Delete<JournalEntryDto>(form.Id);
        }
    }
}