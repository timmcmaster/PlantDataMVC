using AutoMapper;
using Framework.Web.Views;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using PlantDataMVC.Api.Models.DataModels;
using PlantDataMVC.Common.Client;
using PlantDataMVC.Web.Controllers.Queries.StocktakeHeader;
using PlantDataMVC.Web.Helpers;
using PlantDataMVC.Web.Models.ViewModels;
using PlantDataMVC.Web.Models.ViewModels.StocktakeHeader;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace PlantDataMVC.Web.Handlers.Views.StocktakeHeader
{
    public class IndexQueryHandler : IQueryHandler<IndexQuery, ListViewModelStatic<StocktakeHeaderListViewModel>>
    {
        private readonly IPlantDataApiClient _plantDataApiClient;
        private readonly IMapper _mapper;

        public IndexQueryHandler(IPlantDataApiClient plantDataApiClient, IMapper mapper)
        {
            _plantDataApiClient = plantDataApiClient;
            _mapper = mapper;
        }

        public async Task<ListViewModelStatic<StocktakeHeaderListViewModel>> Handle(IndexQuery query, CancellationToken cancellationToken)
        {
            bool usePaging = (query.Page != null && query.PageSize != null);

            // Get paging part of query
            var baseUri = "api/StocktakeHeader";
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
            var response = await _plantDataApiClient.GetAsync<IEnumerable<StocktakeDataModel>>(requestUri, cancellationToken).ConfigureAwait(false);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedAccessException();
            }
            else if (response.Success && response.Content != null)
            {
                var apiPagingInfo = response.PagingInfo;

                var modelList = _mapper.Map<IEnumerable<StocktakeDataModel>, List<StocktakeHeaderListViewModel>>(response.Content);

                var model = new ListViewModelStatic<StocktakeHeaderListViewModel>(
                    modelList,
                    apiPagingInfo.Page, apiPagingInfo.PageSize, apiPagingInfo.TotalCount,
                    query.SortBy, query.SortAscending);

                return model;
            }
            else
            {
                // TODO: better way needed to handle failure response
                return null;
            }
        }

        /// <summary>
        /// Maps the sort field from display field column to dataModel field as used by API
        /// </summary>
        /// <param name="querySortBy">The query sort by.</param>
        /// <returns></returns>
        private static string MapSortField(string querySortBy)
        {
            var sortField = "";

            // TODO: Got to be a more rigorous way to convert columns back to API fields
            // supplied sortBy field should belong to display object (as it is generated from model metadata)
            if (querySortBy == nameof(StocktakeHeaderListViewModel.Id))
            {
                sortField = nameof(StocktakeDataModel.Id);
            }
            else if (querySortBy == nameof(StocktakeHeaderListViewModel.Reference))
            {
                sortField = nameof(StocktakeDataModel.Reference);
            }
            else if (querySortBy == nameof(StocktakeHeaderListViewModel.StocktakeDate))
            {
                sortField = nameof(StocktakeDataModel.StocktakeDate);
            }

            return sortField;
        }
    }
}