using AutoMapper;
using Framework.Web.Views;
using Newtonsoft.Json;
using PlantDataMVC.Api.Models.DataModels;
using PlantDataMVC.Common.Client;
using PlantData.Web.Mvc.Helpers;
using PlantData.Web.Mvc.Models.ViewModels.Genus;
using System.Net;
using System;
using System.Threading;
using System.Threading.Tasks;
using PlantDataMVC.Api.Models;
using PlantData.Web.Mvc.Controllers.Queries.Plant;
using PlantData.Web.Mvc.Models.ViewModels.Plant;

namespace PlantData.Web.Mvc.Handlers.Views.Plant
{
    public class EditQueryHandler : IQueryHandler<EditQuery, PlantEditViewModel>
    {
        private readonly IPlantDataApiClient _plantDataApiClient;
        private readonly IMapper _mapper;

        public EditQueryHandler(IPlantDataApiClient plantDataApiClient, IMapper mapper)
        {
            _plantDataApiClient = plantDataApiClient;
            _mapper = mapper;
        }

        public async Task<PlantEditViewModel> Handle(EditQuery query, CancellationToken cancellationToken)
        {
            var uri = "api/Species/" + query.Id;
            var response = await _plantDataApiClient.GetAsync<SpeciesDataModel>(uri, cancellationToken).ConfigureAwait(false);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedAccessException();
            }
            else if (response.Success && response.Content != null)
            {
                var model = _mapper.Map<SpeciesDataModel, PlantEditViewModel>(response.Content);
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