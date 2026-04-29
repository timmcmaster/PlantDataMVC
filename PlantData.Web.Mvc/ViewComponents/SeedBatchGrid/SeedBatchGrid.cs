using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PlantData.Web.Mvc.Models.ViewComponents.ViewModels;
using PlantData.Web.Mvc.Models.ViewModels;
using PlantData.Web.Mvc.Models.ViewModels.SeedBatch;
using System;

namespace PlantData.Web.Mvc.ViewComponents.SeedBatchGrid
{
    public class SeedBatchGrid : ViewComponent
    {
        private readonly bool _UseBasicHtmlViews = false;

        public SeedBatchGrid(IConfiguration configuration)
        {
            _UseBasicHtmlViews = Convert.ToBoolean(configuration["WebUI:UseBasicHtmlViews"]);
        }

        public IViewComponentResult Invoke(ListViewModelStatic<SeedBatchListViewModel> model, GridOptionsModel gridOptions)
        {
            // TODO: Need edit with dropdowns and proper selction of species/genus
            string viewName = "Default";

            if (_UseBasicHtmlViews)
                viewName = "Basic";

            var gridModel = new SeedBatchGridViewModel()
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
