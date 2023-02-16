using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace PlantDataMVC.Web.Models.ViewModels.Transaction
{
    public class TransactionListViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Species Id")]
        public int SpeciesId { get; set; }

        [Display(Name = "Product Type Id")]
        public int ProductTypeId { get; set; }

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
