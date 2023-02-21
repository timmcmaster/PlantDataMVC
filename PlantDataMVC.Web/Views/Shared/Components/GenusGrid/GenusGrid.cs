using Microsoft.AspNetCore.Mvc;
using PlantDataMVC.Web.Models.ViewModels;
using PlantDataMVC.Web.Models.ViewModels.Genus;
using System;
using System.Threading.Tasks;

namespace PlantDataMVC.Web.Shared.Components.GenusGrid
{
    public class GenusGrid: ViewComponent
    {
        public GenusGrid()
        {
            Console.WriteLine("Called VC constructor");
        }

        public async Task<IViewComponentResult> InvokeAsync(ListViewModelStatic<GenusListViewModel> model)
        {
            return View(model);
        }
    }
}
