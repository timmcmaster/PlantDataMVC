using AutoMapper;
using Framework.Web.Forms;
using PlantData.Web.Blazor.UIModels.EditModels.Genus;
using PlantDataMVC.Api.Models.DataModels;
using PlantDataMVC.Common.Client;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace PlantData.Web.Blazor.Features.Genus;

public class GenusUpdateEditModelFormHandler : IFormHandler<GenusUpdateEditModel, bool>
{
    private readonly IPlantDataApiClient _plantDataApiClient;
    private readonly IMapper _mapper;

    public GenusUpdateEditModelFormHandler(IPlantDataApiClient plantDataApiClient, IMapper mapper)
    {
        _plantDataApiClient = plantDataApiClient;
        _mapper = mapper;
    }

    public async Task<bool> Handle(GenusUpdateEditModel form, CancellationToken cancellationToken)
    {
        try
        {
            // Map local model to DTO
            CreateUpdateGenusDataModel item = _mapper.Map<GenusUpdateEditModel, CreateUpdateGenusDataModel>(form);

            // Update with PUT
            var uri = "api/Genus/" + form.Id;
            var response = await _plantDataApiClient.PutAsync(uri, item, cancellationToken).ConfigureAwait(false);
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