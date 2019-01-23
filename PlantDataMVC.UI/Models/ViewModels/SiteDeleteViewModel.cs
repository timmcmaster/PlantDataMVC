using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PlantDataMVC.UI.Models.ViewModels
{
    public class SiteDeleteViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Site Name")]
        public string SiteName { get; set; }

        public string Suburb { get; set; }

        [DisplayFormat(DataFormatString = "{0:0.00000}")]
        public decimal Latitude { get; set; }

        [DisplayFormat(DataFormatString = "{0:0.00000}")]
        public decimal Longitude { get; set; }
    }
}
