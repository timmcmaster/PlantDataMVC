using Microsoft.AspNetCore.Mvc;
using PlantDataMVC.Web.Models.ViewModels;
using System;
using System.Threading.Tasks;

namespace PlantDataMVC.Web.Shared.Components.GenusGrid
{
    public class GenusGridViewComponent: ViewComponent
    {
        public GenusGridViewComponent()
        {
            Console.WriteLine("Called VC constructor");
        }

        public async Task<IViewComponentResult> InvokeAsync(//ListViewModelStatic<PlantDataMVC.Web.Models.ViewModels.Genus.GenusListViewModel> model
                                                           )
        {
            return View();
        }
    }
}
