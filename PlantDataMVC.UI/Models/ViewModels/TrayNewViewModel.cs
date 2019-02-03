using System;
using System.ComponentModel.DataAnnotations;
using Framework.Web.Views;
using PlantDataMVC.DTO.Dtos;

namespace PlantDataMVC.UI.Models.ViewModels
{
    public class TrayNewViewModel : IViewModel
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
            SeedBatch = new SeedBatchDto();
            DatePlanted = new DateTime();
        }
    }
}
