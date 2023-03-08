using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PlantDataMVC.Web.Models.ViewModels;
using PlantDataMVC.Web.Models.ViewModels.SeedTray;
using System;
using System.Threading.Tasks;

namespace PlantDataMVC.Web.ViewComponents.SeedTrayGrid
{
    public class SeedTrayGrid : ViewComponent
    {
        private readonly bool _useBasicMvcViews = false;

        public SeedTrayGrid(IConfiguration configuration)
        {
            _useBasicMvcViews = Convert.ToBoolean(configuration["WebUI:UseBasicMvcViews"]);
        }

        public async Task<IViewComponentResult> InvokeAsync(ListViewModelStatic<SeedTrayListViewModel> model)
        {
            string viewName = "Default";

            if (_useBasicMvcViews)
                viewName = "Basic";

            return View(viewName, model);
        }
    }
}
