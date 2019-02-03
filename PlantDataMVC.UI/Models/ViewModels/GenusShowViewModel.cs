using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Framework.Web.Views;

namespace PlantDataMVC.UI.Models.ViewModels
{
    public class GenusShowViewModel : IViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; private set; }

        [Display(Name = "Latin Name")]
        public string LatinName { get; private set; }

    }
}