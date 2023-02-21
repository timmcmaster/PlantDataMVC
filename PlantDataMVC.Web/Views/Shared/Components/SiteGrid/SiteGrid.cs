using Microsoft.AspNetCore.Mvc;
using PlantDataMVC.Web.Models.ViewModels;
using PlantDataMVC.Web.Models.ViewModels.Site;
using System;
using System.Threading.Tasks;

namespace PlantDataMVC.Web.Shared.Components.SiteGrid
{
    public class SiteGrid : ViewComponent
    {
        public SiteGrid()
        {
            Console.WriteLine("Called VC constructor");
        }

        public async Task<IViewComponentResult> InvokeAsync(ListViewModelStatic<SiteListViewModel> model)
        {
            return View(model);
        }
    }
}
