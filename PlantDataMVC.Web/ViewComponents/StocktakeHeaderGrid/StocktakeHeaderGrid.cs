using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PlantDataMVC.Web.Models.ViewComponents.ViewModels;
using PlantDataMVC.Web.Models.ViewModels;
using PlantDataMVC.Web.Models.ViewModels.StocktakeHeader;
using System;
using System.Threading.Tasks;

namespace PlantDataMVC.Web.ViewComponents.StocktakeHeaderGrid
{
    public class StocktakeHeaderGrid : ViewComponent
    {
        private readonly bool _useBasicMvcViews = false;

        public StocktakeHeaderGrid(IConfiguration configuration)
        {
            _useBasicMvcViews = Convert.ToBoolean(configuration["WebUI:UseBasicMvcViews"]);
        }

        public IViewComponentResult Invoke(ListViewModelStatic<StocktakeHeaderListViewModel> model, GridOptionsModel gridOptions)
        {
            // TODO: Default edit needs ability to edit via map position
            string viewName = "Default";

            if (_useBasicMvcViews)
                viewName = "Basic";

            var gridModel = new StocktakeHeaderGridViewModel()
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
