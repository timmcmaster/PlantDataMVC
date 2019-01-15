﻿using Framework.Web.Forms;
using Interfaces.Service.Responses;
using PlantDataMVC.DTO.Entities;
using PlantDataMVC.UI.Models;
using PlantDataMVC.dataService.ServiceContracts;

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
            // Map local model to business object
            JournalEntryDTO item = AutoMapper.Mapper.Map<PlantStockTransactionDestroyEditModel, JournalEntryDTO>(form);

            //DeleteRequest<JournalEntryDTO> request = new DeleteRequest<JournalEntryDTO>(item.Id);

            IDeleteResponse<JournalEntryDTO> response = _dataService.Delete(item.Id);
        }
    }
}