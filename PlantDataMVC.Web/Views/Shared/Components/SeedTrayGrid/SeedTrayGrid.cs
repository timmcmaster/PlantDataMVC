using Microsoft.AspNetCore.Mvc;
using PlantDataMVC.Web.Models.ViewModels;
using System;
using System.Threading.Tasks;

namespace PlantDataMVC.Web.Shared.Components.SeedTrayGrid
{
    public class SeedTrayGrid : ViewComponent
    {
        public SeedTrayGrid()
        {
            Console.WriteLine("Called VC constructor");
        }

        public async Task<IViewComponentResult> InvokeAsync(ListViewModelStatic<PlantDataMVC.Web.Models.ViewModels.SeedTray.SeedTrayListViewModel> model)
        {
            return View(model);
        }
    }
}
