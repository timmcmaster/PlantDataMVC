﻿using System.Threading.Tasks;
using AutoMapper;
using Framework.Web.Views;
using Newtonsoft.Json;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.UI.Controllers.Queries;
using PlantDataMVC.UI.Helpers;
using PlantDataMVC.UI.Models.ViewModels;

namespace PlantDataMVC.UI.Handlers.Views
{
    public class TrayEditViewModelHandler : IViewHandler<TrayEditViewModel, ShowQuery>
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TrayEditViewModelHandler(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<TrayEditViewModel> HandleAsync(ShowQuery query)
        {
            var httpClient = _httpClientFactory.CreateClient(NamedHttpClients.PlantDataApi);
            // todo: if not null client
            var httpResponse = await httpClient.GetAsync("api/SeedTray/" + query.Id);

            if (httpResponse.IsSuccessStatusCode)
            {
                string content = await httpResponse.Content.ReadAsStringAsync();
                var dto = JsonConvert.DeserializeObject<SeedTrayDto>(content);

                var model = Mapper.Map<SeedTrayDto, TrayEditViewModel>(dto);
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