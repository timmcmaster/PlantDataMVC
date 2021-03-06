﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PlantDataMVC.UI.Models
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
