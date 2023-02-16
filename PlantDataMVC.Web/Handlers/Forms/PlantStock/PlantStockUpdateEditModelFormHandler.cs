using AutoMapper;
using Framework.Web.Forms;
using Newtonsoft.Json;
using PlantDataMVC.Api.Models.DataModels;
using PlantDataMVC.Common.Client;
using PlantDataMVC.Web.Models.EditModels.PlantStock;
using System.Net;
using System;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PlantDataMVC.Web.Handlers.Forms.PlantStock
{
    public class PlantStockUpdateEditModelFormHandler : IFormHandler<PlantStockUpdateEditModel, bool>
    {
        private readonly IPlantDataApiClient _plantDataApiClient;
        private readonly IMapper _mapper;

        public PlantStockUpdateEditModelFormHandler(IPlantDataApiClient plantDataApiClient, IMapper mapper)
        {
            _plantDataApiClient = plantDataApiClient;
            _mapper = mapper;
        }

        public async Task<bool> Handle(PlantStockUpdateEditModel form, CancellationToken cancellationToken)
        {
            try
            {
                // Map local model to DTO
                CreateUpdatePlantStockDataModel item = _mapper.Map<PlantStockUpdateEditModel, CreateUpdatePlantStockDataModel>(form);

                // Update with PUT
                var uri = "api/PlantStock/" + form.Id;
                var response = await _plantDataApiClient.PutAsync<CreateUpdatePlantStockDataModel>(uri, item, cancellationToken).ConfigureAwait(false);
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