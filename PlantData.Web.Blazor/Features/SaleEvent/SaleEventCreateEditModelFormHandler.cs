using AutoMapper;
using Framework.Web.Forms;
using PlantData.Web.Blazor.UIModels.EditModels.SaleEvent;
using PlantDataMVC.Api.Models.DataModels;
using PlantDataMVC.Common.Client;
using System.Threading;
using System.Threading.Tasks;

namespace PlantData.Web.Blazor.Features.SaleEvent
{
    public class SaleEventCreateEditModelFormHandler : IFormHandler<SaleEventCreateEditModel, bool>
    {
        private readonly IPlantDataApiClient _plantDataApiClient;
        private readonly IMapper _mapper;

        public SaleEventCreateEditModelFormHandler(IPlantDataApiClient plantDataApiClient, IMapper mapper)
        {
            _plantDataApiClient = plantDataApiClient;
            _mapper = mapper;
        }

        public async Task<bool> Handle(SaleEventCreateEditModel form, CancellationToken cancellationToken)
        {
            try
            {
                // Map local model to DTO
                CreateUpdateSaleEventDataModel item = _mapper.Map<SaleEventCreateEditModel, CreateUpdateSaleEventDataModel>(form);

                var uri = "api/SaleEvent";
                var response = await _plantDataApiClient.PostAsync(uri, item, cancellationToken).ConfigureAwait(false);

                return response.Success;
            }
            catch
            {
                return false;
            }
        }
    }
}