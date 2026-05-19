using AutoMapper;
using Framework.Web.Forms;
using PlantData.Web.Blazor.UIModels.EditModels.Genus;
using PlantDataMVC.Api.Models.DataModels;
using PlantDataMVC.Common.Client;
using System.Threading;
using System.Threading.Tasks;

namespace PlantData.Web.Blazor.Features.Genus;

public class GenusCreateEditModelFormHandler : IFormHandler<GenusCreateEditModel, bool>
{
    private readonly IPlantDataApiClient _plantDataApiClient;
    private readonly IMapper _mapper;

    public GenusCreateEditModelFormHandler(IPlantDataApiClient plantDataApiClient, IMapper mapper)
    {
        _plantDataApiClient = plantDataApiClient;
        _mapper = mapper;
    }

    public async Task<bool> Handle(GenusCreateEditModel form, CancellationToken cancellationToken)
    {
        try
        {
            // Map local model to dataModel
            CreateUpdateGenusDataModel item = _mapper.Map<GenusCreateEditModel, CreateUpdateGenusDataModel>(form);

            var uri = "api/Genus";
            var response = await _plantDataApiClient.PostAsync(uri, item, cancellationToken).ConfigureAwait(false);

            return response.Success;
        }
        catch
        {
            return false;
        }
    }

}