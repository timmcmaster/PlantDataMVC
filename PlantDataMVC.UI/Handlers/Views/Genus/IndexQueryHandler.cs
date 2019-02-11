using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Framework.Web.Views;
using Newtonsoft.Json;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.UI.Controllers.Queries.Genus;
using PlantDataMVC.UI.Helpers;
using PlantDataMVC.UI.Models.ViewModels;
using PlantDataMVC.UI.Models.ViewModels.Genus;

namespace PlantDataMVC.UI.Handlers.Views.Genus
{
    public class IndexQueryHandler : IQueryHandler<IndexQuery, ListViewModelStatic<GenusListViewModel>>
    {
        private readonly IMyHttpClientFactory _httpClientFactory;

        public IndexQueryHandler(IMyHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ListViewModelStatic<GenusListViewModel>> HandleAsync(IndexQuery query)
        {
            // Get paging part of query string
            var requestUri = "api/Genus?page=" + query.Page + "&pageSize=" + query.PageSize;

            // add sorting if it maps ok
            if (!String.IsNullOrEmpty(query.SortBy))
            {
                var apiSortField = MapSortField(query.SortBy);
                if (!String.IsNullOrEmpty(apiSortField))
                {
                    var sortString = ApiSorting.CreateSortString(apiSortField, query.SortAscending);
                    requestUri = sortString == "" ? requestUri : requestUri + "&sort=" + sortString;
                }
            }

            HttpClient httpClient = _httpClientFactory.CreateClient(NamedHttpClients.PlantDataApi);
            // todo: if not null client
            var httpResponse = await httpClient.GetAsync(requestUri).ConfigureAwait(false);

            if (httpResponse.IsSuccessStatusCode)
            {
                var content = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

                ApiPagingInfo apiPagingInfo = HeaderParser.FindAndParsePagingInfo(httpResponse.Headers);
                LinkHeader linkInfo = HeaderParser.FindAndParseLinkInfo(httpResponse.Headers);

                var dtoList = JsonConvert.DeserializeObject<IEnumerable<GenusInListDto>>(content);

                // TODO: check to ensure these DTOs map to view model
                List<GenusListViewModel> modelList =
                    Mapper.Map<IEnumerable<GenusInListDto>, List<GenusListViewModel>>(dtoList);

                var model = new ListViewModelStatic<GenusListViewModel>(modelList, apiPagingInfo.page,
                                                                        apiPagingInfo.pageSize,
                                                                        apiPagingInfo.totalCount, 
                                                                        query.SortBy,
                                                                        query.SortAscending);
                return model;
            }

            // TODO: better way needed to handle failure response
            return null;
        }

        /// <summary>
        /// Maps the sort field from display field column to dto field as used by API
        /// </summary>
        /// <param name="querySortBy">The query sort by.</param>
        /// <returns></returns>
        private string MapSortField(string querySortBy)
        {
            var sortField = "";

            // TODO: Got to be a more rigorous way to convert columns back to API fields
            // supplied sortBy field should belong to display object (as it is generated from model metadata)
            if (querySortBy == nameof(GenusListViewModel.Id))
            {
                sortField = nameof(GenusInListDto.Id);
            }
            else if (querySortBy == nameof(GenusListViewModel.LatinName))
            {
                sortField = nameof(GenusInListDto.LatinName);
            }

            return sortField;
        }
    }
}