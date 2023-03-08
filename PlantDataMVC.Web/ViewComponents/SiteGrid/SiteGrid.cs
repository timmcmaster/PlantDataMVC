using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PlantDataMVC.Web.Models.ViewModels;
using PlantDataMVC.Web.Models.ViewModels.Site;
using System;
using System.Threading.Tasks;

namespace PlantDataMVC.Web.ViewComponents.SiteGrid
{
    public class SiteGrid : ViewComponent
    {
        private readonly bool _useBasicMvcViews = false;

        public SiteGrid(IConfiguration configuration)
        {
            _useBasicMvcViews = Convert.ToBoolean(configuration["WebUI:UseBasicMvcViews"]);
        }

        public async Task<IViewComponentResult> InvokeAsync(ListViewModelStatic<SiteListViewModel> model)
        {
            // TODO: Default edit needs ability to edit via map position
            string viewName = "Default";

            if (_useBasicMvcViews)
                viewName = "Basic";

            return View(viewName, model);
        }
    }
}
