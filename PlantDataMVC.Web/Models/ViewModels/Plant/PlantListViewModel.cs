using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace PlantDataMVC.UICore.Models.ViewModels.Plant
{
    public class PlantListViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Latin Name")]
        public string Binomial { get; set; }

        [Display(Name = "Common Name")]
        public string CommonName { get; set; }
    }
}