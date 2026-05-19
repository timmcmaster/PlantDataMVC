using Framework.Web.Forms;
using PlantData.Web.Blazor.UIModels.EditModels.SeedBatch;
using PlantDataMVC.Common.Client;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace PlantData.Web.Blazor.Features.SeedBatch;

public class SeedBatchDestroyEditModelFormHandler : IFormHandler<SeedBatchDestroyEditModel, bool>
{
    private readonly IPlantDataApiClient _plantDataApiClient;

    public SeedBatchDestroyEditModelFormHandler(IPlantDataApiClient plantDataApiClient)
    {
        _plantDataApiClient = plantDataApiClient;
    }

    public async Task<bool> Handle(SeedBatchDestroyEditModel form, CancellationToken cancellationToken)
    {
        try
        {
            var uri = "api/SeedBatch/" + form.Id;
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