using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PlantDataMVC.Web.Models.ViewComponents.ViewModels;
using PlantDataMVC.Web.Models.ViewModels.Transaction;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlantDataMVC.Web.ViewComponents.TransactionGrid
{
    public class TransactionGrid : ViewComponent
    {
        private readonly bool _useBasicMvcViews = false;

        public TransactionGrid(IConfiguration configuration)
        {
            _useBasicMvcViews = Convert.ToBoolean(configuration["WebUI:UseBasicMvcViews"]);
        }

        public async Task<IViewComponentResult> InvokeAsync(IEnumerable<TransactionListViewModel> transactions, int? speciesId = null, int? productTypeId = null)
        {
            string viewName = "Default";

            if (_useBasicMvcViews)
            {
                viewName = "Basic";
            }

            var gridOptionsModel = new GridOptionsModel()
            {
                AllowAdd = false,
                AllowDelete = false,
                AllowEdit = false,
                AllowPaging = false,
                AllowSorting = false,
            };

            var gridModel = new TransactionGridViewModel()
            {
                Options = gridOptionsModel,

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
