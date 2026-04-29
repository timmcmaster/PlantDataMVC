using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PlantData.Web.Mvc.Models.ViewComponents.ViewModels;
using PlantData.Web.Mvc.Models.ViewModels;
using PlantData.Web.Mvc.Models.ViewModels.Site;
using System;
using System.Threading.Tasks;

namespace PlantData.Web.Mvc.ViewComponents.SiteGrid
{
    public class SiteGrid : ViewComponent
    {
        private readonly bool _UseBasicHtmlViews = false;

        public SiteGrid(IConfiguration configuration)
        {
            _UseBasicHtmlViews = Convert.ToBoolean(configuration["WebUI:UseBasicHtmlViews"]);
        }

        public IViewComponentResult Invoke(ListViewModelStatic<SiteListViewModel> model, GridOptionsModel gridOptions)
        {
            // TODO: Default edit needs ability to edit via map position
            string viewName = "Default";

            if (_UseBasicHtmlViews)
                viewName = "Basic";

            var gridModel = new SiteGridViewModel()
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
