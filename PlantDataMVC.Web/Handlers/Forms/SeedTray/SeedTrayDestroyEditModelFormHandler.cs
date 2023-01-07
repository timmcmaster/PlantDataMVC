using Framework.Web.Forms;
using PlantDataMVC.Common.Client;
using PlantDataMVC.Web.Models.EditModels.SeedTray;
using System.Net;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PlantDataMVC.Web.Handlers.Forms.SeedTray
{
    public class SeedTrayDestroyEditModelFormHandler : IFormHandler<SeedTrayDestroyEditModel, bool>
    {
        private readonly IPlantDataApiClient _plantDataApiClient;

        public SeedTrayDestroyEditModelFormHandler(IPlantDataApiClient plantDataApiClient)
        {
            _plantDataApiClient = plantDataApiClient;
        }

        public async Task<bool> Handle(SeedTrayDestroyEditModel form, CancellationToken cancellationToken)
        {
            try
            {
                var uri = "api/SeedTray/" + form.Id;
                var response = await _plantDataApiClient.DeleteAsync(uri, cancellationToken).ConfigureAwait(false);
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new UnauthorizedAccessException();
                }
                else
                {
                    return response.Success;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}