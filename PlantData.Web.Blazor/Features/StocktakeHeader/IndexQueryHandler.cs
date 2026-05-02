using AutoMapper;
using Framework.Web.Views;
using Microsoft.AspNetCore.WebUtilities;
using PlantData.Web.Blazor.Features.StocktakeHeader;
using PlantData.Web.Blazor.Helpers;
using PlantData.Web.Blazor.SharedComponents.Grid;
using PlantData.Web.Blazor.UIModels.ViewModels.StocktakeHeader;
using PlantDataMVC.Api.Models.DataModels;
using PlantDataMVC.Common.Client;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace PlantData.Web.Mvc.Handlers.Views.StocktakeHeader
{
    public class IndexQueryHandler : IQueryHandler<IndexQuery, GridDataModel<StocktakeHeaderGridModel>>
    {
        private readonly IPlantDataApiClient _plantDataApiClient;
        private readonly IMapper _mapper;

        public IndexQueryHandler(IPlantDataApiClient plantDataApiClient, IMapper mapper)
        {
            _plantDataApiClient = plantDataApiClient;
            _mapper = mapper;
        }

        public async Task<GridDataModel<StocktakeHeaderGridModel>> Handle(IndexQuery query, CancellationToken cancellationToken)
        {
            bool usePaging = query.Page != null && query.PageSize != null;

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

                var modelList = _mapper.Map<IEnumerable<StocktakeDataModel>, List<StocktakeHeaderGridModel>>(response.Content);

                var model = new GridDataModel<StocktakeHeaderGridModel>(
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
            if (querySortBy == nameof(StocktakeHeaderGridModel.Id))
            {
                sortField = nameof(StocktakeDataModel.Id);
            }
            else if (querySortBy == nameof(StocktakeDataModel.StocktakeDate))
            {
                sortField = nameof(StocktakeDataModel.StocktakeDate);
            }
            else if (querySortBy == nameof(StocktakeDataModel.Reference))
            {
                sortField = nameof(StocktakeDataModel.Reference);
            }

            return sortField;
        }
    }
}
