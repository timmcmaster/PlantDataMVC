﻿using AutoMapper;
using Framework.Web.Views;
using Microsoft.AspNetCore.WebUtilities;
using PlantDataMVC.Common.Client;
using PlantDataMVC.Repository.Models;
using PlantDataMVC.Web.Controllers.Queries.Transaction;
using PlantDataMVC.Web.Models.ViewModels.Transaction;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace PlantDataMVC.Web.Handlers.Views.Transaction
{
    public class StockSummaryDetailsQueryHandler : IQueryHandler<StockSummaryDetailsQuery, TransactionStockSummaryDetailsViewModel>
    {
        private readonly IPlantDataApiClient _plantDataApiClient;
        private readonly IMapper _mapper;

        public StockSummaryDetailsQueryHandler(IPlantDataApiClient plantDataApiClient, IMapper mapper)
        {
            _plantDataApiClient = plantDataApiClient;
            _mapper = mapper;
        }

        public async Task<TransactionStockSummaryDetailsViewModel> Handle(StockSummaryDetailsQuery query, CancellationToken cancellationToken)
        {
            var baseUri = "api/JournalEntries/StockSummaryDetails";
            var queryParams = new Dictionary<string, string?>();
                queryParams.Add("speciesId", query.SpeciesId.ToString());
                queryParams.Add("productTypeId", query.ProductTypeId.ToString());

            var requestUri = QueryHelpers.AddQueryString(baseUri, queryParams);
            var response = await _plantDataApiClient.GetAsync<JournalEntryStockSummaryDataModel>(requestUri, cancellationToken).ConfigureAwait(false);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedAccessException();
            }
            else if (response.Success && response.Content != null)
            {
                var model = _mapper.Map<JournalEntryStockSummaryDataModel, TransactionStockSummaryDetailsViewModel>(response.Content);
                return model;
            }
            else
            {
                // TODO: better way needed to handle failure response
                return null;
            }
        }
    }
}