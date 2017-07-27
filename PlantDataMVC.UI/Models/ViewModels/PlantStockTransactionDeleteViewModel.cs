using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using PlantDataMVC.Domain.Entities;

namespace PlantDataMVC.UI.Models
{
    public class PlantStockTransactionDeleteViewModel
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

        [Display(Name = "Seed Tray Id")]
        public int SeedTrayId { get; set; }

        [Display(Name = "Transaction Source")]
        public string TransactionSource { get; set; }

        public string Notes { get; set; }


        public PlantStockTransactionDeleteViewModel()
        {
            TransactionDate = new DateTime();
        }
    }
}
