using Microsoft.AspNetCore.Mvc;
using PlantDataMVC.Web.Models.ViewModels;
using System;
using System.Threading.Tasks;

namespace PlantDataMVC.Web.Shared.Components.SaleEventGrid
{
    public class SaleEventGrid : ViewComponent
    {
        public SaleEventGrid()
        {
            Console.WriteLine("Called VC constructor");
        }

        public async Task<IViewComponentResult> InvokeAsync(ListViewModelStatic<PlantDataMVC.Web.Models.ViewModels.SaleEvent.SaleEventListViewModel> model)
        {
            return View(model);
        }
    }
}
