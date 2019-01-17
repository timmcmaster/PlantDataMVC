using PlantDataMVC.DTO.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace PlantDataMVC.UI.Models.ViewModels
{
    public class TrayNewViewModel
    {
        [Display(Name = "Seed Batch")]
        public SeedBatchDto SeedBatch { get; set; }

        [Display(Name = "Date Planted")]
        public DateTime DatePlanted { get; set; }

        [StringLength(50), DataType("CustomString")]
        public string Treatment { get; set; }

        [Display(Name = "Thrown Out")]
        public bool ThrownOut { get; set; }


        public TrayNewViewModel()
        {
            this.SeedBatch = new SeedBatchDto();
            this.DatePlanted = new DateTime();
        }
    }
}
