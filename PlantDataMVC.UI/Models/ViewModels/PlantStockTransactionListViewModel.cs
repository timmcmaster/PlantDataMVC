using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace PlantDataMVC.UI.Models
{
    public class PlantStockTransactionListViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Plant Stock Entry Id")]
        public int PlantStockEntryId { get; set; }

        [Display(Name = "Transaction Type")]
        public string TransactionTypeName { get; set; }

        [Display(Name = "Transaction Date")]
        public DateTime TransactionDate { get; set; }

        public int Quantity { get; set; }


        public PlantStockTransactionListViewModel()
        {
            TransactionDate = new DateTime();
        }
    }
}
