using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace PlantDataMVC.UICore.Models.ViewModels.SaleEvent
{
    public class SaleEventShowViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Sale Name")]
        public string Name { get; set; }

        [Display(Name = "Date of Sale")]
        public DateTime SaleDate { get; set; }

        public string Location { get; set; }
    }
}
