using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PlantDataMVC.Web.Models.ViewModels;
using PlantDataMVC.Web.Models.ViewModels.PlantStock;
using System;
using System.Threading.Tasks;

namespace PlantDataMVC.Web.Shared.Components.PlantStockGrid
{
    public class PlantStockGrid : ViewComponent
    {
        private readonly bool _useBasicMvcViews = false;

        public PlantStockGrid(IConfiguration configuration)
        {
            _useBasicMvcViews = Convert.ToBoolean(configuration["WebUI:UseBasicMvcViews"]);
        }
        
        public async Task<IViewComponentResult> InvokeAsync(ListViewModelStatic<PlantStockListViewModel> model)
        {
            string viewName = "Default";

            if (_useBasicMvcViews)
                viewName = "Basic";

            return View(viewName, model);

        }
    }
}
