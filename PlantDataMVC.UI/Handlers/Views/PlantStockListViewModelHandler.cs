﻿using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Framework.Web.Views;
using Newtonsoft.Json;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.UI.Controllers.Queries;
using PlantDataMVC.UI.Helpers;
using PlantDataMVC.UI.Models.ViewModels;

namespace PlantDataMVC.UI.Handlers.Views
{
    public class PlantStockListViewModelHandler : IViewHandler<ListViewModelStatic<PlantStockListViewModel>,IndexQuery>
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public PlantStockListViewModelHandler(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ListViewModelStatic<PlantStockListViewModel>> HandleAsync(IndexQuery query)
        {
            var httpClient = _httpClientFactory.CreateClient(NamedHttpClients.PlantDataApi);
            // todo: if not null client
            // Initialise with default sort
            // TODO: really want to sort by genus name and species name (if showing details by plant)
            var httpResponse = await httpClient.GetAsync("api/PlantStock?page=" + query.Page + "&pageSize=" + query.PageSize);

            if (httpResponse.IsSuccessStatusCode)
            {
                string content = await httpResponse.Content.ReadAsStringAsync();

                var apiPagingInfo = HeaderParser.FindAndParsePagingInfo(httpResponse.Headers);
                var linkInfo = HeaderParser.FindAndParseLinkInfo(httpResponse.Headers);

                var dtoList = JsonConvert.DeserializeObject<IEnumerable<PlantStockDto>>(content);

                // TODO: check to ensure these DTOs map to view model
                var modelList = Mapper.Map<IEnumerable<PlantStockDto>, List<PlantStockListViewModel>>(dtoList);

                var model = new ListViewModelStatic<PlantStockListViewModel>(modelList, apiPagingInfo.page, apiPagingInfo.pageSize, apiPagingInfo.totalCount);

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