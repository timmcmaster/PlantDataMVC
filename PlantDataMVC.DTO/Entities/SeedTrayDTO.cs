using PlantDataMVC.DTO.Entities;
using System;
using System.Collections.Generic;

namespace PlantDataMVC.DTO.Entities
{
    public class SeedTrayDTO: DtoEntity
    {
        public int SeedBatchId { get; set; }

        public DateTime DatePlanted { get; set; }

        public string Treatment { get; set; }

        public bool ThrownOut { get; set; }

        public ICollection<JournalEntryDTO> JournalEntries { get; set; }
    }
}
