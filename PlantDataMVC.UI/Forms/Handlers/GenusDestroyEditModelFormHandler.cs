using System.Net.Http;
using Framework.Web.Forms;
using PlantDataMVC.UI.Helpers;
using PlantDataMVC.UI.Models.EditModels;
using System.Threading.Tasks;

namespace PlantDataMVC.UI.Forms.Handlers
{
    public class GenusDestroyEditModelFormHandler : IFormHandler<GenusDestroyEditModel>
    {
        private readonly HttpClient _httpClient;

        public GenusDestroyEditModelFormHandler()
        {
            _httpClient = MyHttpClient.GetClient();
        }

        public async Task<bool> HandleAsync(GenusDestroyEditModel form)
        {
            try
            {
                var httpResponse = await _httpClient.DeleteAsync("api/Genus/" + form.Id);

                return httpResponse.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}