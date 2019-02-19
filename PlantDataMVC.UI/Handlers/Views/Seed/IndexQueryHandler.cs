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
using PlantDataMVC.UI.Controllers.Queries.Seed;
using PlantDataMVC.UI.Helpers;
using PlantDataMVC.UI.Models.ViewModels;
using PlantDataMVC.UI.Models.ViewModels.Seed;

namespace PlantDataMVC.UI.Handlers.Views.Seed
{
    public class IndexQueryHandler : IQueryHandler<IndexQuery, ListViewModelStatic<PlantSeedListViewModel>>
    {
        private readonly IMyHttpClientFactory _httpClientFactory;

        public IndexQueryHandler(IMyHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ListViewModelStatic<PlantSeedListViewModel>> HandleAsync(IndexQuery query, CancellationToken cancellationToken)
        {
            var token = (HttpContext.Current.User.Identity as ClaimsIdentity).FindFirst("access_token");

            // Get paging part of query
            var requestUri = "api/SeedBatch?page=" + query.Page + "&pageSize=" + query.PageSize;

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
            var httpResponse = await httpClient.GetAsync(requestUri, cancellationToken).ConfigureAwait(false);
            //var httpResponse = await httpClient.GetAsync(requestUri).ConfigureAwait(false);

            if (httpResponse.IsSuccessStatusCode)
            {
                var content = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

                ApiPagingInfo apiPagingInfo = HeaderParser.FindAndParsePagingInfo(httpResponse.Headers);
                LinkHeader linkInfo = HeaderParser.FindAndParseLinkInfo(httpResponse.Headers);

                var dtoList = JsonConvert.DeserializeObject<IEnumerable<SeedBatchDto>>(content);

                // TODO: check to ensure these DTOs map to view model
                List<PlantSeedListViewModel> modelList =
                    Mapper.Map<IEnumerable<SeedBatchDto>, List<PlantSeedListViewModel>>(dtoList);

                var model = new ListViewModelStatic<PlantSeedListViewModel>(
                    modelList, apiPagingInfo.page, apiPagingInfo.pageSize, apiPagingInfo.totalCount, query.SortBy,
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
            if (querySortBy == nameof(PlantSeedListViewModel.Id))
            {
                sortField = nameof(SeedBatchDto.Id);
            }
            else if (querySortBy == nameof(PlantSeedListViewModel.DateCollected))
            {
                sortField = nameof(SeedBatchDto.DateCollected);
            }
            else if (querySortBy == nameof(PlantSeedListViewModel.Location))
            {
                sortField = nameof(SeedBatchDto.Location);
            }
            else if (querySortBy == nameof(PlantSeedListViewModel.SiteName))
            {
                sortField = ""; // TODO: solve this problem
            }
            else if (querySortBy == nameof(PlantSeedListViewModel.SpeciesBinomial))
            {
                sortField = ""; // TODO: solve this problem
            }
            else if (querySortBy == nameof(PlantSeedListViewModel.SpeciesId))
            {
                sortField = nameof(SeedBatchDto.SpeciesId);
            }

            return sortField;
        }
    }
}