using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PlantData.Web.Mvc.Models.ViewComponents.ViewModels;
using PlantData.Web.Mvc.Models.ViewModels;
using PlantData.Web.Mvc.Models.ViewModels.Plant;
using System;
using System.Threading.Tasks;

namespace PlantData.Web.Mvc.ViewComponents.PlantGrid
{
    public class PlantGrid : ViewComponent
    {
        private readonly bool _UseBasicHtmlViews = false;

        public PlantGrid(IConfiguration configuration)
        {
            _UseBasicHtmlViews = Convert.ToBoolean(configuration["WebUI:UseBasicHtmlViews"]);
        }

        public IViewComponentResult Invoke(ListViewModelStatic<PlantListViewModel> model, GridOptionsModel gridOptions)
        {
            // TODO: Need to be able to edit all fields of object (not just ones in grid row) - dropdowns for genus etc
            string viewName = "Default";

            if (_UseBasicHtmlViews)
                viewName = "Basic";

            var gridModel = new PlantGridViewModel()
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
