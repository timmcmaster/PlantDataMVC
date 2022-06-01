using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace PlantDataMVC.UICore.Models.ViewModels.SaleEvent
{
    public class SaleEventEditViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Sale Name"), StringLength(30), DataType("CustomString")]
        public string Name { get; set; }

        [Display(Name = "Date of Sale")]
        public DateTime SaleDate { get; set; }

        [StringLength(30), DataType("CustomString")]
        public string Location { get; set; }
    }
}
