using Microsoft.AspNetCore.Mvc;
using PlantDataMVC.Web.Models.ViewComponents.ViewModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlantDataMVC.Web.Models.ViewModels.Transaction
{
    public class TransactionStockSummaryDetailsViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int SpeciesId { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int ProductTypeId { get; set; }

        [Display(Name = "Species Name")]
        public string SpeciesBinomial { get; private set; } = string.Empty;

        [Display(Name = "Product Type")]
        public string ProductTypeName { get; set; } = string.Empty;

        [Display(Name = "Quantity In Stock")]
        public int QuantityInStock { get; set; }

        [Display(Name = "Transactions")]
        public IEnumerable<TransactionListViewModel> Transactions { get; set; } = new List<TransactionListViewModel>();

        public GridOptionsModel GridOptions { get; set; } = new();
    }
}