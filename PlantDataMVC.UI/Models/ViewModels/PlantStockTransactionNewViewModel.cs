using PlantDataMVC.DTO.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace PlantDataMVC.UI.Models.ViewModels
{
    public class PlantStockTransactionNewViewModel
    {
        [Display(Name = "Plant Stock Entry Id")]
        public int PlantStockEntryId { get; set; }

        [Display(Name = "Transaction Type")]
        public JournalEntryTypeDTO TransactionType { get; set; }

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
