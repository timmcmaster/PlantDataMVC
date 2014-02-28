using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PlantDataMvc3.UI.Models
{
    public class SiteNewViewModel
    {
        [Display(Name = "Site Name"), StringLength(50), DataType("CustomString")]
        public string SiteName { get; set; }

        [StringLength(50), DataType("CustomString")]
        public string Suburb { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

    }
}
