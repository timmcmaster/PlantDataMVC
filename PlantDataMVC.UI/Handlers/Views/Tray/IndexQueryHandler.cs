using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Framework.Web.Views;
using Newtonsoft.Json;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.UI.Controllers.Queries.Tray;
using PlantDataMVC.UI.Helpers;
using PlantDataMVC.UI.Models.ViewModels;
using PlantDataMVC.UI.Models.ViewModels.Tray;

namespace PlantDataMVC.UI.Handlers.Views.Tray
{
    public class IndexQueryHandler : IQueryHandler<IndexQuery,ListViewModelStatic<TrayListViewModel>>
    {
        private readonly IMyHttpClientFactory _httpClientFactory;

        public IndexQueryHandler(IMyHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ListViewModelStatic<TrayListViewModel>> HandleAsync(IndexQuery query)
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

            var httpClient = _httpClientFactory.CreateClient(NamedHttpClients.PlantDataApi);
            // todo: if not null client
            var httpResponse = await httpClient.GetAsync(requestUri).ConfigureAwait(false);

            if (httpResponse.IsSuccessStatusCode)
            {
                string content = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

                var apiPagingInfo = HeaderParser.FindAndParsePagingInfo(httpResponse.Headers);
                var linkInfo = HeaderParser.FindAndParseLinkInfo(httpResponse.Headers);

                var dtoList = JsonConvert.DeserializeObject<IEnumerable<SeedTrayDto>>(content);

                // TODO: check to ensure these DTOs map to view model
                var modelList = Mapper.Map<IEnumerable<SeedTrayDto>, List<TrayListViewModel>>(dtoList);

                var model = new ListViewModelStatic<TrayListViewModel>(modelList, apiPagingInfo.page,
                                                                        apiPagingInfo.pageSize,
                                                                        apiPagingInfo.totalCount,
                                                                        query.SortBy,
                                                                        query.SortAscending);

                return model;
            }
            else
            {
                // TODO: better way needed to handle failure response
                return null;
            }
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
            if (querySortBy == nameof(TrayListViewModel.Id))
            {
                sortField = nameof(SeedTrayDto.Id);
            }
            else if (querySortBy == nameof(TrayListViewModel.DatePlanted))
            {
                sortField = nameof(SeedTrayDto.DatePlanted);
            }
            else if (querySortBy == nameof(TrayListViewModel.SeedBatchId))
            {
                sortField = nameof(SeedTrayDto.SeedBatchId);
            }
            else if (querySortBy == nameof(TrayListViewModel.ThrownOut))
            {
                sortField = nameof(SeedTrayDto.ThrownOut);
            }
            else if (querySortBy == nameof(TrayListViewModel.Treatment))
            {
                sortField = nameof(SeedTrayDto.Treatment);
            }

            return sortField;
        }
    }
}