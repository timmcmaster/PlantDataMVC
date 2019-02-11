using System;
using System.ComponentModel.DataAnnotations;

namespace PlantDataMVC.UI.Models.ViewModels.Tray
{
    public class TrayNewViewModel
    {
        //[Display(Name = "Seed Batch")]
        //public SeedBatchDto SeedBatch { get; set; }

        [Display(Name = "Seed Batch")]
        public int SeedBatchId { get; set; }

        [Display(Name = "Date Planted")]
        public DateTime DatePlanted { get; set; }

        [StringLength(50), DataType("CustomString")]
        public string Treatment { get; set; }

        [Display(Name = "Thrown Out")]
        public bool ThrownOut { get; set; }


        public TrayNewViewModel()
        {
            //SeedBatch = new SeedBatchDto();
            DatePlanted = new DateTime();
        }
    }
}
