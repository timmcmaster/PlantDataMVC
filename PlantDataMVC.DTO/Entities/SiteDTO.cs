using Interfaces.DTO;
using System.Collections.Generic;

namespace PlantDataMVC.DTO.Entities
{
    public class SiteDto: IDtoEntity
    {
        public int Id { get; set; }
        public string SiteName { get; set; }
        public string Suburb { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public ICollection<SeedBatchDto> SeedBatches { get; set; }
    }
}
