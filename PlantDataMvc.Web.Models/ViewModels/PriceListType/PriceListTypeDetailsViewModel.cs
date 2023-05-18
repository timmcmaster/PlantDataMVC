using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using PlantDataMVC.Web.Models.ViewComponents.ViewModels;
using PlantDataMVC.Web.Models.ViewModels.ProductPrice;

namespace PlantDataMVC.Web.Models.ViewModels.PriceListType
{
    public class PriceListTypeDetailsViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Kind")]
        public string Kind { get; set; } = string.Empty;

        [Display(Name = "Date Effective")]
        public DateTime SelectedEffectiveDate { get; set; }

        public List<DateTime> EffectiveDates { get; set; } = new();

        [Display(Name = "Product Prices")]
        public List<ProductPriceListViewModel> ProductPrices { get; set; } = new();

        public GridOptionsModel GridOptions { get; set; } = new();
    }
}