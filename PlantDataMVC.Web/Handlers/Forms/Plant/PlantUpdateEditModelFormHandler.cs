using AutoMapper;
using Framework.Web.Forms;
using Newtonsoft.Json;
using PlantDataMVC.Api.Models.DataModels;
using PlantDataMVC.Common.Client;
using PlantDataMVC.Web.Models.EditModels.Plant;
using System.Net;
using System;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PlantDataMVC.Web.Handlers.Forms.Plant
{
    public class PlantUpdateEditModelFormHandler : IFormHandler<PlantUpdateEditModel, bool>
    {
        private readonly IPlantDataApiClient _plantDataApiClient;
        private readonly IMapper _mapper;

        public PlantUpdateEditModelFormHandler(IPlantDataApiClient plantDataApiClient, IMapper mapper)
        {
            _plantDataApiClient = plantDataApiClient;
            _mapper = mapper;
        }

        public async Task<bool> Handle(PlantUpdateEditModel form, CancellationToken cancellationToken)
        {
            try
            {
                // Map local model to DTO
                CreateUpdateSpeciesDataModel item = _mapper.Map<PlantUpdateEditModel, CreateUpdateSpeciesDataModel>(form);

                // Update with PUT
                var uri = "api/Species/" + form.Id;
                var response = await _plantDataApiClient.PutAsync<CreateUpdateSpeciesDataModel>(uri, item, cancellationToken).ConfigureAwait(false);
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