﻿using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace PlantDataMVC.Web.Models.ViewModels.SeedBatch
{
    public class SeedBatchDeleteViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int SpeciesId { get; set; }

        [Display(Name = "Species Name")]
        public string SpeciesBinomial { get; private set; }

        [Display(Name = "Date Collected")]
        public DateTime DateCollected { get; set; }

        public string Location { get; set; }

        public string Notes { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int? SiteId { get; set; } // SiteId

        [Display(Name = "Site Name")]
        public string SiteName { get; set; }
    }
}
