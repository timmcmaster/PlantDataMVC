using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Framework.Web.Core.Forms;
using PlantDataMVC .UICore.Helpers;
using PlantDataMVC.UICore.Models.EditModels.Genus;

namespace PlantDataMVC.UICore.Handlers.Forms.Genus
{
    public class GenusDestroyEditModelFormHandler : IFormHandler<GenusDestroyEditModel, bool>
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public GenusDestroyEditModelFormHandler(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<bool> HandleAsync(GenusDestroyEditModel form, CancellationToken cancellationToken)
        {
            try
            {
                var httpClient = _httpClientFactory.CreateClient(NamedHttpClients.PlantDataApi);
                var uri = "api/Genus/" + form.Id;
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