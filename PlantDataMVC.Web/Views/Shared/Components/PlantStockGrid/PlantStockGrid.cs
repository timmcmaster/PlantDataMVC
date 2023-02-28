using Microsoft.AspNetCore.Mvc;
using PlantDataMVC.Constants;
using PlantDataMVC.Web.Models.ViewModels;
using PlantDataMVC.Web.Models.ViewModels.PlantStock;
using System;
using System.Threading.Tasks;

namespace PlantDataMVC.Web.Shared.Components.PlantStockGrid
{
    public class PlantStockGrid : ViewComponent
    {
        public PlantStockGrid()
        {
            Console.WriteLine("Called VC constructor");
        }

        public async Task<IViewComponentResult> InvokeAsync(ListViewModelStatic<PlantStockListViewModel> model)
        {
            string viewName = "Default";

            if (PlantDataMvcConstants.UseBasicMvcViews)
                viewName = "Basic";

            return View(viewName, model);

        }
    }
}
