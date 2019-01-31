using System;

namespace PlantDataMVC.DTO.Dtos
{
    public class CreateUpdateSeedBatchDto
    {
        public int SpeciesId { get; set; }
        public DateTime DateCollected { get; set; }
        public string Location { get; set; }
        public string Notes { get; set; }
        public int? SiteId { get; set; }
    }
}