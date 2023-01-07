using AutoMapper;
using Framework.Web.Forms;
using PlantDataMVC.Common.Client;
using PlantDataMVC.Web.Models.EditModels.Plant;
using System.Net;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PlantDataMVC.Web.Handlers.Forms.Plant
{
    public class PlantDestroyEditModelFormHandler : IFormHandler<PlantDestroyEditModel, bool>
    {
        private readonly IPlantDataApiClient _plantDataApiClient;
        private readonly IMapper _mapper;

        public PlantDestroyEditModelFormHandler(IPlantDataApiClient plantDataApiClient, IMapper mapper)
        {
            _plantDataApiClient = plantDataApiClient;
            _mapper = mapper;
        }

        public async Task<bool> Handle(PlantDestroyEditModel form, CancellationToken cancellationToken)
        {
            try
            {
                var uri = "api/Species/" + form.Id;
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