using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Framework.Web.Views;

namespace PlantDataMVC.UI.Models.ViewModels
{
    public class GenusEditViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Latin Name"), StringLength(30), DataType("CustomString")]
        public string LatinName { get; set; }
    }
}