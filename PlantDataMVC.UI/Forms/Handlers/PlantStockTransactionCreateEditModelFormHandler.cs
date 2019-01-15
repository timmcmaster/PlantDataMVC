using Framework.Web.Forms;
using Interfaces.Service.Responses;
using PlantDataMVC.DTO.Entities;
using PlantDataMVC.UI.Models;
using PlantDataMVC.dataService.ServiceContracts;

namespace PlantDataMVC.UI.Forms.Handlers
{
    public class PlantStockTransactionCreateEditModelFormHandler : IFormHandler<PlantStockTransactionCreateEditModel>
    {
        private IJournalEntryWcfService _dataService;

        public PlantStockTransactionCreateEditModelFormHandler(IJournalEntryWcfService dataService)
        {
            _dataService = dataService;
        }

        public void Handle(PlantStockTransactionCreateEditModel form)
        {
            // Map local model to business object
            JournalEntryDTO item = AutoMapper.Mapper.Map<PlantStockTransactionCreateEditModel, JournalEntryDTO>(form);

            //CreateRequest<JournalEntryDTO> request = new CreateRequest<JournalEntryDTO>(item);

            ICreateResponse<JournalEntryDTO> response = _dataService.Create(item);
        }
    }
}