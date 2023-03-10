using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PlantDataMVC.Web.Models.ViewComponents.ViewModels;
using PlantDataMVC.Web.Models.ViewModels;
using PlantDataMVC.Web.Models.ViewModels.SeedBatch;
using PlantDataMVC.Web.ViewComponents.SaleEventGrid;
using System;
using System.Threading.Tasks;

namespace PlantDataMVC.Web.ViewComponents.SeedBatchGrid
{
    public class SeedBatchGrid : ViewComponent
    {
        private readonly bool _useBasicMvcViews = false;

        public SeedBatchGrid(IConfiguration configuration)
        {
            _useBasicMvcViews = Convert.ToBoolean(configuration["WebUI:UseBasicMvcViews"]);
        }

        public async Task<IViewComponentResult> InvokeAsync(ListViewModelStatic<SeedBatchListViewModel> model)
        {
            // TODO: Need edit with dropdowns and proper selction of species/genus
            string viewName = "Default";

            if (_useBasicMvcViews)
                viewName = "Basic";

            var gridOptionsModel = new GridOptionsModel()
            {
                AllowAdd = true,
                AllowDelete = true,
                AllowEdit = true,
                AllowPaging = true,
                AllowSorting = true,
            };

            var gridModel = new SeedBatchGridViewModel()
            {
                Options = gridOptionsModel,

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
