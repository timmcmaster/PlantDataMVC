using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Framework.Web.Views;

namespace PlantDataMVC.UI.Models.ViewModels
{
    public class SiteEditViewModel : IViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Site Name"), StringLength(50), DataType("CustomString")]
        public string SiteName { get; set; }

        [StringLength(50), DataType("CustomString")]
        public string Suburb { get; set; }

        [DisplayFormat(DataFormatString = "{0:0.00000}", ApplyFormatInEditMode = true)]
        public decimal Latitude { get; set; }

        [DisplayFormat(DataFormatString = "{0:0.00000}", ApplyFormatInEditMode = true)]
        public decimal Longitude { get; set; }
    }
}
