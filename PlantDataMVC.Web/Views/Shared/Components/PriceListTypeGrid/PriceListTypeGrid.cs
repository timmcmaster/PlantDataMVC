using Microsoft.AspNetCore.Mvc;
using PlantDataMVC.Constants;
using PlantDataMVC.Web.Models.ViewModels;
using PlantDataMVC.Web.Models.ViewModels.PriceListType;
using System;
using System.Threading.Tasks;

namespace PlantDataMVC.Web.Shared.Components.PriceListTypeGrid
{
    public class PriceListTypeGrid : ViewComponent
    {
        public PriceListTypeGrid()
        {
            Console.WriteLine("Called VC constructor");
        }

        public async Task<IViewComponentResult> InvokeAsync(ListViewModelStatic<PriceListTypeListViewModel> model)
        {
            string viewName = "Default";

            if (PlantDataMvcConstants.UseBasicMvcViews)
                viewName = "Basic";

            return View(viewName, model);
        }
    }
}
