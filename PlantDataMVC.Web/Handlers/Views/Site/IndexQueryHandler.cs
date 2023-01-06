﻿using AutoMapper;
using Framework.Web.Views;
using Newtonsoft.Json;
using PlantDataMVC.Api.Models.DataModels;
using PlantDataMVC.Common.Client;
using PlantDataMVC.Web.Controllers.Queries.Site;
using PlantDataMVC.Web.Helpers;
using PlantDataMVC.Web.Models.ViewModels;
using PlantDataMVC.Web.Models.ViewModels.Site;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PlantDataMVC.Web.Handlers.Views.Site
{
    public class IndexQueryHandler : IQueryHandler<IndexQuery, ListViewModelStatic<SiteListViewModel>>
    {
        private readonly IPlantDataApiClient _plantDataApiClient;
        private readonly IMapper _mapper;

        public IndexQueryHandler(IPlantDataApiClient plantDataApiClient, IMapper mapper)
        {
            _plantDataApiClient = plantDataApiClient;
            _mapper = mapper;
        }

        public async Task<ListViewModelStatic<SiteListViewModel>> Handle(IndexQuery query, CancellationToken cancellationToken)
        {
            // Get paging part of query
            var requestUri = "api/Site?page=" + query.Page + "&pageSize=" + query.PageSize;

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

                var dataModelList = JsonConvert.DeserializeObject<IEnumerable<SiteDataModel>>(content);
                var modelList = _mapper.Map<IEnumerable<SiteDataModel>, List<SiteListViewModel>>(dataModelList);

                var model = new ListViewModelStatic<SiteListViewModel>(modelList, apiPagingInfo.page,
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
        /// Maps the sort field from display field column to dataModel field as used by API
        /// </summary>
        /// <param name="querySortBy">The query sort by.</param>
        /// <returns></returns>
        private string MapSortField(string querySortBy)
        {
            var sortField = "";

            // TODO: Got to be a more rigorous way to convert columns back to API fields
            // supplied sortBy field should belong to display object (as it is generated from model metadata)
            if (querySortBy == nameof(SiteListViewModel.Id))
            {
                sortField = nameof(SeedTrayDataModel.Id);
            }
            else if (querySortBy == nameof(SiteListViewModel.Latitude))
            {
                sortField = nameof(SiteDataModel.Latitude);
            }
            else if (querySortBy == nameof(SiteListViewModel.Longitude))
            {
                sortField = nameof(SiteDataModel.Longitude);
            }
            else if (querySortBy == nameof(SiteListViewModel.SiteName))
            {
                sortField = nameof(SiteDataModel.SiteName);
            }
            else if (querySortBy == nameof(SiteListViewModel.Suburb))
            {
                sortField = nameof(SiteDataModel.Suburb);
            }

            return sortField;
        }
    }
}