using PlantDataMVC.DTO.Entities;
using System;
using System.Collections.Generic;

namespace PlantDataMVC.DTO.Entities
{
    public class SeedBatchDTO: DtoEntity
    {
        public int SpeciesId { get; set; }

        public DateTime DateCollected { get; set; }

        public string Location { get; set; }

        public string Notes { get; set; }

        public int? SiteId { get; set; }

        ICollection<SeedTrayDTO> SeedTrays { get; set; }
    }
}
