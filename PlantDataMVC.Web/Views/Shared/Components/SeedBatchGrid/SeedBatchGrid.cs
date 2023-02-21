using Microsoft.AspNetCore.Mvc;
using PlantDataMVC.Web.Models.ViewModels;
using PlantDataMVC.Web.Models.ViewModels.SeedBatch;
using System;
using System.Threading.Tasks;

namespace PlantDataMVC.Web.Shared.Components.SeedBatchGrid
{
    public class SeedBatchGrid : ViewComponent
    {
        public SeedBatchGrid()
        {
            Console.WriteLine("Called VC constructor");
        }

        public async Task<IViewComponentResult> InvokeAsync(ListViewModelStatic<SeedBatchListViewModel> model)
        {
            return View(model);
        }
    }
}
