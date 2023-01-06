using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace PlantDataMVC.UICore.Models.ViewModels.SeedTray
{
    public class SeedTrayEditViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        // From SeedBatch
        [HiddenInput(DisplayValue = false)]
        public int SeedBatchId { get; set; }

        [Display(Name = "Species Name")]
        public string SeedBatchSpeciesBinomial { get; private set; }
        
        [Display(Name = "Location")]
        public string SeedBatchLocation { get; private set; }

        [Display(Name = "Date Collected")]
        public DateTime SeedBatchDateCollected { get; private set; }

        [Display(Name = "Date Planted")]
        public DateTime DatePlanted { get; set; }

        [StringLength(50), DataType("CustomString")]
        public string Treatment { get; set; }

        [Display(Name = "Thrown Out")]
        public bool ThrownOut { get; set; }


        public SeedTrayEditViewModel()
        {
            DatePlanted = new DateTime();
        }
    }
}
