using System.Net.Http;
using System.Threading.Tasks;
using Framework.Web.Forms;
using PlantDataMVC.UI.Helpers;
using PlantDataMVC.UI.Models.EditModels;

namespace PlantDataMVC.UI.Handlers.Forms
{
    public class PlantStockDestroyEditModelFormHandler : IFormHandler<PlantStockDestroyEditModel>
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public PlantStockDestroyEditModelFormHandler(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<bool> HandleAsync(PlantStockDestroyEditModel form)
        {
            try
            {
                var httpClient = _httpClientFactory.CreateClient(NamedHttpClients.PlantDataApi);
                // todo: if not null client
                var httpResponse = await httpClient.DeleteAsync("api/PlantStock/" + form.Id);

                return httpResponse.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}