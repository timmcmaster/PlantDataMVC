using System;
using System.ComponentModel.DataAnnotations;

namespace PlantDataMVC.UICore.Models.ViewModels.SeedTray
{
    public class SeedTrayNewViewModel
    {
        //[Display(Name = "Seed Batch")]
        //public SeedBatchDataModel SeedBatch { get; set; }

        [Display(Name = "Seed Batch")]
        public int SeedBatchId { get; set; }

        [Display(Name = "Date Planted")]
        public DateTime DatePlanted { get; set; }

        [StringLength(50), DataType("CustomString")]
        public string Treatment { get; set; }

        [Display(Name = "Thrown Out")]
        public bool ThrownOut { get; set; }


        public SeedTrayNewViewModel()
        {
            //SeedBatch = new SeedBatchDataModel();
            DatePlanted = new DateTime();
        }
    }
}
