using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PlantDataMVC.Web.Models.ViewModels;
using PlantDataMVC.Web.Models.ViewModels.Plant;
using PlantDataMVC.Web.ViewComponents.PlantGrid;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlantDataMVC.Web.ViewComponents.PlantGrid
{
    public class PlantGrid : ViewComponent
    {
        private readonly bool _useBasicMvcViews = false;

        public PlantGrid(IConfiguration configuration)
        {
            _useBasicMvcViews = Convert.ToBoolean(configuration["WebUI:UseBasicMvcViews"]);
        }

        public async Task<IViewComponentResult> InvokeAsync(ListViewModelStatic<PlantListViewModel> model)
        {
            // TODO: Need to be able to edit all fields of object (not just ones in grid row) - dropdowns for genus etc
            string viewName = "Default";

            if (_useBasicMvcViews)
                viewName = "Basic";

            var gridModel = new PlantGridViewModel()
            {
                AllowAdd = true,
                AllowDelete = true,
                AllowEdit = true,
                AllowPaging = true,
                AllowSorting = true,

                PageNumber = model.PageNumber,
                PageSize = model.PageSize,
                HasNextPage = model.HasNextPage,
                HasPreviousPage = model.HasPreviousPage,
                TotalCount = model.TotalCount,
                TotalPages = model.TotalPages,

                SortBy = model.SortBy,
                SortAscending = model.SortAscending,
                SortExpression = model.SortExpression,

                Items = (IEnumerable<PlantListViewModel>)model
            };

            //return View(viewName, model);
            return View(viewName, gridModel);
        }
    }
}
