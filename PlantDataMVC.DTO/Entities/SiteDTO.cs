using System.Collections.Generic;

namespace PlantDataMVC.DTO.Entities
{
    public class SiteDTO: DtoEntity
    {
        public string SiteName { get; set; }

        public string Suburb { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

        ICollection<SeedBatchDTO> SeedBatches { get; set; }
    }
}
