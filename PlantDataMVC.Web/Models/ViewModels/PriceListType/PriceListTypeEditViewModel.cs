using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace PlantDataMVC.Web.Models.ViewModels.PriceListType
{
    public class PriceListTypeEditViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Name"), StringLength(50), DataType("CustomString")]
        public string Name { get; set; }

        [Display(Name = "Kind"), StringLength(1), DataType("CustomString")]
        public string Kind { get; set; }
    }
}