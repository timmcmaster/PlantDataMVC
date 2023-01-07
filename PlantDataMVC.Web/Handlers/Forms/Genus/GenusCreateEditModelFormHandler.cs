using AutoMapper;
using Framework.Web.Forms;
using Newtonsoft.Json;
using PlantDataMVC.Api.Models.DataModels;
using PlantDataMVC.Common.Client;
using PlantDataMVC.Web.Models.EditModels.Genus;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PlantDataMVC.Web.Handlers.Forms.Genus
{
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
                var response = await _plantDataApiClient.PostAsync<CreateUpdateGenusDataModel>(uri, item, cancellationToken).ConfigureAwait(false);

                return response.Success;
            }
            catch
            {
                return false;
            }
        }

    }
}