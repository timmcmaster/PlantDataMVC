﻿using AutoMapper;
using Framework.Web.Core.Views;
using Newtonsoft.Json;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.UICore.Controllers.Queries.SeedTray;
using PlantDataMVC.UICore.Helpers;
using PlantDataMVC.UICore.Models.ViewModels;
using PlantDataMVC.UICore.Models.ViewModels.SeedTray;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PlantDataMVC.UICore.Handlers.Views.SeedTray
{
    public class IndexQueryHandler : IQueryHandler<IndexQuery, ListViewModelStatic<SeedTrayListViewModel>>
    {
        private readonly IPlantDataApiClient _plantDataApiClient;

        public IndexQueryHandler(IPlantDataApiClient plantDataApiClient)
        {
            _plantDataApiClient = plantDataApiClient;
        }

        public async Task<ListViewModelStatic<SeedTrayListViewModel>> HandleAsync(IndexQuery query, CancellationToken cancellationToken)
        {
            // Get paging part of query string
            var requestUri = "api/SeedTray?page=" + query.Page + "&pageSize=" + query.PageSize;

            // add sorting if it maps ok
            if (!string.IsNullOrEmpty(query.SortBy))
            {
                var apiSortField = MapSortField(query.SortBy);
                if (!string.IsNullOrEmpty(apiSortField))
                {
                    var sortString = ApiSorting.CreateSortString(apiSortField, query.SortAscending);
                    requestUri = sortString == "" ? requestUri : requestUri + "&sort=" + sortString;
                }
            }

            var httpResponse = await _plantDataApiClient.GetAsync(requestUri, cancellationToken).ConfigureAwait(false);

            if (httpResponse.IsSuccessStatusCode)
            {
                string content = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

                var apiPagingInfo = HeaderParser.FindAndParsePagingInfo(httpResponse.Headers);
                var linkInfo = HeaderParser.FindAndParseLinkInfo(httpResponse.Headers);

                var dtoList = JsonConvert.DeserializeObject<IEnumerable<SeedTrayDto>>(content);
                var modelList = Mapper.Map<IEnumerable<SeedTrayDto>, List<SeedTrayListViewModel>>(dtoList);

                var model = new ListViewModelStatic<SeedTrayListViewModel>(modelList, apiPagingInfo.page,
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
            if (querySortBy == nameof(SeedTrayListViewModel.Id))
            {
                sortField = nameof(SeedTrayDto.Id);
            }
            else if (querySortBy == nameof(SeedTrayListViewModel.DatePlanted))
            {
                sortField = nameof(SeedTrayDto.DatePlanted);
            }
            else if (querySortBy == nameof(SeedTrayListViewModel.SeedBatchId))
            {
                sortField = nameof(SeedTrayDto.SeedBatchId);
            }
            else if (querySortBy == nameof(SeedTrayListViewModel.ThrownOut))
            {
                sortField = nameof(SeedTrayDto.ThrownOut);
            }
            else if (querySortBy == nameof(SeedTrayListViewModel.Treatment))
            {
                sortField = nameof(SeedTrayDto.Treatment);
            }

            return sortField;
        }
    }
}