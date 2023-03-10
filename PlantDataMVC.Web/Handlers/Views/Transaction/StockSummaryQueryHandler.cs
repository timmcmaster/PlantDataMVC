using AutoMapper;
using Framework.Web.Views;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using PlantDataMVC.Common.Client;
using PlantDataMVC.Repository.Models;
using PlantDataMVC.Web.Controllers.Queries.Transaction;
using PlantDataMVC.Web.Helpers;
using PlantDataMVC.Web.Models.ViewModels;
using PlantDataMVC.Web.Models.ViewModels.Transaction;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace PlantDataMVC.Web.Handlers.Views.Transaction
{
    public class StockSummaryQueryHandler : IQueryHandler<StockSummaryQuery, ListViewModelStatic<TransactionStockSummaryListViewModel>>
    {
        private readonly IPlantDataApiClient _plantDataApiClient;
        private readonly IMapper _mapper;

        public StockSummaryQueryHandler(IPlantDataApiClient plantDataApiClient, IMapper mapper)
        {
            _plantDataApiClient = plantDataApiClient;
            _mapper = mapper;
        }

        public async Task<ListViewModelStatic<TransactionStockSummaryListViewModel>> Handle(StockSummaryQuery query, CancellationToken cancellationToken)
        {
            bool usePaging = (query.Page != null && query.PageSize != null);
            // Get paging part of query string
            var baseUri = "api/JournalEntries/StockSummary";
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
            var response = await _plantDataApiClient.GetAsync<IEnumerable<JournalEntryStockSummaryDataModel>>(requestUri, cancellationToken).ConfigureAwait(false);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedAccessException();
            }
            else if (response.Success && response.Content != null)
            {
                var apiPagingInfo = response.PagingInfo;
                var linkInfo = response.LinkInfo;

                var modelList = _mapper.Map<IEnumerable<JournalEntryStockSummaryDataModel>, List<TransactionStockSummaryListViewModel>>(response.Content);

                var model = new ListViewModelStatic<TransactionStockSummaryListViewModel>(
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
            if (querySortBy == nameof(TransactionStockSummaryListViewModel.ProductTypeId))
            {
                sortField = nameof(JournalEntryStockSummaryDataModel.ProductTypeId);
            }
            else if (querySortBy == nameof(TransactionStockSummaryListViewModel.SpeciesId))
            {
                sortField = nameof(JournalEntryStockSummaryDataModel.SpeciesId);
            }
            else if (querySortBy == nameof(TransactionStockSummaryListViewModel.QuantityInStock))
            {
                sortField = nameof(JournalEntryStockSummaryDataModel.QuantityInStock);
            }
            else if (querySortBy == nameof(TransactionStockSummaryListViewModel.ProductTypeName))
            {
                sortField = nameof(JournalEntryStockSummaryDataModel.ProductTypeName);
            }
            else if (querySortBy == nameof(TransactionStockSummaryListViewModel.SpeciesBinomial))
            {
                sortField = $"{nameof(JournalEntryStockSummaryDataModel.GenusName)},{nameof(JournalEntryStockSummaryDataModel.SpeciesName)}";
            }

            return sortField;
        }
    }
}