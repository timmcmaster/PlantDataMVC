using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PlantDataMVC.Web.Models.ViewModels;
using PlantDataMVC.Web.Models.ViewModels.Genus;
using System;
using System.Threading.Tasks;

namespace PlantDataMVC.Web.ViewComponents.GenusGrid
{
    public class GenusGrid : ViewComponent
    {
        private readonly bool _useBasicMvcViews = false;

        public GenusGrid(IConfiguration configuration)
        {
            _useBasicMvcViews = Convert.ToBoolean(configuration["WebUI:UseBasicMvcViews"]);
        }

        public async Task<IViewComponentResult> InvokeAsync(ListViewModelStatic<GenusListViewModel> model)
        {
            string viewName = "Default";

            if (_useBasicMvcViews)
                viewName = "Basic";

            return View(viewName, model);
        }
    }
}
