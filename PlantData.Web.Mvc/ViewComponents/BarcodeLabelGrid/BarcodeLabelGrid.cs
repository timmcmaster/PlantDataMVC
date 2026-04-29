using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PlantData.Web.Mvc.Models.ViewComponents.ViewModels;
using PlantData.Web.Mvc.Models.ViewModels.Label;
using System;
using System.Collections.Generic;

namespace PlantData.Web.Mvc.ViewComponents.BarcodeLabelGrid
{
    public class BarcodeLabelGrid : ViewComponent
    {
        private readonly bool _UseBasicHtmlViews = false;

        public BarcodeLabelGrid(IConfiguration configuration)
        {
            _UseBasicHtmlViews = Convert.ToBoolean(configuration["WebUI:UseBasicHtmlViews"]);
        }

        public IViewComponentResult Invoke(IEnumerable<BarcodeLabelListViewModel> barcodeLabels, GridOptionsModel gridOptions)
        {
            string viewName = "Default";

            if (_UseBasicHtmlViews)
                viewName = "Basic";

            var gridModel = new BarcodeLabelGridViewModel()
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

                Items = barcodeLabels
            };

            return View(viewName, gridModel);
        }
    }
}
