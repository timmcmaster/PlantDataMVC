using System.Collections.Generic;

namespace PlantDataMVC.DTO.Entities
{
    public class SpeciesDTO : DtoEntity
    {
        public int GenusId { get; set; } 

        public string SpecificName { get; set; } 

        public string CommonName { get; set; } 

        public string Description { get; set; }

        public int? PropagationTime { get; set; }

        public bool Native { get; set; }

        public ICollection<PlantStockDTO> PlantStocks { get; set; }
         
        public ICollection<SeedBatchDTO> SeedBatches { get; set; }
    }
}
