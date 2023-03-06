using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PlantDataMVC.Web.Models.ViewModels.SaleEventStock;
using PlantDataMVC.Web.Views.Shared.Components.SaleEventStockGrid;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlantDataMVC.Web.Shared.Components.ProductTypeGrid
{
    public class SaleEventStockGrid : ViewComponent
    {
        private readonly bool _useBasicMvcViews = false;

        public SaleEventStockGrid(IConfiguration configuration)
        {
            _useBasicMvcViews = Convert.ToBoolean(configuration["WebUI:UseBasicMvcViews"]);
        }

        public async Task<IViewComponentResult> InvokeAsync(IEnumerable<SaleEventStockListViewModel> saleEventStocks, int? saleEventId = null)
        {
            string viewName = "Default";

            if (_useBasicMvcViews)
            {
                viewName = "Basic";
                return View(viewName, saleEventStocks);
            }

            var model = new SaleEventStockGridViewModel()
            {
                SaleEventId = saleEventId,
                SaleEventStocks = saleEventStocks
            };

            return View(viewName, model);
        }
    }
}
