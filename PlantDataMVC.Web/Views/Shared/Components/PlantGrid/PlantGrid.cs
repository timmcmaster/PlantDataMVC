using Microsoft.AspNetCore.Mvc;
using PlantDataMVC.Constants;
using PlantDataMVC.Web.Models.ViewModels;
using PlantDataMVC.Web.Models.ViewModels.Plant;
using System;
using System.Threading.Tasks;

namespace PlantDataMVC.Web.Shared.Components.PlantGrid
{
    public class PlantGrid : ViewComponent
    {
        public PlantGrid()
        {
            Console.WriteLine("Called VC constructor");
        }

        public async Task<IViewComponentResult> InvokeAsync(ListViewModelStatic<PlantListViewModel> model)
        {
            string viewName = "Default";

            if (PlantDataMvcConstants.UseBasicMvcViews)
                viewName = "Basic";

            return View(viewName, model);
        }
    }
}
