using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using Framework.Web.Views;

namespace PlantDataMVC.UI.Models.ViewModels
{
    public class GenusListViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Latin Name")]
        public string LatinName { get; set; }
    }
}