using System.Collections.Generic;

namespace PlantDataMVC.Api.Models.DataModels
{
    public class SiteDataModel : IDataModel
    {
        public int Id { get; set; }
        public string SiteName { get; set; }
        public string Suburb { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public ICollection<SeedBatchDataModel> SeedBatches { get; set; }
    }
}