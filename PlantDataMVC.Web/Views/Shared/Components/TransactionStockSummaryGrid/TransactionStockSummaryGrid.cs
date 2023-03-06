using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PlantDataMVC.Web.Models.ViewModels;
using PlantDataMVC.Web.Models.ViewModels.Transaction;
using System;
using System.Threading.Tasks;

namespace PlantDataMVC.Web.Shared.Components.TransactionStockSummaryGrid
{
    public class TransactionStockSummaryGrid : ViewComponent
    {
        private readonly bool _useBasicMvcViews = false;

        public TransactionStockSummaryGrid(IConfiguration configuration)
        {
            _useBasicMvcViews = Convert.ToBoolean(configuration["WebUI:UseBasicMvcViews"]);
        }

        public async Task<IViewComponentResult> InvokeAsync(ListViewModelStatic<TransactionStockSummaryListViewModel> model)
        {
            string viewName = "Default";

            if (_useBasicMvcViews)
                viewName = "Basic";

            return View(viewName, model);
        }
    }
}
