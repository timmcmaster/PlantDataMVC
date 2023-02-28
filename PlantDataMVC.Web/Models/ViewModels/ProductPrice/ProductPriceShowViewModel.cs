using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace PlantDataMVC.Web.Models.ViewModels.ProductPrice
{
    public class ProductPriceShowViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int ProductTypeId { get; set; }

        [Display(Name = "Product Type Name")]
        public string ProductTypeName { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int PriceListTypeId { get; set; }

        [Display(Name = "Price List Name")]
        public string PriceListTypeName { get; set; }

        [Display(Name = "Date Effective")]
        public DateTime DateEffective { get; set; }

        public decimal Price { get; set; }
    }
}