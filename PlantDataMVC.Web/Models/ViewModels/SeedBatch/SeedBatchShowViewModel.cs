using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace PlantDataMVC.UICore.Models.ViewModels.SeedBatch
{
    public class SeedBatchShowViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; private set; }

        [HiddenInput(DisplayValue = false)]
        public int SpeciesId { get; private set; }

        [Display(Name = "Species Name")]
        public string SpeciesBinomial { get; private set; }

        [Display(Name = "Date Collected")]
        public DateTime DateCollected { get; private set; }

        public string Location { get; private set; }

        public string Notes { get; private set; }

        [HiddenInput(DisplayValue = false)]
        public int? SiteId { get; set; } // SiteId

        [Display(Name = "Site Name")]
        public string SiteName { get; set; }
    }
}
