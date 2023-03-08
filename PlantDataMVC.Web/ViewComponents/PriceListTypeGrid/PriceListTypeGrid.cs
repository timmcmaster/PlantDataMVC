using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PlantDataMVC.Web.Models.ViewModels;
using PlantDataMVC.Web.Models.ViewModels.PriceListType;
using System;
using System.Threading.Tasks;

namespace PlantDataMVC.Web.ViewComponents.PriceListTypeGrid
{
    public class PriceListTypeGrid : ViewComponent
    {
        private readonly bool _useBasicMvcViews = false;

        public PriceListTypeGrid(IConfiguration configuration)
        {
            _useBasicMvcViews = Convert.ToBoolean(configuration["WebUI:UseBasicMvcViews"]);
        }

        public async Task<IViewComponentResult> InvokeAsync(ListViewModelStatic<PriceListTypeListViewModel> model)
        {
            string viewName = "Default";

            if (_useBasicMvcViews)
                viewName = "Basic";

            return View(viewName, model);
        }
    }
}
