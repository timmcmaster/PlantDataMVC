using Framework.Web.Core.Forms;
using PlantDataMVC.UICore.Helpers;
using PlantDataMVC.UICore.Models.EditModels.Plant;
using System.Threading;
using System.Threading.Tasks;

namespace PlantDataMVC.UICore.Handlers.Forms.Plant
{
    public class PlantDestroyEditModelFormHandler : IFormHandler<PlantDestroyEditModel, bool>
    {
        private readonly IPlantDataApiClient _plantDataApiClient;

        public PlantDestroyEditModelFormHandler(IPlantDataApiClient plantDataApiClient)
        {
            _plantDataApiClient = plantDataApiClient;
        }

        public async Task<bool> HandleAsync(PlantDestroyEditModel form, CancellationToken cancellationToken)
        {
            try
            {
                var uri = "api/Species/" + form.Id;
                var httpResponse = await _plantDataApiClient.DeleteAsync(uri, cancellationToken).ConfigureAwait(false);

                return httpResponse.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}