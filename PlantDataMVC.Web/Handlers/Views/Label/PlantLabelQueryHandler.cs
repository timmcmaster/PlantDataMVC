using AutoMapper;
using Azure;
using Framework.Web.Views;
using Microsoft.AspNetCore.WebUtilities;
using PlantDataMVC.Api.Models.DataModels;
using PlantDataMVC.Common.Client;
using PlantDataMVC.Common.Client.Models;
using PlantDataMVC.Web.Controllers.Queries.Label;
using PlantDataMVC.Web.Helpers;
using PlantDataMVC.Web.Models.ViewModels;
using PlantDataMVC.Web.Models.ViewModels.Label;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace PlantDataMVC.Web.Handlers.Views.Label
{
    public class PlantLabelQueryHandler : IQueryHandler<PlantLabelQuery, ListViewModelStatic<PlantLabelListViewModel>>
    {
        private readonly IPlantDataApiClient _plantDataApiClient;
        private readonly IMapper _mapper;

        public PlantLabelQueryHandler(IPlantDataApiClient plantDataApiClient, IMapper mapper)
        {
            _plantDataApiClient = plantDataApiClient;
            _mapper = mapper;
        }

        public async Task<ListViewModelStatic<PlantLabelListViewModel>> Handle(PlantLabelQuery query, CancellationToken cancellationToken)
        {
            /*
            bool usePaging = (query.Page != null && query.PageSize != null);
            // Get paging part of query string
            var baseUri = "api/Species";
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
            var response = await _plantDataApiClient.GetAsync<IEnumerable<SpeciesDataModel>>(requestUri, cancellationToken).ConfigureAwait(false);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedAccessException();
            }
            else if (response.Success && response.Content != null)
            {
                var apiPagingInfo = response.PagingInfo;
                var linkInfo = response.LinkInfo;

                var modelList = _mapper.Map<IEnumerable<SpeciesDataModel>, List<PlantLabelListViewModel>>(response.Content);

                var model = new ListViewModelStatic<PlantLabelListViewModel>(
                    modelList,
                    apiPagingInfo.page, apiPagingInfo.pageSize, apiPagingInfo.totalCount,
                    query.SortBy, query.SortAscending);

                return model;
            }
            */
            var modelList = new List<PlantLabelListViewModel>();

            var model = new ListViewModelStatic<PlantLabelListViewModel>(modelList,1,0,0, query.SortBy, query.SortAscending);

            return model;
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
            if (querySortBy == nameof(PlantLabelListViewModel.SpeciesId))
            {
                sortField = nameof(SpeciesDataModel.Id);
            }
            else if (querySortBy == nameof(PlantLabelListViewModel.SpeciesBinomial))
            {
                sortField = $"{nameof(SpeciesDataModel.GenusName)},{nameof(SpeciesDataModel.SpecificName)}";
            }

            return sortField;
        }
    }
}