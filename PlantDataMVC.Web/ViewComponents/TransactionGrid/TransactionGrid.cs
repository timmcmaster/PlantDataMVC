using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PlantDataMVC.Web.Models.ViewModels.Transaction;
using PlantDataMVC.Web.ViewComponents.TransactionGrid;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlantDataMVC.Web.ViewComponents.TransactionGrid
{
    public class TransactionGrid : ViewComponent
    {
        private readonly bool _useBasicMvcViews = false;

        public TransactionGrid(IConfiguration configuration)
        {
            _useBasicMvcViews = Convert.ToBoolean(configuration["WebUI:UseBasicMvcViews"]);
        }

        public async Task<IViewComponentResult> InvokeAsync(IEnumerable<TransactionListViewModel> transactions, int? speciesId = null, int? productTypeId = null)
        {
            string viewName = "Default";

            if (_useBasicMvcViews)
            {
                viewName = "Basic";
                return View(viewName, transactions);
            }

            var model = new TransactionGridViewModel()
            {
                SpeciesId = speciesId,
                ProductTypeId = productTypeId,
                Transactions = transactions
            };

            return View(viewName, model);
        }
    }
}
