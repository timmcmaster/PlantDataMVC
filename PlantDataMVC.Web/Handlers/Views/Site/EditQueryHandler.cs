﻿using AutoMapper;
using Framework.Web.Views;
using Newtonsoft.Json;
using PlantDataMVC.Api.Models.DataModels;
using PlantDataMVC.UICore.Controllers.Queries.Site;
using PlantDataMVC.UICore.Helpers;
using PlantDataMVC.UICore.Models.ViewModels.Site;
using System.Threading;
using System.Threading.Tasks;

namespace PlantDataMVC.UICore.Handlers.Views.Site
{
    public class EditQueryHandler : IQueryHandler<EditQuery, SiteEditViewModel>
    {
        private readonly IPlantDataApiClient _plantDataApiClient;
        private readonly IMapper _mapper;

        public EditQueryHandler(IPlantDataApiClient plantDataApiClient, IMapper mapper)
        {
            _plantDataApiClient = plantDataApiClient;
            _mapper = mapper;
        }

        public async Task<SiteEditViewModel> Handle(EditQuery query, CancellationToken cancellationToken)
        {
            var uri = "api/Site/" + query.Id;
            var httpResponse = await _plantDataApiClient.GetAsync(uri, cancellationToken).ConfigureAwait(false);

            if (httpResponse.IsSuccessStatusCode)
            {
                string content = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                var dto = JsonConvert.DeserializeObject<SiteDataModel>(content);

                var model = _mapper.Map<SiteDataModel, SiteEditViewModel>(dto);
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