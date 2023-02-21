using Microsoft.AspNetCore.Mvc;
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
            return View(model);
        }
    }
}
