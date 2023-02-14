using Microsoft.AspNetCore.Mvc;
using PlantDataMVC.Web.Models.ViewModels;
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

        public async Task<IViewComponentResult> InvokeAsync(ListViewModelStatic<PlantDataMVC.Web.Models.ViewModels.Site.SiteListViewModel> model)
        {
            return View(model);
        }
    }
}
