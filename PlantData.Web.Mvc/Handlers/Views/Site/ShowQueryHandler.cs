using AutoMapper;
using Framework.Web.Views;
using PlantData.Web.Mvc.Controllers.Queries.Site;
using PlantData.Web.Mvc.Models.ViewModels.Site;
using PlantDataMVC.Api.Models.DataModels;
using PlantDataMVC.Common.Client;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace PlantData.Web.Mvc.Handlers.Views.Site
{
    public class ShowQueryHandler : IQueryHandler<ShowQuery, SiteShowViewModel>
    {
        private readonly IPlantDataApiClient _plantDataApiClient;
        private readonly IMapper _mapper;

        public ShowQueryHandler(IPlantDataApiClient plantDataApiClient, IMapper mapper)
        {
            _plantDataApiClient = plantDataApiClient;
            _mapper = mapper;
        }

        public async Task<SiteShowViewModel> Handle(ShowQuery query, CancellationToken cancellationToken)
        {
            var uri = "api/Site/" + query.Id;
            var response = await _plantDataApiClient.GetAsync<SiteDataModel>(uri, cancellationToken).ConfigureAwait(false);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedAccessException();
            }
            else if (response.Success && response.Content != null)
            {
                var model = _mapper.Map<SiteDataModel, SiteShowViewModel>(response.Content);
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