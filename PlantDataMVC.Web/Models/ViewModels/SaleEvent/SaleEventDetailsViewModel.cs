using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using PlantDataMVC.Web.Models.ViewModels.SaleEventStock;

namespace PlantDataMVC.Web.Models.ViewModels.SaleEvent
{
    public class SaleEventDetailsViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Sale Name")]
        public string Name { get; set; }

        [Display(Name = "Date of Sale")]
        public DateTime SaleDate { get; set; }

        public string Location { get; set; }

        [Display(Name = "Sale Event Stock Items")]
        public IEnumerable<SaleEventStockListViewModel> SaleEventStocks { get; set; } = new List<SaleEventStockListViewModel>();

        [HiddenInput(DisplayValue = false)]
        public bool ShowAddItem { get; set; }
    }
}
