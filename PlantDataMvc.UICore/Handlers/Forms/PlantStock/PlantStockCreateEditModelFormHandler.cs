using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Framework.Web.Core.Forms;
using Newtonsoft.Json;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.UICore.Helpers;
using PlantDataMVC.UICore.Models.EditModels.PlantStock;

namespace PlantDataMVC.UICore.Handlers.Forms.PlantStock
{
    public class PlantStockCreateEditModelFormHandler : IFormHandler<PlantStockCreateEditModel, bool>
    {
        private readonly IPlantDataApiClient _plantDataApiClient;

        public PlantStockCreateEditModelFormHandler(IPlantDataApiClient plantDataApiClient)
        {
            _plantDataApiClient = plantDataApiClient;
        }

        public async Task<bool> HandleAsync(PlantStockCreateEditModel form, CancellationToken cancellationToken)
        {
            try
            {
                // Map local model to DTO
                PlantStockDto item = AutoMapper.Mapper.Map<PlantStockCreateEditModel, PlantStockDto>(form);
                var serializedItem = JsonConvert.SerializeObject(item);
                var content = new StringContent(serializedItem, Encoding.Unicode, "application/json");

                var uri = "api/PlantStock";
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