using System.Threading;
using System.Threading.Tasks;
using Framework.Web.Forms;
using PlantDataMVC.UI.Helpers;
using PlantDataMVC.UI.Models.EditModels.SeedTray;

namespace PlantDataMVC.UI.Handlers.Forms.SeedTray
{
    public class SeedTrayDestroyEditModelFormHandler : IFormHandler<SeedTrayDestroyEditModel, bool>
    {
        private readonly IMyHttpClientFactory _httpClientFactory;

        public SeedTrayDestroyEditModelFormHandler(IMyHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<bool> HandleAsync(SeedTrayDestroyEditModel form, CancellationToken cancellationToken)
        {
            try
            {
                var httpClient = _httpClientFactory.CreateClient(NamedHttpClients.PlantDataApi);
                // todo: if not null client
                var uri = "api/SeedTray/" + form.Id;
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