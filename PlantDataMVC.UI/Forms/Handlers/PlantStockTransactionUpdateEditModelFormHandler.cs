using Framework.Web.Forms;
using Interfaces.Service.Responses;
using PlantDataMVC.DTO.Entities;
using PlantDataMVC.UI.Models;
using PlantDataMVC.dataService.ServiceContracts;


namespace PlantDataMVC.UI.Forms.Handlers
{
    public class PlantStockTransactionUpdateEditModelFormHandler : IFormHandler<PlantStockTransactionUpdateEditModel>
    {
        private IJournalEntryWcfService _dataService;

        public PlantStockTransactionUpdateEditModelFormHandler(IJournalEntryWcfService dataService)
        {
            _dataService = dataService;
        }

        public void Handle(PlantStockTransactionUpdateEditModel form)
        {
            // Map local model to business object
            JournalEntryDTO item = AutoMapper.Mapper.Map<PlantStockTransactionUpdateEditModel, JournalEntryDTO>(form);

            //UpdateRequest<JournalEntryDTO> request = new UpdateRequest<JournalEntryDTO>(item);

            IUpdateResponse<JournalEntryDTO> response = _dataService.Update(item.Id, item);
        }
    }
}