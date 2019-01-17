using Framework.Web.Forms;
using Interfaces.Service.Responses;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.UI.Models.EditModels;
using PlantDataMVC.WCFService.ServiceContracts;

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
            // Map local model to DTO
            // TODO: Check map exists
            var item = AutoMapper.Mapper.Map<PlantStockTransactionCreateEditModel, JournalEntryDto>(form);

            var response = _dataService.Create(item);
        }
    }
}