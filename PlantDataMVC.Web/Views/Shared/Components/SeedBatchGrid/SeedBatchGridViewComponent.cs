using Microsoft.AspNetCore.Mvc;
using PlantDataMVC.Web.Models.ViewModels;
using System;
using System.Threading.Tasks;

namespace PlantDataMVC.Web.Shared.Components.SeedBatchGrid
{
    public class SeedBatchGridViewComponent : ViewComponent
    {
        public SeedBatchGridViewComponent()
        {
            Console.WriteLine("Called VC constructor");
        }

        public async Task<IViewComponentResult> InvokeAsync(ListViewModelStatic<PlantDataMVC.Web.Models.ViewModels.SeedBatch.SeedBatchListViewModel> model)
        {
            return View(model);
        }
    }
}
