using System;
using System.Collections.Generic;

namespace PlantDataMVC.Api.Models.DataModels
{
    public class SeedBatchDataModel : IDataModel
    {
        public int Id { get; set; }
        public int SpeciesId { get; set; }
        public string GenusName { get; set; }
        public string SpeciesName { get; set; }
        public DateTime DateCollected { get; set; }
        public string Location { get; set; }
        public string Notes { get; set; }
        public int? SiteId { get; set; }
        public string SiteName { get; set; }
        public ICollection<SeedTrayDataModel> SeedTrays { get; set; }
    }
}