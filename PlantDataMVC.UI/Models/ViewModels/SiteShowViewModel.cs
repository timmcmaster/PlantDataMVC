using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Framework.Web.Views;

namespace PlantDataMVC.UI.Models.ViewModels
{
    public class SiteShowViewModel : IViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; private set; }

        [Display(Name = "Site Name")]
        public string SiteName { get; private set; }

        public string Suburb { get; private set; }

        [DisplayFormat(DataFormatString = "{0:0.00000}")]
        public decimal Latitude { get; private set; }

        [DisplayFormat(DataFormatString = "{0:0.00000}")]
        public decimal Longitude { get; private set; }
    }
}
