using AutoMapper;
using Azure;
using Framework.Web.Forms;
using PlantDataMVC.Common.Client;
using PlantDataMVC.Web.Models.EditModels.Genus;
using System.Net;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PlantDataMVC.Web.Handlers.Forms.Genus
{
    public class GenusDestroyEditModelFormHandler : IFormHandler<GenusDestroyEditModel, bool>
    {
        private readonly IPlantDataApiClient _plantDataApiClient;
        private readonly IMapper _mapper;

        public GenusDestroyEditModelFormHandler(IPlantDataApiClient plantDataApiClient, IMapper mapper)
        {
            _plantDataApiClient = plantDataApiClient;
        }

        public async Task<bool> Handle(GenusDestroyEditModel form, CancellationToken cancellationToken)
        {
            try
            {
                var uri = "api/Genus/" + form.Id;
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