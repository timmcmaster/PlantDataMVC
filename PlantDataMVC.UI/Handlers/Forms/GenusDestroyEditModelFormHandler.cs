using System.Net.Http;
using System.Threading.Tasks;
using Framework.Web.Forms;
using PlantDataMVC.UI.Helpers;
using PlantDataMVC.UI.Models.EditModels;

namespace PlantDataMVC.UI.Handlers.Forms
{
    public class GenusDestroyEditModelFormHandler : IFormHandler<GenusDestroyEditModel>
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public GenusDestroyEditModelFormHandler(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<bool> HandleAsync(GenusDestroyEditModel form)
        {
            try
            {
                var httpClient = _httpClientFactory.CreateClient(NamedHttpClients.PlantDataApi);
                // todo: if not null client
                var httpResponse = await httpClient.DeleteAsync("api/Genus/" + form.Id);

                return httpResponse.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}