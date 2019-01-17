using PlantDataMVC.DTO.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PlantDataMVC.UI.Models.ViewModels
{
    public class PlantSeedNewViewModel
    {
        [Display(Name = "Species Name")]
        public SpeciesDto PlantSpecies { get; set; }

        [Display(Name = "Date Collected")]
        public DateTime DateCollected { get; set; }

        [StringLength(30), DataType("CustomString")]
        public string Location { get; set; }

        [StringLength(200), DataType("CustomString")]
        public string Notes { get; set; }

        [Display(Name = "Site Name")]
        public SiteDto Site { get; set; }

        public PlantSeedNewViewModel()
        {
            this.PlantSpecies = new SpeciesDto();
            this.DateCollected = new DateTime();
            this.Site = new SiteDto();
        }
    }
}
