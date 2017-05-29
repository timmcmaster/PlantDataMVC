using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using PlantDataMVC.Core.Domain.BusinessObjects;

namespace PlantDataMVC.UI.Models
{
    public class SiteListViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Site Name")]
        public string SiteName { get; set; }

        public string Suburb { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }
    }
}
