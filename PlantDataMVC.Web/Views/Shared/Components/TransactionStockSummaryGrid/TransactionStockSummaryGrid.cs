using Microsoft.AspNetCore.Mvc;
using PlantDataMVC.Web.Models.ViewModels;
using PlantDataMVC.Web.Models.ViewModels.Transaction;
using System;
using System.Threading.Tasks;

namespace PlantDataMVC.Web.Shared.Components.TransactionStockSummaryGrid
{
    public class TransactionStockSummaryGrid : ViewComponent
    {
        public TransactionStockSummaryGrid()
        {
            Console.WriteLine("Called VC constructor");
        }

        public async Task<IViewComponentResult> InvokeAsync(ListViewModelStatic<TransactionStockSummaryListViewModel> model)
        {
            return View();
        }
    }
}
