using Framework.Web.Core.Forms;
using Newtonsoft.Json;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.UICore.Helpers;
using PlantDataMVC.UICore.Models.EditModels.PlantStock;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PlantDataMVC.UICore.Handlers.Forms.PlantStock
{
    public class PlantStockUpdateEditModelFormHandler : IFormHandler<PlantStockUpdateEditModel, bool>
    {
        private readonly IPlantDataApiClient _plantDataApiClient;

        public PlantStockUpdateEditModelFormHandler(IPlantDataApiClient plantDataApiClient)
        {
            _plantDataApiClient = plantDataApiClient;
        }

        public async Task<bool> HandleAsync(PlantStockUpdateEditModel form, CancellationToken cancellationToken)
        {
            try
            {
                // Map local model to DTO
                PlantStockDto item = AutoMapper.Mapper.Map<PlantStockUpdateEditModel, PlantStockDto>(form);

                // Update with PUT
                var serializedItem = JsonConvert.SerializeObject(item);
                var content = new StringContent(serializedItem, Encoding.Unicode, "application/json");

                var uri = "api/PlantStock/" + form.Id;
                var httpResponse = await _plantDataApiClient.PutAsync(uri, content, cancellationToken).ConfigureAwait(false);

                return httpResponse.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}