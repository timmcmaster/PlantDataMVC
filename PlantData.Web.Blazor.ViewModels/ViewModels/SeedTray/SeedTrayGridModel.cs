using System;
using System.ComponentModel.DataAnnotations;

namespace PlantData.Web.Blazor.UIModels.ViewModels.SeedTray
{
    public class SeedTrayGridModel
    {
        public int Id { get; set; }

        [Display(Name = "Seed Batch Id")]
        public int SeedBatchId { get; set; }

        [Display(Name = "Species Name")]
        public string SpeciesBinomial { get; set; }

        [Display(Name = "Date Sown")]
        public DateTime DateSown { get; set; }

        public string Treatment { get; set; }

        [Display(Name = "Thrown Out")]
        public bool ThrownOut { get; set; }


        public SeedTrayGridModel()
        {
            DateSown = new DateTime();
        }
    }
}
