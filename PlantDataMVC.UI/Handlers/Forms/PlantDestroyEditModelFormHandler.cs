using System.Net.Http;
using System.Threading.Tasks;
using Framework.Web.Forms;
using PlantDataMVC.UI.Helpers;
using PlantDataMVC.UI.Models.EditModels;

namespace PlantDataMVC.UI.Handlers.Forms
{
    public class PlantDestroyEditModelFormHandler : IFormHandler<PlantDestroyEditModel>
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public PlantDestroyEditModelFormHandler(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<bool> HandleAsync(PlantDestroyEditModel form)
        {
            try
            {
                var httpClient = _httpClientFactory.CreateClient(NamedHttpClients.PlantDataApi);
                // todo: if not null client
                var httpResponse = await httpClient.DeleteAsync("api/Species/" + form.Id);

                return httpResponse.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}