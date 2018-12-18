using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using PlantDataMVC.Domain.Entities;

namespace PlantDataMVC.UI.Models
{
    public class TrayNewViewModel
    {
        [Display(Name = "Seed Batch")]
        public PlantSeed SeedBatch { get; set; }

        [Display(Name = "Date Planted")]
        public DateTime DatePlanted { get; set; }

        [StringLength(50), DataType("CustomString")]
        public string Treatment { get; set; }

        [Display(Name = "Thrown Out")]
        public bool ThrownOut { get; set; }


        public TrayNewViewModel()
        {
            this.SeedBatch = new PlantSeed();
            this.DatePlanted = new DateTime();
        }
    }
}
