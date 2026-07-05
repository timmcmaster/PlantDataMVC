using System;
using System.ComponentModel.DataAnnotations;

namespace PlantData.Web.Blazor.UIModels.ViewModels.SeedBatch
{
    public class SeedBatchGridModel
    {
        public int Id { get; set; }

        public int SpeciesId { get; set; }

        [Display(Name = "Species Name")]
        public string SpeciesBinomial { get; set; }

        public int SiteId { get; set; }

        [Display(Name = "Site Name")]
        public string SiteName { get; set; }

        [Display(Name = "Date Collected")]
        public DateTime DateCollected { get; set; }

        public string Location { get; set; }

        public string Notes { get; set; }
    }
}
