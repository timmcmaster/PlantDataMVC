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
using Microsoft.Extensions.Configuration;

namespace PlantDataMVC.Web.Handlers.Views.PriceListType
{
    public class DetailsQueryHandler : IQueryHandler<DetailsQuery, PriceListTypeDetailsViewModel>
    {
        private readonly IPlantDataApiClient _plantDataApiClient;
        private readonly IMapper _mapper;
        private readonly bool _useBasicMvcViews = false;

        public DetailsQueryHandler(IPlantDataApiClient plantDataApiClient, IMapper mapper, IConfiguration configuration)
        {
            _plantDataApiClient = plantDataApiClient;
            _mapper = mapper;
            _useBasicMvcViews = Convert.ToBoolean(configuration["WebUI:UseBasicMvcViews"]);
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
                model.ShowAddItem = _useBasicMvcViews;
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