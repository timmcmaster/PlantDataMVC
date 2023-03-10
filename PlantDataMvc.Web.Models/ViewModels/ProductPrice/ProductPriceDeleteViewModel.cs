using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;


namespace PlantDataMVC.Web.Models.ViewModels.ProductPrice
{
    public class ProductPriceDeleteViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

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
    }
}