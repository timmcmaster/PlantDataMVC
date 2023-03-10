using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace PlantDataMVC.Web.Models.ViewModels.SaleEventStock
{
    public class SaleEventStockListViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Sale Event Id")]
        public int SaleEventId { get; set; }

        [Display(Name = "Species Id")]
        public int SpeciesId { get; set; }

        [Display(Name = "Product Type Id")]
        public int ProductTypeId { get; set; }

        [Display(Name = "Species Name")]
        public string SpeciesBinomial { get; private set; }

        [Display(Name = "Product Type")]
        public string ProductTypeName { get; set; }

        public int Quantity { get; set; }
    }
}
