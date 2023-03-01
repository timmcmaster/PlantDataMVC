using Microsoft.AspNetCore.Mvc;
using PlantDataMVC.Constants;
using PlantDataMVC.Web.Models.ViewModels.ProductPrice;
using PlantDataMVC.Web.Views.Shared.Components.ProductPriceGrid;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlantDataMVC.Web.Shared.Components.ProductTypeGrid
{
    public class ProductPriceGrid : ViewComponent
    {
        public ProductPriceGrid()
        {
            Console.WriteLine("Called VC constructor");
        }

        public async Task<IViewComponentResult> InvokeAsync(IEnumerable<ProductPriceListViewModel> productPrices, int? priceListTypeId = null)
        {
            string viewName = "Default";

            if (PlantDataMvcConstants.UseBasicMvcViews)
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
