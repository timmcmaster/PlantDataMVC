using Microsoft.AspNetCore.Mvc;
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
            return View();
        }
    }
}
