using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;


namespace PlantDataMVC.UICore.Models.ViewModels.Genus
{
    public class GenusDeleteViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Latin Name")]
        public string LatinName { get; set; }
    }
}