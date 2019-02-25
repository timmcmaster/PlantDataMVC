using System.Threading;
using System.Threading.Tasks;
using Framework.Web.Forms;
using PlantDataMVC.UI.Helpers;
using PlantDataMVC.UI.Models.EditModels.SeedBatch;

namespace PlantDataMVC.UI.Handlers.Forms.SeedBatch
{
    public class SeedBatchDestroyEditModelFormHandler : IFormHandler<SeedBatchDestroyEditModel, bool>
    {
        private readonly IMyHttpClientFactory _httpClientFactory;

        public SeedBatchDestroyEditModelFormHandler(IMyHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<bool> HandleAsync(SeedBatchDestroyEditModel form, CancellationToken cancellationToken)
        {
            try
            {
                var httpClient = _httpClientFactory.CreateClient(NamedHttpClients.PlantDataApi);
                var uri = "api/SeedBatch/" + form.Id;
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