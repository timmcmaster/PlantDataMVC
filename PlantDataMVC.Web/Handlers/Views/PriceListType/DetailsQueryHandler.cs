using AutoMapper;
using Framework.Web.Views;
using Newtonsoft.Json;
using PlantDataMVC.Api.Models.DataModels;
using PlantDataMVC.Common.Client;
using PlantDataMVC.Web.Controllers.Queries.PriceListType;
using PlantDataMVC.Web.Helpers;
using PlantDataMVC.Web.Models.ViewModels.PriceListType;
using System.Net;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PlantDataMVC.Web.Handlers.Views.PriceListType
{
    public class DetailsQueryHandler : IQueryHandler<DetailsQuery, PriceListTypeDetailsViewModel>
    {
        private readonly IPlantDataApiClient _plantDataApiClient;
        private readonly IMapper _mapper;

        public DetailsQueryHandler(IPlantDataApiClient plantDataApiClient, IMapper mapper)
        {
            _plantDataApiClient = plantDataApiClient;
            _mapper = mapper;
        }

        public async Task<PriceListTypeDetailsViewModel> Handle(DetailsQuery query, CancellationToken cancellationToken)
        {
            //var uri = "api/PriceListType/" + query.Id + "?fields=id,name,kind,productPrices";
            var uri = $"api/PriceListType/{query.Id}";
            var response = await _plantDataApiClient.GetAsync<PriceListTypeDataModel>(uri, cancellationToken).ConfigureAwait(false);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedAccessException();
            }
            else if (response.Success && response.Content != null)
            {
                var model = _mapper.Map<PriceListTypeDataModel, PriceListTypeDetailsViewModel>(response.Content);
                return model;
            }
            else
            {
                // TODO: better way needed to handle failure response
                return null;
            }
        }
    }
}