using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PlantDataMVC.UI.Models.ViewModels.Transaction
{
    public class TransactionListViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Plant Stock Id")]
        public int PlantStockId { get; set; }

        [Display(Name = "Transaction Type")]
        public string TransactionTypeName { get; set; }

        [Display(Name = "Transaction Date")]
        public DateTime TransactionDate { get; set; }

        public int Quantity { get; set; }


        public TransactionListViewModel()
        {
            TransactionDate = new DateTime();
        }
    }
}
