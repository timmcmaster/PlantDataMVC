using System.Threading;
using System.Threading.Tasks;
using Framework.Web.Forms;
using PlantDataMVC.UI.Helpers;
using PlantDataMVC.UI.Models.EditModels.Transaction;

namespace PlantDataMVC.UI.Handlers.Forms.Transaction
{
    public class TransactionDestroyEditModelFormHandler : IFormHandler<TransactionDestroyEditModel, bool>
    {
        private readonly IMyHttpClientFactory _httpClientFactory;

        public TransactionDestroyEditModelFormHandler(IMyHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<bool> HandleAsync(TransactionDestroyEditModel form, CancellationToken cancellationToken)
        {
            try
            {
                var httpClient = _httpClientFactory.CreateClient(NamedHttpClients.PlantDataApi);
                var uri = "api/JournalEntries/" + form.Id;
                var httpResponse = await httpClient.DeleteAsync(uri, cancellationToken).ConfigureAwait(false);

                return httpResponse.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}