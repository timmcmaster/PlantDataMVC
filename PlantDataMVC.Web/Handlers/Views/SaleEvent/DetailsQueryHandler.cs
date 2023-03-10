using AutoMapper;
using Framework.Web.Views;
using PlantDataMVC.Api.Models.DataModels;
using PlantDataMVC.Common.Client;
using PlantDataMVC.Web.Controllers.Queries.SaleEvent;
using PlantDataMVC.Web.Models.ViewModels.SaleEvent;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace PlantDataMVC.Web.Handlers.Views.SaleEvent
{
    public class DetailsQueryHandler : IQueryHandler<DetailsQuery, SaleEventDetailsViewModel>
    {
        private readonly IPlantDataApiClient _plantDataApiClient;
        private readonly IMapper _mapper;

        public DetailsQueryHandler(IPlantDataApiClient plantDataApiClient, IMapper mapper)
        {
            _plantDataApiClient = plantDataApiClient;
            _mapper = mapper;
        }

        public async Task<SaleEventDetailsViewModel> Handle(DetailsQuery query, CancellationToken cancellationToken)
        {
            // Get paging part of query
            var requestUri = $"api/SaleEvent/{query.Id}";
            var response = await _plantDataApiClient.GetAsync<SaleEventDataModel>(requestUri, cancellationToken).ConfigureAwait(false);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedAccessException();
            }
            else if (response.Success && response.Content != null)
            {
                var model = _mapper.Map<SaleEventDataModel, SaleEventDetailsViewModel>(response.Content);
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
            if (querySortBy == nameof(SaleEventListViewModel.Id))
            {
                sortField = nameof(SaleEventDataModel.Id);
            }
            else if (querySortBy == nameof(SaleEventListViewModel.Name))
            {
                sortField = nameof(SaleEventDataModel.Name);
            }
            else if (querySortBy == nameof(SaleEventListViewModel.SaleDate))
            {
                sortField = nameof(SaleEventDataModel.SaleDate);
            }
            else if (querySortBy == nameof(SaleEventListViewModel.Location))
            {
                sortField = nameof(SaleEventDataModel.Location);
            }

            return sortField;
        }
    }
}