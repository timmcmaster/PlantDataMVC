using System;
using System.ComponentModel.DataAnnotations;

namespace PlantDataMVC.UI.Models.ViewModels.Seed
{
    public class PlantSeedNewViewModel
    {
        //[Display(Name = "Species Name")]
        //public SpeciesDto PlantSpecies { get; set; }

        [Display(Name = "Species")]
        public int SpeciesId { get; set; }

        [Display(Name = "Date Collected")]
        public DateTime DateCollected { get; set; }

        [StringLength(30), DataType("CustomString")]
        public string Location { get; set; }

        [StringLength(200), DataType("CustomString")]
        public string Notes { get; set; }

        //[Display(Name = "Site Name")]
        //public SiteDto Site { get; set; }

        [Display(Name = "Site")]
        public int SiteId { get; set; }

        public PlantSeedNewViewModel()
        {
            //PlantSpecies = new SpeciesDto();
            DateCollected = new DateTime();
            //Site = new SiteDto();
        }
    }
}
