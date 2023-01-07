using AutoMapper;
using Framework.Web.Views;
using Newtonsoft.Json;
using PlantDataMVC.Api.Models.DataModels;
using PlantDataMVC.Common.Client;
using PlantDataMVC.Web.Controllers.Queries.PlantStock;
using PlantDataMVC.Web.Helpers;
using PlantDataMVC.Web.Models.ViewModels.PlantStock;
using System.Net;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PlantDataMVC.Web.Handlers.Views.PlantStock
{
    public class DetailsQueryHandler : IQueryHandler<DetailsQuery, PlantStockDetailsViewModel>
    {
        private readonly IPlantDataApiClient _plantDataApiClient;
        private readonly IMapper _mapper;

        public DetailsQueryHandler(IPlantDataApiClient plantDataApiClient, IMapper mapper)
        {
            _plantDataApiClient = plantDataApiClient;
            _mapper = mapper;
        }

        public async Task<PlantStockDetailsViewModel> Handle(DetailsQuery query, CancellationToken cancellationToken)
        {
            var uri = "api/PlantStock/" + query.Id + "?fields=id,speciesId,productTypeId,quantityInStock,journalEntries";
            var response = await _plantDataApiClient.GetAsync<PlantStockDataModel>(uri, cancellationToken).ConfigureAwait(false);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedAccessException();
            }
            else if (response.Success && response.Content != null)
            {
                var model = _mapper.Map<PlantStockDataModel, PlantStockDetailsViewModel>(response.Content);
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