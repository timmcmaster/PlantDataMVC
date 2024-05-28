using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace PlantData.Web.Mvc.Models.ViewModels.ProductPrice
{
    public class ProductPriceNewViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int PriceListTypeId { get; set; }

        [Display(Name = "Price List Name")]
        public string PriceListTypeName { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int ProductTypeId { get; set; }

        [Display(Name = "Product Type Name")]
        public string ProductTypeName { get; set; }

        [Display(Name = "Date Effective")]
        public DateTime DateEffective { get; set; }

        public decimal Price { get; set; }

        [Display(Name = "SKU")]
        public string BarcodeSKU { get; set; }
    }
}