using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PlantDataMVC.UI.Models
{
    public class PlantSeedNewViewModel
    {
        // TODO: Make dropdown for ID and name
        [Display(Name = "Species Id")]
        public int SpeciesId { get; set; }

        [Display(Name = "Species Name")]
        public string SpeciesBinomial { get; set; }

        [Display(Name = "Date Collected")]
        public DateTime DateCollected { get; set; }

        [StringLength(30), DataType("CustomString")]
        public string Location { get; set; }

        [StringLength(200), DataType("CustomString")]
        public string Notes { get; set; }
    }
}
