﻿using System.Threading.Tasks;
using Framework.Web.Forms;
using Interfaces.WcfService;
using Interfaces.WcfService.Responses;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.UI.Models.EditModels;
using PlantDataMVC.WCFService.ServiceContracts;

namespace PlantDataMVC.UI.Forms.Handlers
{
    public class PlantStockTransactionDestroyEditModelFormHandler : IFormHandler<PlantStockTransactionDestroyEditModel>
    {
        private readonly IJournalEntryWcfService _dataService;

        public PlantStockTransactionDestroyEditModelFormHandler(IJournalEntryWcfService dataService)
        {
            _dataService = dataService;
        }

        public async Task<bool> HandleAsync(PlantStockTransactionDestroyEditModel form)
        {
            IDeleteResponse<JournalEntryDto> response = _dataService.Delete(form.Id);
            return (response.Status == ServiceActionStatus.Deleted);
        }
    }
}