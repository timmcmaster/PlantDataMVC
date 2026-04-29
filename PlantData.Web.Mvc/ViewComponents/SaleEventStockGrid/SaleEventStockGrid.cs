using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PlantData.Web.Mvc.Models.ViewComponents.ViewModels;
using PlantData.Web.Mvc.Models.ViewModels.SaleEventStock;
using System;
using System.Collections.Generic;

namespace PlantData.Web.Mvc.ViewComponents.SaleEventStockGrid
{
    public class SaleEventStockGrid : ViewComponent
    {
        private readonly bool _UseBasicHtmlViews = false;

        public SaleEventStockGrid(IConfiguration configuration)
        {
            _UseBasicHtmlViews = Convert.ToBoolean(configuration["WebUI:UseBasicHtmlViews"]);
        }

        public IViewComponentResult Invoke(IEnumerable<SaleEventStockListViewModel> saleEventStocks, GridOptionsModel gridOptions, int? saleEventId = null)
        {
            string viewName = "Default";

            if (_UseBasicHtmlViews)
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
