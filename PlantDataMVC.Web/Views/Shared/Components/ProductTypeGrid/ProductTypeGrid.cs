using Microsoft.AspNetCore.Mvc;
using PlantDataMVC.Constants;
using PlantDataMVC.Web.Models.ViewModels;
using PlantDataMVC.Web.Models.ViewModels.ProductType;
using System;
using System.Threading.Tasks;

namespace PlantDataMVC.Web.Shared.Components.ProductTypeGrid
{
    public class ProductTypeGrid : ViewComponent
    {
        public ProductTypeGrid()
        {
            Console.WriteLine("Called VC constructor");
        }

        public async Task<IViewComponentResult> InvokeAsync(ListViewModelStatic<ProductTypeListViewModel> model)
        {
            string viewName = "Default";

            if (PlantDataMvcConstants.UseBasicMvcViews)
                viewName = "Basic";

            return View(viewName, model);
        }
    }
}
