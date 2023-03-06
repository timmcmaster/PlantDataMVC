using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PlantDataMVC.Web.Models.ViewModels;
using PlantDataMVC.Web.Models.ViewModels.ProductType;
using System;
using System.Threading.Tasks;

namespace PlantDataMVC.Web.Shared.Components.ProductTypeGrid
{
    public class ProductTypeGrid : ViewComponent
    {
        private readonly bool _useBasicMvcViews = false;

        public ProductTypeGrid(IConfiguration configuration)
        {
            _useBasicMvcViews = Convert.ToBoolean(configuration["WebUI:UseBasicMvcViews"]);
        }

        public async Task<IViewComponentResult> InvokeAsync(ListViewModelStatic<ProductTypeListViewModel> model)
        {
            string viewName = "Default";

            if (_useBasicMvcViews)
                viewName = "Basic";

            return View(viewName, model);
        }
    }
}
