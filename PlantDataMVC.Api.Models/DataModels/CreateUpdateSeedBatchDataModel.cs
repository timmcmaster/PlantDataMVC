using System;

namespace PlantDataMVC.Api.Models.DataModels
{
    public class CreateUpdateSeedBatchDataModel
    {
        public int SpeciesId { get; set; }
        public DateTime DateCollected { get; set; }
        public string Location { get; set; }
        public string Notes { get; set; }
        public int? SiteId { get; set; }
    }
}