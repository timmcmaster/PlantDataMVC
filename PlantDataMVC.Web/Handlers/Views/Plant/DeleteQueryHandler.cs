using AutoMapper;
using Framework.Web.Views;
using Newtonsoft.Json;
using PlantDataMVC.Api.Models.DataModels;
using PlantDataMVC.Common.Client;
using PlantDataMVC.Web.Controllers.Queries.Plant;
using PlantDataMVC.Web.Models.ViewModels.Genus;
using PlantDataMVC.Web.Models.ViewModels.Plant;
using System.Net;
using System;
using System.Threading;
using System.Threading.Tasks;
using PlantDataMVC.Api.Models;

namespace PlantDataMVC.Web.Handlers.Views.Plant
{
    public class DeleteQueryHandler : IQueryHandler<DeleteQuery, PlantDeleteViewModel>
    {
        private readonly IPlantDataApiClient _plantDataApiClient;
        private readonly IMapper _mapper;

        public DeleteQueryHandler(IPlantDataApiClient plantDataApiClient, IMapper mapper)
        {
            _plantDataApiClient = plantDataApiClient;
            _mapper = mapper;
        }

        public async Task<PlantDeleteViewModel> Handle(DeleteQuery query, CancellationToken cancellationToken)
        {
            var uri = "api/Species/" + query.Id;
            var response = await _plantDataApiClient.GetAsync<SpeciesDataModel>(uri, cancellationToken).ConfigureAwait(false);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedAccessException();
            }
            else if (response.Success && response.Content != null)
            {
                var model = _mapper.Map<SpeciesDataModel, PlantDeleteViewModel>(response.Content);
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