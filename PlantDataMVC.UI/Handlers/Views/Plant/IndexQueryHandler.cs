using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using AutoMapper;
using Framework.Web.Views;
using Newtonsoft.Json;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.UI.Controllers.Queries.Plant;
using PlantDataMVC.UI.Helpers;
using PlantDataMVC.UI.Models.ViewModels;
using PlantDataMVC.UI.Models.ViewModels.Plant;

namespace PlantDataMVC.UI.Handlers.Views.Plant
{
    public class IndexQueryHandler : IQueryHandler<IndexQuery, ListViewModelStatic<PlantListViewModel>>
    {
        private readonly IMyHttpClientFactory _httpClientFactory;

        public IndexQueryHandler(IMyHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ListViewModelStatic<PlantListViewModel>> HandleAsync(IndexQuery query, CancellationToken cancellationToken)
        {
            // Get paging part of query
            // TODO: really want to sort by genus name and species name (if showing details by plant)
            var requestUri = "api/Species?page=" + query.Page + "&pageSize=" + query.PageSize;

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
            var httpResponse = await httpClient.GetAsync(requestUri, cancellationToken).ConfigureAwait(false);

            if (httpResponse.IsSuccessStatusCode)
            {
                var content = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

                ApiPagingInfo apiPagingInfo = HeaderParser.FindAndParsePagingInfo(httpResponse.Headers);
                LinkHeader linkInfo = HeaderParser.FindAndParseLinkInfo(httpResponse.Headers);

                var dtoList = JsonConvert.DeserializeObject<IEnumerable<SpeciesDto>>(content);
                List<PlantListViewModel> modelList =
                    Mapper.Map<IEnumerable<SpeciesDto>, List<PlantListViewModel>>(dtoList);

                var model = new ListViewModelStatic<PlantListViewModel>(modelList, apiPagingInfo.page,
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
            if (querySortBy == nameof(PlantListViewModel.Id))
            {
                sortField = nameof(SpeciesDto.Id);
            }
            else if (querySortBy == nameof(PlantListViewModel.Binomial))
            {
                sortField = ""; // TODO: solve problem of sort by species binomial
            }
            else if (querySortBy == nameof(PlantListViewModel.CommonName))
            {
                sortField = nameof(SpeciesDto.CommonName);
            }

            return sortField;
        }
    }
}