using Framework.Web.Core.Forms;
using Newtonsoft.Json;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.UICore.Helpers;
using PlantDataMVC.UICore.Models.EditModels.Transaction;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PlantDataMVC.UICore.Handlers.Forms.Transaction
{
    public class TransactionCreateEditModelFormHandler : IFormHandler<TransactionCreateEditModel, bool>
    {
        private readonly IPlantDataApiClient _plantDataApiClient;

        public TransactionCreateEditModelFormHandler(IPlantDataApiClient plantDataApiClient)
        {
            _plantDataApiClient = plantDataApiClient;
        }

        public async Task<bool> HandleAsync(TransactionCreateEditModel form, CancellationToken cancellationToken)
        {
            try
            {
                // Map local model to DTO
                JournalEntryDto item = AutoMapper.Mapper.Map<TransactionCreateEditModel, JournalEntryDto>(form);
                var serializedItem = JsonConvert.SerializeObject(item);
                var content = new StringContent(serializedItem, Encoding.Unicode, "application/json");

                var uri = "api/JournalEntries";
                var httpResponse = await _plantDataApiClient.PostAsync(uri, content, cancellationToken).ConfigureAwait(false);

                return httpResponse.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}