using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace PlantDataMVC.Web.Models.ViewModels.Transaction
{
    public class TransactionEditViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Species")]
        public int SpeciesId { get; set; }

        [Display(Name = "Product Type")]
        public int ProductTypeId { get; set; }

        [Display(Name = "Transaction Type")]
        public int TransactionTypeId { get; set; }

        [Display(Name = "Transaction Date")]
        public DateTime TransactionDate { get; set; }

        public int Quantity { get; set; }

        [Display(Name = "Effective Quantity"), ReadOnly(true)]
        public int EffectiveQuantity { get; set; }

        [Display(Name = "Seed Tray")]
        public int SeedTrayId { get; set; }

        [Display(Name = "Transaction Source"), StringLength(50), DataType("CustomString")]
        public string TransactionSource { get; set; }

        [StringLength(50), DataType("CustomString")]
        public string Notes { get; set; }


        public TransactionEditViewModel()
        {
            TransactionDate = new DateTime();
        }
    }
}