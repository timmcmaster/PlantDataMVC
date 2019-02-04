using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Framework.Web.Views;

namespace PlantDataMVC.UI.Models.ViewModels
{
    public class TrayEditViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Seed Batch Id")]
        public int SeedBatchId { get; set; }

        [Display(Name = "Date Planted")]
        public DateTime DatePlanted { get; set; }

        [StringLength(50), DataType("CustomString")]
        public string Treatment { get; set; }

        [Display(Name = "Thrown Out")]
        public bool ThrownOut { get; set; }


        public TrayEditViewModel()
        {
            DatePlanted = new DateTime();
        }
    }
}
