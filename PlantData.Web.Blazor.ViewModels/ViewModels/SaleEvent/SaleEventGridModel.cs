using System;
using System.ComponentModel.DataAnnotations;

namespace PlantData.Web.Blazor.UIModels.ViewModels.SaleEvent
{
    public class SaleEventGridModel
    {
        public int Id { get; set; }

        [Display(Name = "Sale Name"), StringLength(30), DataType("CustomString")]
        public string Name { get; set; }

        [Display(Name = "Date of Sale")]
        public DateTime SaleDate { get; set; }

        [StringLength(30), DataType("CustomString")]
        public string Location { get; set; }
    }
}
