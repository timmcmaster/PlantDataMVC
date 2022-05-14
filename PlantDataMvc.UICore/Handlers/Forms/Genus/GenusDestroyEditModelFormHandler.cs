using Framework.Web.Core.Forms;
using PlantDataMVC.UICore.Helpers;
using PlantDataMVC.UICore.Models.EditModels.Genus;
using System.Threading;
using System.Threading.Tasks;

namespace PlantDataMVC.UICore.Handlers.Forms.Genus
{
    public class GenusDestroyEditModelFormHandler : IFormHandler<GenusDestroyEditModel, bool>
    {
        private readonly IPlantDataApiClient _plantDataApiClient;

        public GenusDestroyEditModelFormHandler(IPlantDataApiClient plantDataApiClient)
        {
            _plantDataApiClient = plantDataApiClient;
        }

        public async Task<bool> HandleAsync(GenusDestroyEditModel form, CancellationToken cancellationToken)
        {
            try
            {
                var uri = "api/Genus/" + form.Id;
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