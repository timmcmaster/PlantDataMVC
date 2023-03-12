using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace PlantDataMVC.Web.Models.ViewModels.SeedBatch
{
    public class SeedBatchEditViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Species")]
        public int SpeciesId { get; set; }

        [Display(Name = "Date Collected")]
        public DateTime DateCollected { get; set; }

        [StringLength(30), DataType("CustomString")]
        public string Location { get; set; }

        [StringLength(200), DataType("CustomString")]
        public string Notes { get; set; }

        [Display(Name = "Site")]
        public int? SiteId { get; set; } // SiteId
    }
}
