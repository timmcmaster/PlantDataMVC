using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using PlantDataMVC.Web.Models.ViewModels.ProductPrice;

namespace PlantDataMVC.Web.Models.ViewModels.PriceListType
{
    public class PriceListTypeDetailsViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Kind")]
        public string Kind { get; set; }

        [Display(Name = "Product Prices")]
        public IList<ProductPriceListViewModel> ProductPrices { get; set; }
    }
}