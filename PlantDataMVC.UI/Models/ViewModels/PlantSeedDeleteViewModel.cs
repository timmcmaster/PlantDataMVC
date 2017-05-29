using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PlantDataMVC.UI.Models
{
    public class PlantSeedDeleteViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public int SpeciesId { get; set; }
        
        [Display(Name = "Date Collected")]
        public DateTime DateCollected { get; set; }
        
        public string Location { get; set; }
        
        public string Notes { get; set; }
    }
}
