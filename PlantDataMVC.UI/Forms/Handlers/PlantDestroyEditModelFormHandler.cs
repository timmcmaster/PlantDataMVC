using System.Net.Http;
using Framework.Web.Forms;
using PlantDataMVC.UI.Helpers;
using PlantDataMVC.UI.Models.EditModels;
using System.Threading.Tasks;

namespace PlantDataMVC.UI.Forms.Handlers
{
    public class PlantDestroyEditModelFormHandler : IFormHandler<PlantDestroyEditModel>
    {
        private readonly HttpClient _httpClient;

        public PlantDestroyEditModelFormHandler()
        {
            _httpClient = PlantDataApiHttpClient.GetClient();
        }

        public async Task<bool> HandleAsync(PlantDestroyEditModel form)
        {
            try
            {
                var httpResponse = await _httpClient.DeleteAsync("api/Species/" + form.Id);

                return httpResponse.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}