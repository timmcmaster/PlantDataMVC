using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PlantDataMVC.UI.Models.ViewModels
{
    public class PlantSeedEditViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int SpeciesId { get; set; }

        [Display(Name = "Species Name")]
        public string SpeciesBinomial { get; private set; }

        [Display(Name = "Date Collected")]
        public DateTime DateCollected { get; set; }
        
        [StringLength(30), DataType("CustomString")]
        public string Location { get; set; }

        [StringLength(200), DataType("CustomString")]
        public string Notes { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int? SiteId { get; set; } // SiteId

        [Display(Name = "Site Name")]
        public string SiteName { get; set; }
    }
}
