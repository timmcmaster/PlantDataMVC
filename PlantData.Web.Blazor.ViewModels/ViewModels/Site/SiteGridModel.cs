using System;
using System.ComponentModel.DataAnnotations;

namespace PlantData.Web.Blazor.UIModels.ViewModels.Site
{
    public class SiteGridModel
    {
        public int Id { get; set; }

        [Display(Name = "Site Name")]
        public string SiteName { get; set; }

        public string Suburb { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }
    }
}
