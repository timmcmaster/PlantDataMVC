using AutoMapper;
using Framework.Web.Views;
using Newtonsoft.Json;
using PlantDataMVC.Api.Models.DataModels;
using PlantDataMVC.Common.Client;
using PlantData.Web.Mvc.Helpers;
using System.Net;
using System;
using System.Threading;
using System.Threading.Tasks;
using PlantData.Web.Mvc.Controllers.Queries.Genus;
using PlantData.Web.Mvc.Models.ViewModels.Genus;

namespace PlantData.Web.Mvc.Handlers.Views.Genus
{
    public class EditQueryHandler : IQueryHandler<EditQuery, GenusEditViewModel>
    {
        private readonly IPlantDataApiClient _plantDataApiClient;
        private readonly IMapper _mapper;

        public EditQueryHandler(IPlantDataApiClient plantDataApiClient, IMapper mapper)
        {
            _plantDataApiClient = plantDataApiClient;
            _mapper = mapper;
        }

        public async Task<GenusEditViewModel> Handle(EditQuery query, CancellationToken cancellationToken)
        {
            var uri = "api/Genus/" + query.Id;
            var response = await _plantDataApiClient.GetAsync<GenusDataModel>(uri, cancellationToken).ConfigureAwait(false);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedAccessException();
            }
            else if (response.Success && response.Content != null)
            {
                var model = _mapper.Map<GenusDataModel, GenusEditViewModel>(response.Content);
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