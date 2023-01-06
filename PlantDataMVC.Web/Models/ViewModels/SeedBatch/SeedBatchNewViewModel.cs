using System;
using System.ComponentModel.DataAnnotations;

namespace PlantDataMVC.UICore.Models.ViewModels.SeedBatch
{
    public class SeedBatchNewViewModel
    {
        //[Display(Name = "Species Name")]
        //public SpeciesDataModel PlantSpecies { get; set; }

        [Display(Name = "Species")]
        public int SpeciesId { get; set; }

        [Display(Name = "Date Collected")]
        public DateTime DateCollected { get; set; }

        [StringLength(30), DataType("CustomString")]
        public string Location { get; set; }

        [StringLength(200), DataType("CustomString")]
        public string Notes { get; set; }

        //[Display(Name = "Site Name")]
        //public SiteDataModel Site { get; set; }

        [Display(Name = "Site")]
        public int SiteId { get; set; }

        public SeedBatchNewViewModel()
        {
            //PlantSpecies = new SpeciesDataModel();
            DateCollected = new DateTime();
            //Site = new SiteDataModel();
        }
    }
}
