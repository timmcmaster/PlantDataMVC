using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace PlantDataMVC.Web.Models.ViewModels.Genus
{
    public class GenusEditViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Latin Name"), StringLength(30), DataType("CustomString")]
        public string LatinName { get; set; }
    }
}