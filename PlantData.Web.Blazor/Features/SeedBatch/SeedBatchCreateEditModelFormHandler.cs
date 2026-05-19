using AutoMapper;
using Framework.Web.Forms;
using PlantData.Web.Blazor.UIModels.EditModels.SeedBatch;
using PlantDataMVC.Api.Models.DataModels;
using PlantDataMVC.Common.Client;
using System.Threading;
using System.Threading.Tasks;

namespace PlantData.Web.Blazor.Features.SeedBatch;

public class SeedBatchCreateEditModelFormHandler : IFormHandler<SeedBatchCreateEditModel, bool>
{
    private readonly IPlantDataApiClient _plantDataApiClient;
    private readonly IMapper _mapper;

    public SeedBatchCreateEditModelFormHandler(IPlantDataApiClient plantDataApiClient, IMapper mapper)
    {
        _plantDataApiClient = plantDataApiClient;
        _mapper = mapper;
    }

    public async Task<bool> Handle(SeedBatchCreateEditModel form, CancellationToken cancellationToken)
    {
        try
        {
            // Map local model to DTO
            CreateUpdateSeedBatchDataModel item = _mapper.Map<SeedBatchCreateEditModel, CreateUpdateSeedBatchDataModel>(form);

            var uri = "api/SeedBatch";
            var response = await _plantDataApiClient.PostAsync(uri, item, cancellationToken).ConfigureAwait(false);

            return response.Success;
        }
        catch
        {
            return false;
        }
    }
}