using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PlantData.Web.Mvc.Models.ViewComponents.ViewModels;
using PlantData.Web.Mvc.Models.ViewModels.Transaction;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlantData.Web.Mvc.ViewComponents.TransactionGrid
{
    public class TransactionGrid : ViewComponent
    {
        private readonly bool _UseBasicHtmlViews = false;

        public TransactionGrid(IConfiguration configuration)
        {
            _UseBasicHtmlViews = Convert.ToBoolean(configuration["WebUI:UseBasicHtmlViews"]);
        }

        public IViewComponentResult Invoke(IEnumerable<TransactionListViewModel> transactions, GridOptionsModel gridOptions, int? speciesId = null, int? productTypeId = null)
        {
            string viewName = "Default";

            if (_UseBasicHtmlViews)
            {
                viewName = "Basic";
            }

            var gridModel = new TransactionGridViewModel()
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

                SpeciesId = speciesId,
                ProductTypeId = productTypeId,
                Items = transactions
            };

            return View(viewName, gridModel);
        }
    }
}
