﻿using AutoMapper;
using Framework.Web.Views;
using Newtonsoft.Json;
using PlantDataMVC.Api.Models.DataModels;
using PlantDataMVC.Common.Client;
using PlantDataMVC.Web.Controllers.Queries.SeedBatch;
using PlantDataMVC.Web.Helpers;
using PlantDataMVC.Web.Models.ViewModels;
using PlantDataMVC.Web.Models.ViewModels.SeedBatch;
using System.Collections.Generic;
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
            // Get paging part of query
            var requestUri = "api/SeedBatch?page=" + query.Page + "&pageSize=" + query.PageSize;

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
            //var httpResponse = await _plantDataApiClient.GetAsync(requestUri).ConfigureAwait(false);

            if (httpResponse.IsSuccessStatusCode)
            {
                var content = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

                ApiPagingInfo apiPagingInfo = HeaderParser.FindAndParsePagingInfo(httpResponse.Headers);
                LinkHeader linkInfo = HeaderParser.FindAndParseLinkInfo(httpResponse.Headers);

                var dataModelList = JsonConvert.DeserializeObject<IEnumerable<SeedBatchDataModel>>(content);

                List<SeedBatchListViewModel> modelList = _mapper.Map<IEnumerable<SeedBatchDataModel>, List<SeedBatchListViewModel>>(dataModelList);

                var model = new ListViewModelStatic<SeedBatchListViewModel>(
                    modelList, apiPagingInfo.page, apiPagingInfo.pageSize, apiPagingInfo.totalCount, query.SortBy,
                    query.SortAscending);

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