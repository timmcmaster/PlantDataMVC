using AutoMapper;
using Azure;
using Framework.Web.Views;
using Newtonsoft.Json;
using PlantDataMVC.Api.Models.DataModels;
using PlantDataMVC.Common.Client;
using PlantDataMVC.Web.Controllers.Queries.PlantStock;
using PlantDataMVC.Web.Helpers;
using PlantDataMVC.Web.Models.ViewModels;
using PlantDataMVC.Web.Models.ViewModels.PlantStock;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace PlantDataMVC.Web.Handlers.Views.PlantStock
{
    public class IndexQueryHandler : IQueryHandler<IndexQuery, ListViewModelStatic<PlantStockListViewModel>>
    {
        private readonly IPlantDataApiClient _plantDataApiClient;
        private readonly IMapper _mapper;

        public IndexQueryHandler(IPlantDataApiClient plantDataApiClient, IMapper mapper)
        {
            _plantDataApiClient = plantDataApiClient;
            _mapper = mapper;
        }

        public async Task<ListViewModelStatic<PlantStockListViewModel>> Handle(IndexQuery query, CancellationToken cancellationToken)
        {
            // Get paging part of query string
            var requestUri = "api/PlantStock?page=" + query.Page + "&pageSize=" + query.PageSize;

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

            var response = await _plantDataApiClient.GetAsync<IEnumerable<PlantStockDataModel>>(requestUri, cancellationToken).ConfigureAwait(false);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedAccessException();
            }
            else if (response.Success && response.Content != null)
            {
                var apiPagingInfo = response.PagingInfo;
                var linkInfo = response.LinkInfo;

                var modelList = _mapper.Map<IEnumerable<PlantStockDataModel>, List<PlantStockListViewModel>>(response.Content);

                var model = new ListViewModelStatic<PlantStockListViewModel>(modelList,
                                                                             apiPagingInfo.page,
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
        /// Maps the sort field from display field column to dataModel field as used by API
        /// </summary>
        /// <param name="querySortBy">The query sort by.</param>
        /// <returns></returns>
        private string MapSortField(string querySortBy)
        {
            var sortField = "";

            // TODO: Got to be a more rigorous way to convert columns back to API fields
            // supplied sortBy field should belong to display object (as it is generated from model metadata)
            if (querySortBy == nameof(PlantStockListViewModel.Id))
            {
                sortField = nameof(PlantStockDataModel.Id);
            }
            else if (querySortBy == nameof(PlantStockListViewModel.ProductTypeName))
            {
                sortField = nameof(PlantStockDataModel.ProductTypeName);
            }
            else if (querySortBy == nameof(PlantStockListViewModel.QuantityInStock))
            {
                sortField = nameof(PlantStockDataModel.QuantityInStock);
            }
            else if (querySortBy == nameof(PlantStockListViewModel.SpeciesBinomial))
            {
                sortField = $"{nameof(PlantStockDataModel.GenusName)},{nameof(PlantStockDataModel.SpeciesName)}";
            }
            else if (querySortBy == nameof(PlantStockListViewModel.SpeciesId))
            {
                sortField = nameof(PlantStockDataModel.SpeciesId);
            }

            return sortField;
        }
    }
}