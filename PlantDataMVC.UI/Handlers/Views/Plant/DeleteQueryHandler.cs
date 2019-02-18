﻿using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using AutoMapper;
using Framework.Web.Views;
using Newtonsoft.Json;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.UI.Controllers.Queries.Plant;
using PlantDataMVC.UI.Helpers;
using PlantDataMVC.UI.Models.ViewModels.Plant;

namespace PlantDataMVC.UI.Handlers.Views.Plant
{
    public class DeleteQueryHandler : IQueryHandler<DeleteQuery, PlantDeleteViewModel>
    {
        private readonly IMyHttpClientFactory _httpClientFactory;

        public DeleteQueryHandler(IMyHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<PlantDeleteViewModel> HandleAsync(DeleteQuery query, CancellationToken cancellationToken)
        {
            var token = (HttpContext.Current.User.Identity as ClaimsIdentity).FindFirst("access_token");
            var httpClient = _httpClientFactory.CreateClient(NamedHttpClients.PlantDataApi);
            // todo: if not null client
            var uri = "api/Species/" + query.Id;
            var httpResponse = await httpClient.GetAsync(uri, token.Value, cancellationToken).ConfigureAwait(false);

            //var httpResponse = await httpClient.GetAsync(uri).ConfigureAwait(false);

            if (httpResponse.IsSuccessStatusCode)
            {
                string content = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                var dto = JsonConvert.DeserializeObject<SpeciesDto>(content);

                var model = Mapper.Map<SpeciesDto, PlantDeleteViewModel>(dto);
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