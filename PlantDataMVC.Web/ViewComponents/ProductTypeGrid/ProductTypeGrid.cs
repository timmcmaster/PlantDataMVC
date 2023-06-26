using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PlantDataMVC.Web.Models.ViewComponents.ViewModels;
using PlantDataMVC.Web.Models.ViewModels;
using PlantDataMVC.Web.Models.ViewModels.ProductType;
using PlantDataMVC.Web.ViewComponents.PriceListTypeGrid;
using System;
using System.Threading.Tasks;

namespace PlantDataMVC.Web.ViewComponents.ProductTypeGrid
{
    public class ProductTypeGrid : ViewComponent
    {
        private readonly bool _useBasicMvcViews = false;

        public ProductTypeGrid(IConfiguration configuration)
        {
            _useBasicMvcViews = Convert.ToBoolean(configuration["WebUI:UseBasicMvcViews"]);
        }

        public IViewComponentResult Invoke(ListViewModelStatic<ProductTypeListViewModel> model, GridOptionsModel gridOptions)
        {
            string viewName = "Default";

            if (_useBasicMvcViews)
                viewName = "Basic";

            var gridModel = new ProductTypeGridViewModel()
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
