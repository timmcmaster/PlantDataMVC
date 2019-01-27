using System.Threading.Tasks;
using Framework.Web.Forms;
using Interfaces.WcfService;
using Interfaces.WcfService.Responses;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.UI.Models.EditModels;
using PlantDataMVC.WCFService.ServiceContracts;

namespace PlantDataMVC.UI.Forms.Handlers
{
    public class PlantStockTransactionCreateEditModelFormHandler : IFormHandler<PlantStockTransactionCreateEditModel>
    {
        private readonly IJournalEntryWcfService _dataService;

        public PlantStockTransactionCreateEditModelFormHandler(IJournalEntryWcfService dataService)
        {
            _dataService = dataService;
        }

        public async Task<bool> HandleAsync(PlantStockTransactionCreateEditModel form)
        {
            // Map local model to DTO
            // TODO: Check map exists
            JournalEntryDto item = AutoMapper.Mapper.Map<PlantStockTransactionCreateEditModel, JournalEntryDto>(form);

            ICreateResponse<JournalEntryDto> response = _dataService.Create(item);
            return (response.Status == ServiceActionStatus.Created);
        }
    }
}