using Framework.Web.Core.Forms;
using Newtonsoft.Json;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.UICore.Helpers;
using PlantDataMVC.UICore.Models.EditModels.Site;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PlantDataMVC.UICore.Handlers.Forms.Site
{
    public class SiteCreateEditModelFormHandler : IFormHandler<SiteCreateEditModel, bool>
    {
        private readonly IPlantDataApiClient _plantDataApiClient;

        public SiteCreateEditModelFormHandler(IPlantDataApiClient plantDataApiClient)
        {
            _plantDataApiClient = plantDataApiClient;
        }

        public async Task<bool> HandleAsync(SiteCreateEditModel form, CancellationToken cancellationToken)
        {
            try
            {
                // Map local model to DTO
                SiteDto item = AutoMapper.Mapper.Map<SiteCreateEditModel, SiteDto>(form);
                var serializedItem = JsonConvert.SerializeObject(item);
                var content = new StringContent(serializedItem, Encoding.Unicode, "application/json");

                var uri = "api/Site";
                var httpResponse = await _plantDataApiClient.PostAsync(uri, content, cancellationToken).ConfigureAwait(false);

                return httpResponse.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}