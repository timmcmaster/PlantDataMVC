using Framework.Web.Forms;
using PlantDataMVC.UI.Helpers;
using PlantDataMVC.UI.Models.EditModels;
using System.Net.Http;
using System.Threading.Tasks;

namespace PlantDataMVC.UI.Forms.Handlers
{
    public class PlantStockDestroyEditModelFormHandler : IFormHandler<PlantStockDestroyEditModel>
    {
        private readonly HttpClient _httpClient;

        public PlantStockDestroyEditModelFormHandler()
        {
            _httpClient = PlantDataApiHttpClient.GetClient();
        }

        public async Task<bool> HandleAsync(PlantStockDestroyEditModel form)
        {
            try
            {
                var httpResponse = await _httpClient.DeleteAsync("api/PlantStock/" + form.Id);

                return httpResponse.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}