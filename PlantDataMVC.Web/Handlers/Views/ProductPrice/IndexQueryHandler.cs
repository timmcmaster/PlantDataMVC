using AutoMapper;
using Framework.Web.Views;
using Microsoft.Extensions.Configuration;
using PlantDataMVC.Api.Models.DataModels;
using PlantDataMVC.Common.Client;
using PlantDataMVC.Web.Controllers.Queries.ProductPrice;
using PlantDataMVC.Web.Helpers;
using PlantDataMVC.Web.Models.ViewModels;
using PlantDataMVC.Web.Models.ViewModels.ProductPrice;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace PlantDataMVC.Web.Handlers.Views.ProductPrice
{
    public class IndexQueryHandler : IQueryHandler<IndexQuery, ListViewModelStatic<ProductPriceListViewModel>>
    {
        private readonly IPlantDataApiClient _plantDataApiClient;
        private readonly IMapper _mapper;
        private readonly bool _useBasicMvcViews = false;

        public IndexQueryHandler(IPlantDataApiClient plantDataApiClient, IMapper mapper, IConfiguration configuration)
        {
            _plantDataApiClient = plantDataApiClient;
            _mapper = mapper;
            _useBasicMvcViews = Convert.ToBoolean(configuration["WebUI:UseBasicMvcViews"]);
        }

        public async Task<ListViewModelStatic<ProductPriceListViewModel>> Handle(IndexQuery query, CancellationToken cancellationToken)
        {
            // Get paging part of query
            var requestUri = "api/ProductPrice?page=" + query.Page + "&pageSize=" + query.PageSize;

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

            var response = await _plantDataApiClient.GetAsync<IEnumerable<ProductPriceDataModel>>(requestUri, cancellationToken).ConfigureAwait(false);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedAccessException();
            }
            else if (response.Success && response.Content != null)
            {
                var apiPagingInfo = response.PagingInfo;
                var linkInfo = response.LinkInfo;

                var modelList = _mapper.Map<IEnumerable<ProductPriceDataModel>, List<ProductPriceListViewModel>>(response.Content);

                var showAddItem = _useBasicMvcViews;
                var showPagingLinks = _useBasicMvcViews;
                var model = new ListViewModelStatic<ProductPriceListViewModel>(
                    modelList,
                    apiPagingInfo.page, apiPagingInfo.pageSize, apiPagingInfo.totalCount,
                    query.SortBy, query.SortAscending,
                    showAddItem, showPagingLinks);

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
            if (querySortBy == nameof(ProductPriceListViewModel.Id))
            {
                sortField = nameof(ProductPriceDataModel.Id);
            }
            else if (querySortBy == nameof(ProductPriceListViewModel.ProductTypeId))
            {
                sortField = nameof(ProductPriceDataModel.ProductTypeId);
            }
            else if (querySortBy == nameof(ProductPriceListViewModel.PriceListTypeId))
            {
                sortField = nameof(ProductPriceDataModel.PriceListTypeId);
            }
            else if (querySortBy == nameof(ProductPriceListViewModel.ProductTypeName))
            {
                sortField = nameof(ProductPriceDataModel.ProductTypeName);
            }
            else if (querySortBy == nameof(ProductPriceListViewModel.PriceListTypeName))
            {
                sortField = nameof(ProductPriceDataModel.PriceListTypeName);
            }
            else if (querySortBy == nameof(ProductPriceListViewModel.DateEffective))
            {
                sortField = nameof(ProductPriceDataModel.DateEffective);
            }
            else if (querySortBy == nameof(ProductPriceListViewModel.Price))
            {
                sortField = nameof(ProductPriceDataModel.Price);
            }

            return sortField;
        }
    }
}