﻿using AutoMapper;
using Framework.Web.Core.Views;
using Newtonsoft.Json;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.UICore.Controllers.Queries.Site;
using PlantDataMVC.UICore.Helpers;
using PlantDataMVC.UICore.Models.ViewModels.Site;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace PlantDataMVC.UICore.Handlers.Views.Site
{
    public class DeleteQueryHandler : IQueryHandler<DeleteQuery, SiteDeleteViewModel>
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DeleteQueryHandler(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<SiteDeleteViewModel> HandleAsync(DeleteQuery query, CancellationToken cancellationToken)
        {
            var httpClient = _httpClientFactory.CreateClient(NamedHttpClients.PlantDataApi);
            var uri = "api/Site/" + query.Id;
            var httpResponse = await httpClient.GetAsync(uri, cancellationToken).ConfigureAwait(false);

            if (httpResponse.IsSuccessStatusCode)
            {
                string content = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                var dto = JsonConvert.DeserializeObject<SiteDto>(content);

                var model = Mapper.Map<SiteDto, SiteDeleteViewModel>(dto);
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