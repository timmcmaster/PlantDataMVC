using Microsoft.AspNetCore.Mvc;
using PlantDataMVC.Web.Models.ViewModels;
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

        public async Task<IViewComponentResult> InvokeAsync(ListViewModelStatic<PlantDataMVC.Web.Models.ViewModels.PlantStock.PlantStockListViewModel> model)
        {
            return View();
        }
    }
}
