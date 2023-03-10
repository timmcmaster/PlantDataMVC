using System;
using System.ComponentModel.DataAnnotations;

namespace PlantDataMVC.Web.Models.ViewModels.SaleEvent
{
    public class SaleEventNewViewModel
    {
        [Display(Name = "Sale Name"), StringLength(30), DataType("CustomString")]
        public string Name { get; set; }

        [Display(Name = "Date of Sale")]
        public DateTime SaleDate { get; set; }

        [StringLength(30), DataType("CustomString")]
        public string Location { get; set; }
    }
}
