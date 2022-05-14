using Framework.Web.Core.Forms;
using PlantDataMVC.UICore.Helpers;
using PlantDataMVC.UICore.Models.EditModels.Site;
using System.Threading;
using System.Threading.Tasks;

namespace PlantDataMVC.UICore.Handlers.Forms.Site
{
    public class SiteDestroyEditModelFormHandler : IFormHandler<SiteDestroyEditModel, bool>
    {
        private readonly IPlantDataApiClient _plantDataApiClient;

        public SiteDestroyEditModelFormHandler(IPlantDataApiClient plantDataApiClient)
        {
            _plantDataApiClient = plantDataApiClient;
        }

        public async Task<bool> HandleAsync(SiteDestroyEditModel form, CancellationToken cancellationToken)
        {
            try
            {
                var uri = "api/Site/" + form.Id;
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