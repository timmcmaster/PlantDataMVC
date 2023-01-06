using PlantDataMVC.Api.Models;
using System.Collections.Generic;

namespace PlantDataMVC.Api.Models.DataModels
{
    public class SiteDataModel : IDto
    {
        public int Id { get; set; }
        public string SiteName { get; set; }
        public string Suburb { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public ICollection<SeedBatchDataModel> SeedBatches { get; set; }
    }
}