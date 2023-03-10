using AutoMapper;
using Framework.Web.Views;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using PlantDataMVC.Api.Models.DataModels;
using PlantDataMVC.Common.Client;
using PlantDataMVC.Web.Controllers.Queries.SeedBatch;
using PlantDataMVC.Web.Helpers;
using PlantDataMVC.Web.Models.ViewModels;
using PlantDataMVC.Web.Models.ViewModels.SeedBatch;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace PlantDataMVC.Web.Handlers.Views.SeedBatch
{
    public class IndexQueryHandler : IQueryHandler<IndexQuery, ListViewModelStatic<SeedBatchListViewModel>>
    {
        private readonly IPlantDataApiClient _plantDataApiClient;
        private readonly IMapper _mapper;

        public IndexQueryHandler(IPlantDataApiClient plantDataApiClient, IMapper mapper)
        {
            _plantDataApiClient = plantDataApiClient;
            _mapper = mapper;
        }

        public async Task<ListViewModelStatic<SeedBatchListViewModel>> Handle(IndexQuery query, CancellationToken cancellationToken)
        {
            bool usePaging = (query.Page != null && query.PageSize != null);

            // Get paging part of query
            var baseUri = "api/SeedBatch";
            var queryParams = new Dictionary<string, string?>();
            if (usePaging)
            {
                queryParams.Add("page", query.Page.ToString());
                queryParams.Add("pageSize", query.PageSize.ToString());
            }

            // add sorting if it maps ok
            if (!string.IsNullOrEmpty(query.SortBy))
            {
                var apiSortField = MapSortField(query.SortBy);
                if (!string.IsNullOrEmpty(apiSortField))
                {
                    var sortString = ApiSorting.CreateSortString(apiSortField, query.SortAscending);
                    if (sortString != "")
                        queryParams.Add("sort", sortString);

                }
            }

            var requestUri = QueryHelpers.AddQueryString(baseUri, queryParams);
            var response = await _plantDataApiClient.GetAsync<IEnumerable<SeedBatchDataModel>>(requestUri, cancellationToken).ConfigureAwait(false);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedAccessException();
            }
            else if (response.Success && response.Content != null)
            {
                var apiPagingInfo = response.PagingInfo;
                var linkInfo = response.LinkInfo;

                var modelList = _mapper.Map<IEnumerable<SeedBatchDataModel>, List<SeedBatchListViewModel>>(response.Content);

                var model = new ListViewModelStatic<SeedBatchListViewModel>(
                    modelList,
                    apiPagingInfo.page, apiPagingInfo.pageSize, apiPagingInfo.totalCount,
                    query.SortBy, query.SortAscending);

                return model;
            }

            // TODO: better way needed to handle failure response
            return null;
        }

        /// <summary>
        /// Maps the sort field from display field column to dataModel field as used by API
        /// </summary>
        /// <param name="querySortBy">The query sort by.</param>
        /// <returns></returns>
        private string MapSortField(string querySortBy)
        {
            var sortField = "";

            // TODO: Got to be a more rigorous way to convert columns back to API fields
            // supplied sortBy field should belong to display object (as it is generated from model metadata)
            if (querySortBy == nameof(SeedBatchListViewModel.Id))
            {
                sortField = nameof(SeedBatchDataModel.Id);
            }
            else if (querySortBy == nameof(SeedBatchListViewModel.DateCollected))
            {
                sortField = nameof(SeedBatchDataModel.DateCollected);
            }
            else if (querySortBy == nameof(SeedBatchListViewModel.Location))
            {
                sortField = nameof(SeedBatchDataModel.Location);
            }
            else if (querySortBy == nameof(SeedBatchListViewModel.SiteName))
            {
                sortField = nameof(SeedBatchDataModel.SiteName);
            }
            else if (querySortBy == nameof(SeedBatchListViewModel.SpeciesBinomial))
            {
                sortField = $"{nameof(SeedBatchDataModel.GenusName)},{nameof(SeedBatchDataModel.SpeciesName)}";
            }
            else if (querySortBy == nameof(SeedBatchListViewModel.SpeciesId))
            {
                sortField = nameof(SeedBatchDataModel.SpeciesId);
            }

            return sortField;
        }
    }
}