using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;


namespace PlantDataMVC.Web.Models.ViewModels.PriceListType
{
    public class PriceListTypeDeleteViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }
    }
}