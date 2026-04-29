using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PlantData.Web.Mvc.Models.ViewComponents.ViewModels;
using PlantData.Web.Mvc.Models.ViewModels;
using PlantData.Web.Mvc.Models.ViewModels.SaleEvent;
using System;
using System.Threading.Tasks;

namespace PlantData.Web.Mvc.ViewComponents.SaleEventGrid
{
    public class SaleEventGrid : ViewComponent
    {
        private readonly bool _UseBasicHtmlViews = false;

        public SaleEventGrid(IConfiguration configuration)
        {
            _UseBasicHtmlViews = Convert.ToBoolean(configuration["WebUI:UseBasicHtmlViews"]);
        }

        public IViewComponentResult Invoke(ListViewModelStatic<SaleEventListViewModel> model, GridOptionsModel gridOptions)
        {
            string viewName = "Default";

            if (_UseBasicHtmlViews)
                viewName = "Basic";

            var gridModel = new SaleEventGridViewModel()
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
