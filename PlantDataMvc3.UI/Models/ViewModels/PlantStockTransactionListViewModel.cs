using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using PlantDataMVC.Core.Domain.BusinessObjects;

namespace PlantDataMvc3.UI.Models
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
    }
}
