using Microsoft.AspNetCore.Mvc;
using PlantDataMVC.Web.Models.ViewModels;
using System;
using System.Threading.Tasks;

namespace PlantDataMVC.Web.Shared.Components.ProductTypeGrid
{
    public class ProductTypeGrid : ViewComponent
    {
        public ProductTypeGrid()
        {
            Console.WriteLine("Called VC constructor");
        }

        public async Task<IViewComponentResult> InvokeAsync(ListViewModelStatic<PlantDataMVC.Web.Models.ViewModels.ProductType.ProductTypeListViewModel> model)
        {
            return View(model);
        }
    }
}
