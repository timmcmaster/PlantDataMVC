using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace PlantDataMVC.UICore.Models.ViewModels.Genus
{
    public class GenusShowViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; private set; }

        [Display(Name = "Latin Name")]
        public string LatinName { get; private set; }

    }
}