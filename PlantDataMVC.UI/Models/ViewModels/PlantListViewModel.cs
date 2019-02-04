using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Framework.Web.Views;

namespace PlantDataMVC.UI.Models.ViewModels
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