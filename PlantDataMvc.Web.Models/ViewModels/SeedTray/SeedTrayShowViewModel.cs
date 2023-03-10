using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace PlantDataMVC.Web.Models.ViewModels.SeedTray
{
    public class SeedTrayShowViewModel
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

        [Display(Name = "Date Sown")]
        public DateTime DateSown { get; set; }

        public string Treatment { get; set; }

        [Display(Name = "Thrown Out")]
        public bool ThrownOut { get; set; }

        public SeedTrayShowViewModel()
        {
            DateSown = new DateTime();
        }
    }
}
