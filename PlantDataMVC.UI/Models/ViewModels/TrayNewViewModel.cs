using PlantDataMVC.DTO.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace PlantDataMVC.UI.Models
{
    public class TrayNewViewModel
    {
        [Display(Name = "Seed Batch")]
        public SeedBatchDTO SeedBatch { get; set; }

        [Display(Name = "Date Planted")]
        public DateTime DatePlanted { get; set; }

        [StringLength(50), DataType("CustomString")]
        public string Treatment { get; set; }

        [Display(Name = "Thrown Out")]
        public bool ThrownOut { get; set; }


        public TrayNewViewModel()
        {
            this.SeedBatch = new SeedBatchDTO();
            this.DatePlanted = new DateTime();
        }
    }
}
