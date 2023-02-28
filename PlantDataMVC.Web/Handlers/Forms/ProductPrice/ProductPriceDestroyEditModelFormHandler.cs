﻿using AutoMapper;
using Framework.Web.Forms;
using PlantDataMVC.Common.Client;
using PlantDataMVC.Web.Models.EditModels.ProductPrice;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace PlantDataMVC.Web.Handlers.Forms.ProductPrice
{
    public class ProductPriceDestroyEditModelFormHandler : IFormHandler<ProductPriceDestroyEditModel, bool>
    {
        private readonly IPlantDataApiClient _plantDataApiClient;
        private readonly IMapper _mapper;

        public ProductPriceDestroyEditModelFormHandler(IPlantDataApiClient plantDataApiClient, IMapper mapper)
        {
            _plantDataApiClient = plantDataApiClient;
        }

        public async Task<bool> Handle(ProductPriceDestroyEditModel form, CancellationToken cancellationToken)
        {
            try
            {
                var uri = $"api/ProductPrice?productTypeId={form.ProductTypeId}&priceListId={form.PriceListTypeId}&strEffectiveDate={form.DateEffective.ToString("yyyyMMdd")}";

                var response = await _plantDataApiClient.DeleteAsync(uri, cancellationToken).ConfigureAwait(false);
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new UnauthorizedAccessException();
                }
                else
                {
                    return response.Success;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}