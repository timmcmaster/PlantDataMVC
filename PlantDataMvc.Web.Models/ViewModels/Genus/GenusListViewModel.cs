using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace PlantDataMVC.Web.Models.ViewModels.Genus
{
    public class GenusListViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Latin Name")]
        public string LatinName { get; set; }
    }
}