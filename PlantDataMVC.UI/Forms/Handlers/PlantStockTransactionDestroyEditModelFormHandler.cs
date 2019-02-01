using Framework.Web.Forms;
using PlantDataMVC.UI.Helpers;
using PlantDataMVC.UI.Models.EditModels;
using System.Net.Http;
using System.Threading.Tasks;

namespace PlantDataMVC.UI.Forms.Handlers
{
    public class PlantStockTransactionDestroyEditModelFormHandler : IFormHandler<PlantStockTransactionDestroyEditModel>
    {
        private readonly HttpClient _httpClient;

        public PlantStockTransactionDestroyEditModelFormHandler()
        {
            _httpClient = PlantDataApiHttpClient.GetClient();
        }

        public async Task<bool> HandleAsync(PlantStockTransactionDestroyEditModel form)
        {
            try
            {
                var httpResponse = await _httpClient.DeleteAsync("api/JournalEntries/" + form.Id);

                return httpResponse.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}