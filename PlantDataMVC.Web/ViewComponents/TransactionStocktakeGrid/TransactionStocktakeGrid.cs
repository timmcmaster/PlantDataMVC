using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PlantDataMVC.Web.Models.ViewComponents.ViewModels;
using PlantDataMVC.Web.Models.ViewModels;
using PlantDataMVC.Web.Models.ViewModels.Transaction;
using System;
using System.Threading.Tasks;

namespace PlantDataMVC.Web.ViewComponents.TransactionStocktakeGrid
{
    public class TransactionStocktakeGrid : ViewComponent
    {
        private readonly bool _useBasicMvcViews = false;

        public TransactionStocktakeGrid(IConfiguration configuration)
        {
            _useBasicMvcViews = Convert.ToBoolean(configuration["WebUI:UseBasicMvcViews"]);
        }

        public IViewComponentResult Invoke(ListViewModelStatic<TransactionStocktakeListViewModel> model, GridOptionsModel gridOptions)
        {
            string viewName = "Default";

            if (_useBasicMvcViews)
                viewName = "Basic";

            var gridModel = new TransactionStocktakeGridViewModel()
            {
                Options = gridOptions,
                PageNumber = model.PageNumber,
                PageSize = model.PageSize,
                HasNextPage = model.HasNextPage,
                HasPreviousPage = model.HasPreviousPage,
                TotalCount = model.TotalCount,
                TotalPages = model.TotalPages,

                SortBy = model.SortBy,
                SortAscending = model.SortAscending,
                SortExpression = model.SortExpression,

                Items = model
            };

            return View(viewName, gridModel);
        }
    }
}
