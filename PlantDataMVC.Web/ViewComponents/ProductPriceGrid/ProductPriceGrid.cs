using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PlantDataMVC.Web.Models.ViewModels.ProductPrice;
using PlantDataMVC.Web.ViewComponents.ProductPriceGrid;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlantDataMVC.Web.ViewComponents.ProductPriceGrid
{
    public class ProductPriceGrid : ViewComponent
    {
        private readonly bool _useBasicMvcViews = false;

        public ProductPriceGrid(IConfiguration configuration)
        {
            _useBasicMvcViews = Convert.ToBoolean(configuration["WebUI:UseBasicMvcViews"]);
        }

        public async Task<IViewComponentResult> InvokeAsync(IEnumerable<ProductPriceListViewModel> productPrices, int? priceListTypeId = null)
        {
            string viewName = "Default";

            if (_useBasicMvcViews)
            {
                viewName = "Basic";
                return View(viewName, productPrices);
            }

            var model = new ProductPriceGridViewModel()
            {
                PriceListTypeId = priceListTypeId,
                ProductPrices = productPrices
            };

            return View(viewName, model);
        }
    }
}
