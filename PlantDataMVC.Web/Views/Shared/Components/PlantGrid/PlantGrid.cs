using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PlantDataMVC.Web.Models.ViewModels;
using PlantDataMVC.Web.Models.ViewModels.Plant;
using System;
using System.Threading.Tasks;

namespace PlantDataMVC.Web.Shared.Components.PlantGrid
{
    public class PlantGrid : ViewComponent
    {
        private readonly bool _useBasicMvcViews = false;

        public PlantGrid(IConfiguration configuration)
        {
            _useBasicMvcViews = Convert.ToBoolean(configuration["WebUI:UseBasicMvcViews"]);
        }

        public async Task<IViewComponentResult> InvokeAsync(ListViewModelStatic<PlantListViewModel> model)
        {
            // TODO: Need to be able to edit all fields of object (not just ones in grid row) - dropdowns for genus etc
            string viewName = "Default";

            if (_useBasicMvcViews)
                viewName = "Basic";

            return View(viewName, model);
        }
    }
}
