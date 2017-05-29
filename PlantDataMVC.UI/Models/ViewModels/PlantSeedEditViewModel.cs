using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PlantDataMVC.UI.Models
{
    public class PlantSeedEditViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Species Id")]
        public int SpeciesId { get; set; }

        [Display(Name = "Date Collected")]
        public DateTime DateCollected { get; set; }
        
        [StringLength(30), DataType("CustomString")]
        public string Location { get; set; }

        [StringLength(200), DataType("CustomString")]
        public string Notes { get; set; }
    }
}
