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
    public class PlantShowViewModelHandler : IViewHandler<PlantShowQuery, PlantShowViewModel>
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public PlantShowViewModelHandler(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<PlantShowViewModel> HandleAsync(PlantShowQuery query)
        {
            var httpClient = _httpClientFactory.CreateClient(NamedHttpClients.PlantDataApi);
            var httpResponse = await httpClient.GetAsync("api/Species/" + query.Id);

            if (httpResponse.IsSuccessStatusCode)
            {
                string content = await httpResponse.Content.ReadAsStringAsync();
                var dto = JsonConvert.DeserializeObject<SpeciesDto>(content);

                var model = Mapper.Map<SpeciesDto, PlantShowViewModel>(dto);
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