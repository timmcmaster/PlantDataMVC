using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PlantDataMVC.UI.Models.ViewModels.Transaction
{
    public class TransactionDeleteViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Plant Stock Entry Id")]
        public int PlantStockId { get; set; }

        [Display(Name = "Transaction Type")]
        public string TransactionTypeName { get; set; }

        [Display(Name = "Transaction Date")]
        public DateTime TransactionDate { get; set; }

        public int Quantity { get; set; }

        [Display(Name = "Seed Tray Id")]
        public int SeedTrayId { get; set; }

        [Display(Name = "Transaction Source")]
        public string TransactionSource { get; set; }

        public string Notes { get; set; }


        public TransactionDeleteViewModel()
        {
            TransactionDate = new DateTime();
        }
    }
}
