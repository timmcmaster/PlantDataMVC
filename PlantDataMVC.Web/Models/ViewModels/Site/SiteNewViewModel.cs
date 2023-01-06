using System.ComponentModel.DataAnnotations;

namespace PlantDataMVC.Web.Models.ViewModels.Site
{
    public class SiteNewViewModel
    {
        [Display(Name = "Site Name"), StringLength(50), DataType("CustomString")]
        public string SiteName { get; set; }

        [StringLength(50), DataType("CustomString")]
        public string Suburb { get; set; }

        [DisplayFormat(DataFormatString = "{0:0.00000}")]
        public decimal Latitude { get; set; }

        [DisplayFormat(DataFormatString = "{0:0.00000}")]
        public decimal Longitude { get; set; }

    }
}
