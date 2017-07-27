using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using PlantDataMVC.Domain.Entities;

namespace PlantDataMVC.UI.Models
{
    public class PlantStockEntryShowViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int SpeciesId { get; set; }

        [Display(Name = "Species Name")]
        public string SpeciesBinomial { get; private set; }

        [Display(Name = "Product Type")]
        public string ProductTypeName { get; set; }

        [Display(Name = "Quantity In Stock")]
        public int QuantityInStock { get; set; }

        //public IList<PlantStockTransactionListViewModel> Transactions {get; set;}
    }
}
