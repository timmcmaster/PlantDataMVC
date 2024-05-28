using AutoMapper;
using Framework.Web.Forms;
using Newtonsoft.Json;
using PlantDataMVC.Api.Models.DataModels;
using PlantDataMVC.Common.Client;
using System.Net;
using System;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using PlantData.Web.Mvc.Models.EditModels.SaleEvent;

namespace PlantData.Web.Mvc.Handlers.Forms.SaleEvent
{
    public class SaleEventUpdateEditModelFormHandler : IFormHandler<SaleEventUpdateEditModel, bool>
    {
        private readonly IPlantDataApiClient _plantDataApiClient;
        private readonly IMapper _mapper;

        public SaleEventUpdateEditModelFormHandler(IPlantDataApiClient plantDataApiClient, IMapper mapper)
        {
            _plantDataApiClient = plantDataApiClient;
            _mapper = mapper;
        }

        public async Task<bool> Handle(SaleEventUpdateEditModel form, CancellationToken cancellationToken)
        {
            try
            {
                // Map local model to DTO
                CreateUpdateSaleEventDataModel item = _mapper.Map<SaleEventUpdateEditModel, CreateUpdateSaleEventDataModel>(form);

                // Update with PUT
                var uri = "api/SaleEvent/" + form.Id;
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
}