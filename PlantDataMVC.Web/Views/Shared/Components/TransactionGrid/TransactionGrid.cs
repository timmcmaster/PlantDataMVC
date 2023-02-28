﻿using Microsoft.AspNetCore.Mvc;
using PlantDataMVC.Constants;
using PlantDataMVC.Web.Models.ViewModels.Transaction;
using PlantDataMVC.Web.Views.Shared.Components.TransactionGrid;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlantDataMVC.Web.Shared.Components.TransactionGrid
{
    public class TransactionGrid : ViewComponent
    {
        public TransactionGrid()
        {
            Console.WriteLine("Called VC constructor");
        }

        public async Task<IViewComponentResult> InvokeAsync(IEnumerable<TransactionListViewModel> transactions, int? speciesId = null, int? productTypeId = null)
        {
            string viewName = "Default";

            if (PlantDataMvcConstants.UseBasicMvcViews)
            {
                //viewName = "Basic";
                //return View(viewName, model);
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