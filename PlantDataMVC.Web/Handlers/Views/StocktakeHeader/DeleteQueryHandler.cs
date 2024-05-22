using AutoMapper;
using Framework.Web.Views;
using Newtonsoft.Json;
using PlantDataMVC.Api.Models.DataModels;
using PlantDataMVC.Common.Client;
using PlantDataMVC.Web.Controllers.Queries.StocktakeHeader;
using PlantDataMVC.Web.Models.ViewModels.Genus;
using PlantDataMVC.Web.Models.ViewModels.StocktakeHeader;
using System.Net;
using System;
using System.Threading;
using System.Threading.Tasks;
using PlantDataMVC.Api.Models;

namespace PlantDataMVC.Web.Handlers.Views.StocktakeHeader
{
    public class DeleteQueryHandler : IQueryHandler<DeleteQuery, StocktakeHeaderDeleteViewModel>
    {
        private readonly IPlantDataApiClient _plantDataApiClient;
        private readonly IMapper _mapper;

        public DeleteQueryHandler(IPlantDataApiClient plantDataApiClient, IMapper mapper)
        {
            _plantDataApiClient = plantDataApiClient;
            _mapper = mapper;
        }

        public async Task<StocktakeHeaderDeleteViewModel> Handle(DeleteQuery query, CancellationToken cancellationToken)
        {
            var uri = "api/StocktakeHeader/" + query.Id;
            var response = await _plantDataApiClient.GetAsync<StocktakeDataModel>(uri, cancellationToken).ConfigureAwait(false);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedAccessException();
            }
            else if (response.Success && response.Content != null)
            {
                var model = _mapper.Map<StocktakeDataModel, StocktakeHeaderDeleteViewModel>(response.Content);
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