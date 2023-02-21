using Microsoft.AspNetCore.Mvc;
using PlantDataMVC.Web.Models.ViewModels;
using PlantDataMVC.Web.Models.ViewModels.SaleEvent;
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

        public async Task<IViewComponentResult> InvokeAsync(ListViewModelStatic<SaleEventListViewModel> model)
        {
            return View(model);
        }
    }
}
