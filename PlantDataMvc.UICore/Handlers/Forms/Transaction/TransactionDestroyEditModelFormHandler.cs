using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Framework.Web.Core.Forms;
using PlantDataMVC.UICore.Helpers;
using PlantDataMVC.UICore.Models.EditModels.Transaction;

namespace PlantDataMVC.UICore.Handlers.Forms.Transaction
{
    public class TransactionDestroyEditModelFormHandler : IFormHandler<TransactionDestroyEditModel, bool>
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TransactionDestroyEditModelFormHandler(IHttpClientFactory httpClientFactory)
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