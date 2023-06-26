using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PlantDataMVC.Web.Models.ViewComponents.ViewModels;
using PlantDataMVC.Web.Models.ViewModels;
using PlantDataMVC.Web.Models.ViewModels.SaleEventStock;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlantDataMVC.Web.ViewComponents.ProductTypeGrid
{
    public class SaleEventStockGrid : ViewComponent
    {
        private readonly bool _useBasicMvcViews = false;

        public SaleEventStockGrid(IConfiguration configuration)
        {
            _useBasicMvcViews = Convert.ToBoolean(configuration["WebUI:UseBasicMvcViews"]);
        }

        public IViewComponentResult Invoke(IEnumerable<SaleEventStockListViewModel> saleEventStocks, GridOptionsModel gridOptions, int? saleEventId = null)
        {
            string viewName = "Default";

            if (_useBasicMvcViews)
            {
                viewName = "Basic";
            }

            var gridModel = new SaleEventStockGridViewModel()
            {
                Options = gridOptions,

                //PageNumber = model.PageNumber,
                //PageSize = model.PageSize,
                //HasNextPage = model.HasNextPage,
                //HasPreviousPage = model.HasPreviousPage,
                //TotalCount = model.TotalCount,
                //TotalPages = model.TotalPages,

                //SortBy = model.SortBy,
                //SortAscending = model.SortAscending,
                //SortExpression = model.SortExpression,

                SaleEventId = saleEventId,
                Items = saleEventStocks
            };

            return View(viewName, gridModel);
        }
    }
}
