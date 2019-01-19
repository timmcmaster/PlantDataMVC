using System.Collections.Generic;
using Interfaces.DTO;

namespace PlantDataMVC.DTO.Dtos
{
    public class SiteDto: IDto
    {
        public int Id { get; set; }
        public string SiteName { get; set; }
        public string Suburb { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public ICollection<SeedBatchDto> SeedBatches { get; set; }
    }
}
