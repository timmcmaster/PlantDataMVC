using AutoMapper;
using Framework.Web.Forms;
using Newtonsoft.Json;
using PlantDataMVC.Api.Models.DataModels;
using PlantDataMVC.Common.Client;
using PlantDataMVC.Web.Models.EditModels.SeedTray;
using System.Net;
using System;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PlantDataMVC.Web.Handlers.Forms.SeedTray
{
    public class SeedTrayUpdateEditModelFormHandler : IFormHandler<SeedTrayUpdateEditModel, bool>
    {
        private readonly IPlantDataApiClient _plantDataApiClient;
        private readonly IMapper _mapper;

        public SeedTrayUpdateEditModelFormHandler(IPlantDataApiClient plantDataApiClient, IMapper mapper)
        {
            _plantDataApiClient = plantDataApiClient;
            _mapper = mapper;
        }

        public async Task<bool> Handle(SeedTrayUpdateEditModel form, CancellationToken cancellationToken)
        {
            try
            {
                // Map local model to DTO
                CreateUpdateSeedTrayDataModel item = _mapper.Map<SeedTrayUpdateEditModel, CreateUpdateSeedTrayDataModel>(form);

                // Update with PUT
                var uri = "api/SeedTray/" + form.Id;
                var response = await _plantDataApiClient.PutAsync<CreateUpdateSeedTrayDataModel>(uri, item, cancellationToken).ConfigureAwait(false);
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