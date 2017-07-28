using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlantDataMVC.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace PlantDataMVC.UI.Models
{
    public class PlantStockTransactionNewViewModel
    {
        [Display(Name = "Plant Stock Entry Id")]
        public int PlantStockEntryId { get; set; }

        [Display(Name = "Transaction Type")]
        public PlantStockTransactionType TransactionType { get; set; }

        [Display(Name = "Transaction Date")]
        public DateTime TransactionDate { get; set; }

        public int Quantity { get; set; }

        [Display(Name = "Seed Tray Id")]
        public int SeedTrayId { get; set; }

        [Display(Name = "Transaction Source"), StringLength(50), DataType("CustomString")]
        public string TransactionSource { get; set; }

        [StringLength(50), DataType("CustomString")]
        public string Notes { get; set; }


        public PlantStockTransactionNewViewModel()
        {
            TransactionDate = new DateTime();
        }
    }
}
